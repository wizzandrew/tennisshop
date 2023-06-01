public class ShopitemRepository : IShopitemRepository {
    private readonly Context _context;

    public ShopitemRepository(Context context) {
        _context = context;
    }

    public ShopArticles GetShopItems() {
        List<Accessory> accessories = _context.Accessories.OrderBy(a => a.Id).ToList();
        List<Clothing> clothings = _context.Clothings.OrderBy(a => a.Id).ToList();
        List<Shoes> shoes = _context.Shoes.OrderBy(a => a.Id).ToList();
        List<Racket> rackets = _context.Rackets.OrderBy(a => a.Id).ToList();

        return new ShopArticles() {
            Accessories = accessories,
            Clothings = clothings,
            Shoes = shoes,
            Rackets = rackets
        };
    }

}