using DemoLib.Models;
using DemoLib.Presenters;
using DemoLib.Repositories;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    // цвета
    // доп фон #D2F6E7
    // акцентир #70B2AF
    public partial class MainForm : Form
    {
        private IOrdersRepository ordersRepository_;
        private ProductsPresenter productsPresenter_;

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

            ProductsModel model = new ProductsModel();
            if (ordersRepository_ != null)
            {
                model.UpdatePrices(ordersRepository_);
            }

            productsPresenter_ = new ProductsPresenter(model);
            int countProducts = model.GetCountProducts();
            for (int i = 0; i < countProducts; i++)
            {
                DemoUIComponents.ProductCard card = new DemoUIComponents.ProductCard();
                MainLayout.Controls.Add(card);

                productsPresenter_.AddView(card);
            }

            UpdateCatalog(null);
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

        private void UpdateCatalog(string namePart)
        {
            if (productsPresenter_ == null)
            {
                return;
            }

            try
            {
                productsPresenter_.Update(namePart, GetSortDirection());
            }
            catch (Exception error)
            {
                MessageBox.Show(this, "Не удалось обновить каталог.\n" + error.Message,
                    "Ошибка каталога", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SortComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCatalog(null);
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (productsPresenter_ == null)
            {
                return;
            }

            try
            {
                MessageBox.Show(this, BuildSearchMessage(SearchTextBox.Text),
                    "Результаты поиска", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception error)
            {
                MessageBox.Show(this, "Не удалось выполнить поиск.\n" + error.Message,
                    "Ошибка поиска", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SearchButton.PerformClick();
            }
        }

        private string BuildSearchMessage(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return "Введите часть названия товара";
            }

            var products = productsPresenter_.GetCatalog(query, GetSortDirection());
            if (products.Count == 0)
            {
                return "Товары не найдены";
            }

            StringBuilder message = new StringBuilder();
            message.AppendLine("Найдено товаров: " + products.Count);
            for (int i = 0; i < products.Count; i++)
            {
                var product = products[i];
                message.AppendLine($"{i + 1}. {product.Name} — {product.Price} руб. — остаток: {product.Count}");
            }
            return message.ToString().TrimEnd();
        }

    }
}
