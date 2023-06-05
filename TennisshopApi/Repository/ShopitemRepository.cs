using Microsoft.EntityFrameworkCore;
public class ShopitemRepository : IShopitemRepository
{
    private readonly Context _context;

    public ShopitemRepository(Context context)
    {
        _context = context;
    }

    public ShopArticles GetShopItems()
    {
        List<Accessory> accessories = _context.Accessories.OrderBy(a => a.Id).ToList();
        List<Clothing> clothings = _context.Clothings.OrderBy(a => a.Id).ToList();
        List<Shoes> shoes = _context.Shoes.OrderBy(a => a.Id).ToList();
        List<Racket> rackets = _context.Rackets.OrderBy(a => a.Id).ToList();

        return new ShopArticles()
        {
            Accessories = accessories,
            Clothings = clothings,
            Shoes = shoes,
            Rackets = rackets
        };
    }

    public ShopArticles GetNewArrivals()
    {
        // get the latest list with new arrval articles
        var newArrival = _context.NewArrivals.Include(a => a.Items).OrderBy(a => a.Id).LastOrDefault();

        var accessories = new List<Accessory>();
        var clothings = new List<Clothing>();
        var shoes = new List<Shoes>();
        var rackets = new List<Racket>();

        if (newArrival != null)
        {

            // get accessory,clothings,shoes,rackets objects from new arrivals
            for (int i = 0; i < newArrival.Items.Count; i++)
            {
                var accessory = _context.Accessories.Where(a => a.Id == newArrival.Items.ElementAt(i).Id).FirstOrDefault();
                if (accessory != null)
                {
                    accessories.Add(accessory);
                    continue;
                }

                var clothing = _context.Clothings.Where(c => c.Id == newArrival.Items.ElementAt(i).Id).FirstOrDefault();
                if (clothing != null)
                {
                    clothings.Add(clothing);
                    continue;
                }

                var shoess = _context.Shoes.Where(s => s.Id == newArrival.Items.ElementAt(i).Id).FirstOrDefault();
                if (shoess != null)
                {
                    shoes.Add(shoess);
                    continue;
                }

                var racket = _context.Rackets.Where(r => r.Id == newArrival.Items.ElementAt(i).Id).FirstOrDefault();
                if (racket != null)
                {
                    rackets.Add(racket);
                }
            }

            // return result
            return new ShopArticles()
            {
                Accessories = accessories,
                Clothings = clothings,
                Shoes = shoes,
                Rackets = rackets
            };
        }

        return null;
    }

    public ShopArticles GetTopSellers()
    {
        // get the latest list with top seller articles
        var topSeller = _context.TopSellers.Include(s => s.Items).OrderBy(s => s.Id).LastOrDefault();

        var accessories = new List<Accessory>();
        var clothings = new List<Clothing>();
        var shoes = new List<Shoes>();
        var rackets = new List<Racket>();

        if (topSeller != null)
        {

            // get accessory,clothings,shoes,rackets objects from top sellers
            for (int i = 0; i < topSeller.Items.Count; i++)
            {
                var accessory = _context.Accessories.Where(a => a.Id == topSeller.Items.ElementAt(i).Id).FirstOrDefault();
                if (accessory != null)
                {
                    accessories.Add(accessory);
                    continue;
                }

                var clothing = _context.Clothings.Where(c => c.Id == topSeller.Items.ElementAt(i).Id).FirstOrDefault();
                if (clothing != null)
                {
                    clothings.Add(clothing);
                    continue;
                }

                var shoess = _context.Shoes.Where(s => s.Id == topSeller.Items.ElementAt(i).Id).FirstOrDefault();
                if (shoess != null)
                {
                    shoes.Add(shoess);
                    continue;
                }

                var racket = _context.Rackets.Where(r => r.Id == topSeller.Items.ElementAt(i).Id).FirstOrDefault();
                if (racket != null)
                {
                    rackets.Add(racket);
                }
            }

            // return result
            return new ShopArticles()
            {
                Accessories = accessories,
                Clothings = clothings,
                Shoes = shoes,
                Rackets = rackets
            };
        }

        return null;
    }

}