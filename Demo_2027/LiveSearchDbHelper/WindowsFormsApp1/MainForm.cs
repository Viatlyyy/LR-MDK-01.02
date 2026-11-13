using DemoLib.Data;
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
        private DatabaseHelper database_;
        private IOrdersRepository ordersRepository_;
        private ProductsPresenter productsPresenter_;

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(DatabaseHelper database, IOrdersRepository ordersRepository) : this()
        {
            database_ = database;
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
                model = new ProductsModel(database_);
                model.UpdatePrices(ordersRepository_);

                if (CurrentUser != null)
                {
                    CategoryComboBox.Items.Add("Все категории");
                    foreach (string category in database_.LoadCategories())
                    {
                        CategoryComboBox.Items.Add(category);
                    }
                    CategoryComboBox.SelectedIndex = 0;
                }
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

        private void CatalogFilterChanged(object sender, EventArgs e)
        {
            if (CurrentUser == null || productsPresenter_ == null)
            {
                return;
            }

            string category = CategoryComboBox.SelectedIndex > 0
                ? (string)CategoryComboBox.SelectedItem
                : null;
            var products = productsPresenter_.GetCatalog(SearchTextBox.Text, GetSortDirection(), category);

            MainLayout.SuspendLayout();
            productsPresenter_.SetVisibleProducts(products);
            for (int i = 0; i < products.Count; i++)
            {
                Control card = (Control)productsPresenter_.GetView(products[i]);
                if (MainLayout.Controls[i] != card)
                {
                    MainLayout.Controls.SetChildIndex(card, i);
                }
            }
            MainLayout.ResumeLayout(true);
        }
    }
}
