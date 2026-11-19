using DemoLib.Models;
using DemoLib.Views;
using System.Collections.Generic;

namespace DemoLib.Presenters
{
    public class ProductsPresenter
    {
        private IProductsModel model_;
        private Dictionary<Product, IProductsView> views_ = new Dictionary<Product, IProductsView>();

        public ProductsPresenter(IProductsModel model)
        {
            model_ = model;
        }

        public void AddView(Product product, IProductsView view)
        {
            view.Show(product);
            views_.Add(product, view);
        }

        public IProductsView GetView(Product product)
        {
            return views_[product];
        }

        public List<Product> GetCatalog(CatalogParams parameters)
        {
            return model_.GetCatalog(parameters);
        }

        public void SetVisibleProducts(IEnumerable<Product> products)
        {
            var matches = new HashSet<Product>(products);
            foreach (var card in views_)
            {
                card.Value.Visible = matches.Contains(card.Key);
            }
        }
    }
}
