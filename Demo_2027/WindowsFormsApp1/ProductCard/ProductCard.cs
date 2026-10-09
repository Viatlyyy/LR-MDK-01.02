using DemoLib;
using DemoLib.Views;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace DemoUIComponents
{
    public partial class ProductCard : System.Windows.Forms.UserControl, IProductsView
    {
        private int count_;
        public ProductCard()
        {
            InitializeComponent();
            foreach(Control c in Controls)
            {
                c.MouseMove += ProductCard_MouseMove;
                c.MouseLeave += ProductCard_MouseLeave;
            }
            
        }

        public void Show(Product product)
        {
            count_ = product.Count;

            CategoryLabel.Text = product.Category;
            if (product.Count > 5)
            {
                CountLabel.Text = product.Count.ToString() + " (много)";
            }
            else
            {
                CountLabel.Text = product.Count.ToString() + " (мало)";
            }
                PartsLabel.Text = product.Parts;
            PriceProductLabel.Text = product.Price.ToString("N2", CultureInfo.GetCultureInfo("ru-RU")) + " ₽";
            SupplierLabel.Text = product.Supplier + " | " + product.Name; 

            if (product.ImagePath == "" || product.ImagePath == null)
            {
                ImagePictureBox.ImageLocation = "..\\..\\..\\Images\\picture.png";
            }
            else
            {
                ImagePictureBox.ImageLocation = product.ImagePath;
            }      
            
            if (product.Count <= 3)
            {
                BackColor = ColorTranslator.FromHtml("#FF8080");;
            }

        }

        private void ProductCard_MouseMove(object sender, MouseEventArgs e)
        {
            BackColor = ColorTranslator.FromHtml("#70B2AF");
        }

        private void ProductCard_MouseLeave(object sender, System.EventArgs e)
        {
            if (count_ <= 3)
            {
                BackColor = ColorTranslator.FromHtml("#FF8080");
            }
            else
                BackColor = ColorTranslator.FromHtml("#D2F6E7");

        }

        private void ProductCard_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }


    }
}
