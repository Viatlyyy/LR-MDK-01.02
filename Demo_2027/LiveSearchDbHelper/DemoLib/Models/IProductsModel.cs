using System.Collections.Generic;

namespace DemoLib.Models
{
    public interface IProductsModel
    {
        List<Product> Load();

        List<Product> GetCatalog(string namePart, bool? ascending, string category = null);

        int GetCountProducts();
    }
}
