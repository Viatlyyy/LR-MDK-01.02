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
        public MainForm()
        {
            InitializeComponent();

            productsPresenter_ = new ProductsPresenter(model_);
        }

        public MainForm(IOrdersRepository ordersRepository)
        {
            InitializeComponent();
            productsPresenter_ = new ProductsPresenter(model_);
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
