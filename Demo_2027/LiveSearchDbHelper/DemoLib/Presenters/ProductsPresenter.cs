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

        public List<Product> GetCatalog(string namePart, bool? ascending)
        {
            return model_.GetCatalog(namePart, ascending);
        }

        public void Filter(string namePart)
        {
            var matches = new HashSet<Product>(GetCatalog(namePart, null));
            foreach (var item in views_)
            {
                item.Value.Visible = matches.Contains(item.Key);
            }
        }
    }
}
