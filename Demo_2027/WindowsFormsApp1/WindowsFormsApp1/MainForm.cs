using DemoLib.Models;
using DemoLib.Presenters;
using DemoLib.Repositories;
using System;
using System.ComponentModel;
using System.Drawing;
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

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (CurrentUser != null)
            {
                UserNameLabel.Text = CurrentUser.FullName;
                UserRoleLabel.Text = CurrentUser.Role;
                ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
                UserAvatarPictureBox.Image = resources.GetObject("Avatar." + CurrentUser.Login) as Image
                    ?? UserAvatarPictureBox.Image;
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
                MainLayout.Controls.Add(card);

                productsPresenter.AddView(card);
            }

            productsPresenter.Update();
        }

    }
}
