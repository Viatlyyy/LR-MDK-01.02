using DemoLib;
using DemoLib.Views;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DemoUIComponents
{
    public partial class ProductCard : UserControl, IProductsView
    {
        public ProductCard()
        {
            InitializeComponent();
        }

        public void Show(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            NameLabel.Text = string.IsNullOrEmpty(product.Supplier)
                ? product.Name ?? string.Empty
                : product.Supplier + " | " + (product.Name ?? string.Empty);
            CategoryLabel.Text = "Категория: " + product.Category;
            CountLabel.Text = "Количество: " + (product.Count > 5 ? "много" : "мало");
            PartsLabel.Text = "Состав: " + product.Parts;
            PriceLabel.Text = product.Price.ToString("C", CultureInfo.GetCultureInfo("ru-RU"));
            BackColor = product.Count <= 3 ? Color.FromArgb(255, 128, 128) : Color.White;

            Image nextImage = LoadProductImage(product.ImagePath);
            Image previousImage = ProductPictureBox.Image;
            ProductPictureBox.Image = nextImage;
            if (previousImage != null)
                previousImage.Dispose();
        }

        private static Image LoadProductImage(string imagePath)
        {
            if (!string.IsNullOrWhiteSpace(imagePath))
            {
                try
                {
                    string fullPath = Path.IsPathRooted(imagePath)
                        ? imagePath
                        : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, imagePath);
                    if (File.Exists(fullPath))
                    {
                        using (Image source = Image.FromFile(fullPath))
                            return new Bitmap(source);
                    }
                }
                catch (ArgumentException) { }
                catch (IOException) { }
                catch (UnauthorizedAccessException) { }
                catch (ExternalException) { }
                // GDI+ also reports an invalid image format as OutOfMemoryException.
                catch (OutOfMemoryException) { }
            }

            var resources = new ComponentResourceManager(typeof(ProductCard));
            return (Image)resources.GetObject("ProductPictureBox.Image");
        }

        private void DisposeProductImage()
        {
            if (ProductPictureBox == null)
                return;
            Image image = ProductPictureBox.Image;
            ProductPictureBox.Image = null;
            if (image != null)
                image.Dispose();
        }
    }
}
