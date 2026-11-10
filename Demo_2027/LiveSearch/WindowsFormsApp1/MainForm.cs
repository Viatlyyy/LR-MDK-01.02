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
            foreach (var product in productsPresenter_.GetCatalog(null, GetSortDirection()))
            {
                DemoUIComponents.ProductCard card = new DemoUIComponents.ProductCard();
                productsPresenter_.AddView(product, card);
                MainLayout.Controls.Add(card);
            }
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
            if (productsPresenter_ == null)
            {
                return;
            }

            MainLayout.SuspendLayout();
            try
            {
                var products = productsPresenter_.GetCatalog(null, GetSortDirection());
                for (int i = 0; i < products.Count; i++)
                {
                    Control card = (Control)productsPresenter_.GetView(products[i]);
                    MainLayout.Controls.SetChildIndex(card, i);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(this, "Не удалось обновить каталог.\n" + error.Message,
                    "Ошибка каталога", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                MainLayout.ResumeLayout();
            }
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (productsPresenter_ == null)
            {
                return;
            }

            MainLayout.SuspendLayout();
            try
            {
                productsPresenter_.Filter(SearchTextBox.Text);
            }
            finally
            {
                MainLayout.ResumeLayout();
            }
        }

    }
}
