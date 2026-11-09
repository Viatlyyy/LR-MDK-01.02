namespace DemoLib.Views
{
    public interface IProductsView
    {
        bool Visible { get; set; }

        void Show(Product product);
    }
}
