using DemoLib.Models;
using DemoLib.Presenters;
using DemoLib.Repositories;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    // цвета
    // доп фон #D2F6E7
    // акцентир #70B2AF
    public partial class MainForm : Form
    {
        private ProductsPresenter productsPresenter_;
        private ProductsModel model_ = new ProductsModel();
        private IOrdersRepository ordersRepository_;
        private bool productCardResizePending_;

        public MainForm()
        {
            InitializeComponent();

            productsPresenter_ = new ProductsPresenter(model_);
            MainLayout.ClientSizeChanged += MainLayout_ClientSizeChanged;
        }

        public MainForm(IOrdersRepository ordersRepository) : this()
        {
            ordersRepository_ = ordersRepository;
        }

        public User CurrentUser { get; set; }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            if (CurrentUser != null)
            {
                UserNameLabel.Text = CurrentUser.FullName;
                UserRoleLabel.Text = CurrentUser.Role;
            }
            else
            {
                UserNameLabel.Text = "Гость";
                UserRoleLabel.Text = "Просмотр каталога";
                PagesTabControl.TabPages.Remove(OrdersTabPage);
                OrdersTabPage.Dispose();
            }

            // До подключения репозитория показываем исходные цены, а не считаем заказы пустыми.
            if (ordersRepository_ != null)
            {
                model_.UpdatePrices(ordersRepository_);
            }

            int countProducts = model_.GetCountProducts();
            for (int i = 0; i < countProducts; i++)
            {
                DemoUIComponents.ProductCard card = new DemoUIComponents.ProductCard();
                MainLayout.Controls.Add(card);

                productsPresenter_.AddView(card);
            }

            productsPresenter_.Update();
            ResizeProductCards();
        }

        private void MainLayout_ClientSizeChanged(object sender, EventArgs e)
        {
            QueueProductCardResize();
        }

        private void QueueProductCardResize()
        {
            if (productCardResizePending_ || !IsHandleCreated || IsDisposed || Disposing)
            {
                return;
            }

            // Scrollbars can change the client width during layout. Resize on the next UI pass.
            productCardResizePending_ = true;
            BeginInvoke(new MethodInvoker(delegate
            {
                productCardResizePending_ = false;
                if (!IsDisposed && !Disposing)
                {
                    ResizeProductCards();
                }
            }));
        }

        private void ResizeProductCards()
        {
            int availableWidth = MainLayout.ClientSize.Width - MainLayout.Padding.Horizontal;
            if (availableWidth <= 0)
            {
                return;
            }

            MainLayout.SuspendLayout();
            try
            {
                foreach (Control card in MainLayout.Controls)
                {
                    int width = Math.Max(1, availableWidth - card.Margin.Horizontal);
                    if (card.Width != width)
                    {
                        card.Width = width;
                    }
                }
            }
            finally
            {
                MainLayout.ResumeLayout(true);
            }
        }

        private void PagesTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PagesTabControl.SelectedTab == CardsTabPage)
            {
                QueueProductCardResize();
                WindowTitleLabel.Text = "Карточки товаров";
                Text = "Чудо Обувь — Карточки";
            }
            else
            {
                WindowTitleLabel.Text = "Заказы";
                Text = "Чудо Обувь — Заказы";
            }
        }

    }
}
