using System.Collections.Generic;

namespace DemoLib.Models
{
    public interface IProductsModel
    {
        List<Product> Load();

        int GetCountProducts();
    }
}
