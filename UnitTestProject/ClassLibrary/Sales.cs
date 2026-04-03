using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Sales
    {
       public List<Product> allProducts = new List<Product>();

        public List<Product> LoadProduct()
        {
            string path = "..\\..\\..\\продажи.txt";
            StreamReader sr = new StreamReader(path);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] lines = line.Split(';');
                allProducts.Add(new Product
                {
                    Name = lines[0],
                    Price = Convert.ToDouble(lines[1]),
                    Count = Convert.ToInt32(lines[2])
                });
            }
            return allProducts;
                
            }
        }
    }

