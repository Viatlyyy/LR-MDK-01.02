using DemoLib.Models;
using DemoLib.Views;
using System;
using System.Collections.Generic;

namespace DemoLib.Presenters
{
    public class ProductsPresenter
    {
        private IProductsModel model_;
        private List<IProductsView> views_ = new List<IProductsView>();

        public ProductsPresenter(IProductsModel model)
        {
            model_ = model;
        }

        public void AddView(IProductsView view)
        {
            views_.Add(view);
        }

        public List<Product> GetCatalog(string namePart, bool? ascending)
        {
            return model_.GetCatalog(namePart, ascending);
        }

        public void Update(string namePart = null, bool? ascending = null)
        {
            List<Product> products = GetCatalog(namePart, ascending);
            for (int i = 0; i < views_.Count; i++)
            {
                IProductsView view = views_[i];
                if (i < products.Count)
                {
                    view.Show(products[i]);
                    view.Visible = true;
                }
                else
                {
                    view.Visible = false;
                }
            }
        }
    }
}
