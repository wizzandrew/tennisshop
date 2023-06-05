public interface IShopitemRepository
{
    public ShopArticles GetShopItems();
    public ShopArticles GetNewArrivals();
    public ShopArticles GetTopSellers();
}