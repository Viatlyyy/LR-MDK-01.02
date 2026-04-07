using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class SaleAnalyzer
    {
        public double CalculateRevenue(string productName)
        {
            Sales sales = new Sales();
            List<Product> products = sales.LoadProduct();

            foreach (Product product in products)
            {
                if (product.Name == productName)
                {
                    return product.Price * product.Count;
                }
            }

            return 0;
        }
    }
}