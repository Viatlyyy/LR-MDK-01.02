using System.Collections.Generic;

namespace DemoLib.Models
{
    public interface IProductsModel
    {
        List<Product> Load();

        List<Product> GetCatalog(CatalogParams parameters);

        int GetCountProducts();
    }
}
