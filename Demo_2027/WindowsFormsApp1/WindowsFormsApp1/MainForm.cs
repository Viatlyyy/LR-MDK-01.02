using System;
using DemoLib.Models;
using DemoLib.Presenters;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
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

            ResizeProductCards();
            productsPresenter_.Update();
        }

        private void MainLayout_ClientSizeChanged(object sender, EventArgs e)
        {
            ResizeProductCards();
        }

        private void ResizeProductCards()
        {
            MainLayout.SuspendLayout();
            try
            {
                foreach (Control card in MainLayout.Controls)
                {
                    // ClientSize already excludes the visible scroll bar.
                    card.Width = Math.Max(0, MainLayout.ClientSize.Width
                        - MainLayout.Padding.Horizontal - card.Margin.Horizontal);
                }
            }
            finally
            {
                MainLayout.ResumeLayout(true);
            }
        }
    }
}
