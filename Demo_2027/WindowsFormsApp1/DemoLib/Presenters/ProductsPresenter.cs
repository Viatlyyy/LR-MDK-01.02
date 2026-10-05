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

        public void Update()
        {
            List<Product> allProducts = model_.Load();
            for (int i = 0; i < allProducts.Count; i++)
            {
                Product product = allProducts[i];
                IProductsView view = views_[i];

                view.Show(product);
            }
        }
    }
}
