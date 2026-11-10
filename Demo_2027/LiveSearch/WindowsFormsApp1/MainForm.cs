using DemoLib.Models;
using DemoLib.Presenters;
using DemoLib.Repositories;
using System;
using System.ComponentModel;
using System.Data.Common;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    // цвета
    // доп фон #D2F6E7
    // акцентир #70B2AF
    public partial class MainForm : Form
    {
        private string connectionString_;
        private IOrdersRepository ordersRepository_;
        private ProductsPresenter productsPresenter_;

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(string connectionString, IOrdersRepository ordersRepository) : this()
        {
            connectionString_ = connectionString;
            ordersRepository_ = ordersRepository;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public User CurrentUser { get; set; }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            CatalogToolsPanel.Visible = CurrentUser != null;
            if (SortComboBox.SelectedIndex < 0)
            {
                SortComboBox.SelectedIndex = 0;
            }

            if (CurrentUser != null)
            {
                UserNameLabel.Text = CurrentUser.FullName;
                UserRoleLabel.Text = CurrentUser.Role;
                ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
                UserAvatarPictureBox.Image = resources.GetObject("Avatar." + CurrentUser.Login) as Image
                    ?? UserAvatarPictureBox.Image;
            }

            ProductsModel model;
            try
            {
                model = new ProductsModel(connectionString_);
                model.UpdatePrices(ordersRepository_);
            }
            catch (Exception error) when (error is DbException || error is InvalidOperationException || error is ArgumentException)
            {
                CatalogToolsPanel.Enabled = false;
                MainLayout.Controls.Add(new Label
                {
                    AutoSize = true,
                    Text = "Не удалось загрузить каталог из PostgreSQL. Проверьте запуск базы и настройки подключения."
                });
                return;
            }

            productsPresenter_ = new ProductsPresenter(model);
            MainLayout.SuspendLayout();
            foreach (var product in productsPresenter_.GetCatalog(null, GetSortDirection()))
            {
                DemoUIComponents.ProductCard card = new DemoUIComponents.ProductCard();
                productsPresenter_.AddView(product, card);
                MainLayout.Controls.Add(card);
            }
            MainLayout.ResumeLayout(true);
        }

        private bool? GetSortDirection()
        {
            if (SortComboBox.SelectedIndex == 1)
            {
                return true;
            }
            if (SortComboBox.SelectedIndex == 2)
            {
                return false;
            }
            return null;
        }

        private void SortComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CurrentUser == null || productsPresenter_ == null)
            {
                return;
            }

            var products = productsPresenter_.GetCatalog(null, GetSortDirection());
            MainLayout.SuspendLayout();
            for (int i = 0; i < products.Count; i++)
            {
                Control card = (Control)productsPresenter_.GetView(products[i]);
                MainLayout.Controls.SetChildIndex(card, i);
            }
            MainLayout.ResumeLayout(true);
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (CurrentUser == null || productsPresenter_ == null)
            {
                return;
            }

            MainLayout.SuspendLayout();
            productsPresenter_.Filter(SearchTextBox.Text);
            MainLayout.ResumeLayout(true);
        }
    }
}
