using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace DemoLib.Models
{
    public class ProductsModel : IProductsModel
    {
        private List<Product> data_ = new List<Product>();

        public ProductsModel()
        {
            string imageDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
            if (!Directory.Exists(imageDirectory))
                imageDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Images"));

            data_.Add(new Product
            {
                Name = "Кроссовки для бега «Драйв»",
                Category = "Мужская обувь",
                Count = 72,
                Price = 6550.0,
                Supplier = "Азимут",
                Parts = "Верх —  сетка, подкладка — текстиль, подошва —  резина",
                ImagePath = Path.Combine(imageDirectory, "IMG_MS_185531.png")
            });
            data_.Add(new Product
            {
                Name = "Ботинки мужские демисезонные",
                Category = "Мужская обувь",
                Count = 2,
                Price = 21500.0,
                Supplier = "Барбари",
                Parts = "Натуральная кожа; текстиль; искусственный материал",
                ImagePath = Path.Combine(imageDirectory, "IMG_MB_174349.png")
            });
            data_.Add(new Product
            {
                Name = "Босоножки «Песчаный берег» коричневые",
                Category = "Женская обувь",
                Count = 50,
                Price = 7500.0,
                Supplier = "Стиль и комфорт",
                Parts = "100% козья кожа; подкладка и подошва: 100% кожа",
                ImagePath = Path.Combine(imageDirectory, "IMG_WSd_174332.png")
            });
        }

        public List<Product> Load()
        {
            return data_;
        }

        public int GetCountProducts()
        {
            return data_.Count;
        }
    }
}
