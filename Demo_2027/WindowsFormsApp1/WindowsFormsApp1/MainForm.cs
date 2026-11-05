using DemoLib.Models;
using DemoLib.Presenters;
using DemoLib.Repositories;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    // цвета
    // доп фон #D2F6E7
    // акцентир #70B2AF
    public partial class MainForm : Form
    {
        private IOrdersRepository ordersRepository_;

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(IOrdersRepository ordersRepository) : this()
        {
            ordersRepository_ = ordersRepository;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public User CurrentUser { get; set; }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return;
            }

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

            ProductsModel model = new ProductsModel();
            ProductsPresenter productsPresenter = new ProductsPresenter(model);
            if (ordersRepository_ != null)
            {
                model.UpdatePrices(ordersRepository_);
            }

            int countProducts = model.GetCountProducts();
            for (int i = 0; i < countProducts; i++)
            {
                DemoUIComponents.ProductCard card = new DemoUIComponents.ProductCard();
                card.Dock = DockStyle.Top;
                MainLayout.Controls.Add(card);
                card.BringToFront(); // При DockStyle.Top это помещает новую карточку под предыдущими.

                productsPresenter.AddView(card);
            }

            productsPresenter.Update();
        }

        private void PagesTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PagesTabControl.SelectedTab == CardsTabPage)
            {
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
