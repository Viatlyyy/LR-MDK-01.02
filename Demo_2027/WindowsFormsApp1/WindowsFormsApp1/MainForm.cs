using DemoLib.Models;
using DemoLib.Presenters;
using DemoLib.Repositories;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            UserStatusPictureBox.Invalidate();

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

        private void CardsButton_Click(object sender, EventArgs e)
        {
            MainLayout.Visible = true;
            OrdersPanel.Visible = false;
            CardsButton.BackColor = Color.FromArgb(112, 178, 175);
            OrdersButton.BackColor = Color.FromArgb(210, 246, 231);
            WindowTitleLabel.Text = "Карточки товаров";
            Text = "Чудо Обувь — Карточки";
        }

        private void OrdersButton_Click(object sender, EventArgs e)
        {
            MainLayout.Visible = false;
            OrdersPanel.Visible = true;
            CardsButton.BackColor = Color.FromArgb(210, 246, 231);
            OrdersButton.BackColor = Color.FromArgb(112, 178, 175);
            WindowTitleLabel.Text = "Заказы";
            Text = "Чудо Обувь — Заказы";
        }

        private void UserStatusPictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TranslateTransform(0, (UserStatusPictureBox.Height - 56) / 2F);
            using (Pen outline = new Pen(Color.FromArgb(55, 75, 70), 2F))
            {
                e.Graphics.DrawEllipse(outline, 14, 10, 16, 16);
                e.Graphics.DrawArc(outline, 7, 29, 30, 26, 180, 180);
            }
            Color statusColor = CurrentUser == null ? Color.Gray : Color.FromArgb(112, 178, 175);
            using (Brush status = new SolidBrush(statusColor))
            {
                e.Graphics.FillEllipse(status, 31, 38, 10, 10);
            }
        }
    }
}
