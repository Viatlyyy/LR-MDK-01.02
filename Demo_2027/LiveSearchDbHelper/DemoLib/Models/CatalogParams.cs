namespace DemoLib.Models
{
    public struct CatalogParams
    {
        public CatalogParams(string searchText, bool? ascending, string category = null)
        {
            SearchText = searchText;
            Ascending = ascending;
            Category = category;
        }

        public string SearchText { get; }
        public bool? Ascending { get; }
        public string Category { get; }
    }
}
