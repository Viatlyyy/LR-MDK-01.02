using DemoLib;
using DemoLib.Views;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DemoUIComponents
{
    public partial class ProductCard : System.Windows.Forms.UserControl, IProductsView
    {
        private Product product_;
        private bool hovered_;

        private Color normalColor_ = ColorTranslator.FromHtml("#D2F6E7");
        private Color enteringColor_ = ColorTranslator.FromHtml("#70B2AF");
        private Color deficitColor_ = ColorTranslator.FromHtml("#FF8080");

        public ProductCard()
        {
            InitializeComponent();
            foreach(Control c in Controls)
            {
                c.MouseEnter += ProductCard_MouseEnter;
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
            string path = product_.ImagePath;
            if (string.IsNullOrEmpty(path))
            {
                path = "..\\..\\..\\Images\\picture.png";
            }

            if (File.Exists(path))
            {
                return path;
            }

            return Path.Combine(Application.StartupPath, "Images", Path.GetFileName(path));
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

        private void ProductCard_MouseEnter(object sender, EventArgs e)
        {
            SetHovered(true);
        }

        private void ProductCard_MouseLeave(object sender, EventArgs e)
        {
            if (!ClientRectangle.Contains(PointToClient(MousePosition)))
            {
                SetHovered(false);
            }
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (!Visible)
            {
                SetHovered(false);
            }
        }

        private void SetHovered(bool hovered)
        {
            if (hovered_ != hovered)
            {
                hovered_ = hovered;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (hovered_)
            {
                ControlPaint.DrawBorder(e.Graphics, ClientRectangle, enteringColor_, ButtonBorderStyle.Solid);
            }
        }
    }
}
