using DemoLib.Models;
using DemoLib.Presenters;
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
        public MainForm()
        {
            InitializeComponent();

            productsPresenter_ = new ProductsPresenter(model_);
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            int countProducts = model_.GetCountProducts();
            for (int i = 0; i < countProducts; i++)
            {
                DemoUIComponents.ProductCard card = new DemoUIComponents.ProductCard();
                MainLayout.Controls.Add(card);

                productsPresenter_.AddView(card);
            }

            productsPresenter_.Update();
        }
    }
}
