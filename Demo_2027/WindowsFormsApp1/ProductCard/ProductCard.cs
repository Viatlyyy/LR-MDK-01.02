using DemoLib;
using DemoLib.Views;
using System.Drawing;
using System.Windows.Forms;

namespace DemoUIComponents
{
    public partial class ProductCard : System.Windows.Forms.UserControl, IProductsView
    {
        private Product product_;

        private Color normalColor_ = ColorTranslator.FromHtml("#D2F6E7");
        private Color enteringColor_ = ColorTranslator.FromHtml("#70B2AF");
        private Color deficitColor_ = ColorTranslator.FromHtml("#FF8080");

        public ProductCard()
        {
            InitializeComponent();
            foreach(Control c in Controls)
            {
                c.MouseMove += ProductCard_MouseMove;
                c.MouseLeave += ProductCard_MouseLeave;
            }
            
        }

        private string CountText()
        {
            if (product_.Count > 5)
            {
                return product_.Count.ToString() + " (много)";
            }

            return product_.Count.ToString() + " (мало)";
        }

        private string ImagePath()
        {
            if (product_.ImagePath == "" || product_.ImagePath == null)
            {
                return "..\\..\\..\\Images\\picture.png";
            }

            return product_.ImagePath;
        }

        private Color GetColor()
        {
            if (product_ != null && product_.Count <= 3)
            {
                return deficitColor_;
            }

            return normalColor_;
        }

        public void Show(Product product)
        {
            product_ = product;

            CategoryLabel.Text = product.Category;

            CountLabel.Text = CountText();

            PartsLabel.Text = product.Parts;
            PriceProductLabel.Text = product.Price.ToString() + " руб.";
            SupplierLabel.Text = product.Supplier + " | " + product.Name; 

            ImagePictureBox.ImageLocation = ImagePath();

            BackColor = GetColor();

        }

        private void ProductCard_MouseMove(object sender, MouseEventArgs e)
        {
            BackColor = enteringColor_;
        }

        private void ProductCard_MouseLeave(object sender, System.EventArgs e)
        {
            BackColor = GetColor();

        }

        /*
        private void ProductCard_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }
        */


    }
}
