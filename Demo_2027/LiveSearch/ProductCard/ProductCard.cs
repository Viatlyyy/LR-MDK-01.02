using DemoLib;
using DemoLib.Views;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DemoUIComponents
{
    public partial class ProductCard : UserControl, IProductsView
    {
        private Product product_;
        private Bitmap productImage_;
        private bool hovered_;

        private Color normalColor_ = ColorTranslator.FromHtml("#D2F6E7");
        private Color enteringColor_ = ColorTranslator.FromHtml("#70B2AF");
        private Color deficitColor_ = ColorTranslator.FromHtml("#FF8080");

        public ProductCard()
        {
            InitializeComponent();
            DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw, true);
            Disposed += ProductCard_Disposed;
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
            PriceProductLabel.Text = product.Price + " руб.";
            SupplierLabel.Text = product.Supplier + " | " + product.Name;
            AccessibleName = SupplierLabel.Text;
            AccessibleDescription = $"{label1.Text}: {CategoryLabel.Text}. {label2.Text}: {CountLabel.Text}. "
                + $"{label3.Text}: {PartsLabel.Text}. {PriceProductLabel.Text}";

            Bitmap image = LoadProductImage();
            productImage_?.Dispose();
            productImage_ = image;

            // The designer controls provide layout; the card paints their content together at runtime.
            foreach (Control control in Controls)
            {
                control.Visible = false;
            }

            BackColor = GetColor();
            Invalidate();
        }

        private Bitmap LoadProductImage()
        {
            try
            {
                using (Image source = Image.FromFile(ImagePath()))
                {
                    return new Bitmap(source);
                }
            }
            catch (IOException)
            {
                return null;
            }
            catch (ArgumentException)
            {
                return null;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (product_ == null)
            {
                return;
            }

            Image image = productImage_ ?? ImagePictureBox.ErrorImage;
            Rectangle area = ImagePictureBox.Bounds;
            if (image != null && area.Width > 0 && area.Height > 0)
            {
                double scale = Math.Min((double)area.Width / image.Width, (double)area.Height / image.Height);
                int width = Math.Max(1, (int)(image.Width * scale));
                int height = Math.Max(1, (int)(image.Height * scale));
                Rectangle destination = new Rectangle(
                    area.Left + (area.Width - width) / 2, area.Top + (area.Height - height) / 2, width, height);
                e.Graphics.DrawImage(image, destination, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);
            }

            DrawLabel(e.Graphics, SupplierLabel, TextFormatFlags.WordBreak);
            DrawLabel(e.Graphics, label1, TextFormatFlags.SingleLine);
            DrawLabel(e.Graphics, CategoryLabel, TextFormatFlags.SingleLine);
            DrawLabel(e.Graphics, label2, TextFormatFlags.SingleLine);
            DrawLabel(e.Graphics, CountLabel, TextFormatFlags.SingleLine);
            DrawLabel(e.Graphics, label3, TextFormatFlags.SingleLine);
            DrawLabel(e.Graphics, PartsLabel, TextFormatFlags.WordBreak);
            DrawLabel(e.Graphics, PriceProductLabel, TextFormatFlags.SingleLine | TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
            if (hovered_)
            {
                ControlPaint.DrawBorder(e.Graphics, ClientRectangle, enteringColor_, ButtonBorderStyle.Solid);
            }
        }

        private void DrawLabel(Graphics graphics, Label label, TextFormatFlags flags)
        {
            if (label.AutoEllipsis)
            {
                flags |= TextFormatFlags.EndEllipsis;
            }

            TextRenderer.DrawText(graphics, label.Text, label.Font, label.Bounds, label.ForeColor,
                flags | TextFormatFlags.PreserveGraphicsClipping | TextFormatFlags.NoPrefix);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            SetHovered(true);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            SetHovered(false);
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

        private void ProductCard_Disposed(object sender, EventArgs e)
        {
            productImage_?.Dispose();
        }
    }
}
