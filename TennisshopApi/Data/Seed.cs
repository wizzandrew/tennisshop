public class Seed
{
    private readonly Context _context;
    public Seed(Context context)
    {
        _context = context;
    }

    public void SeedContext()
    {

        // accessories
        var accessories = GetAccessories();

        // clothings
        var clothings = GetClothings();

        // shoes
        var shoes = GetShoes();

        // rackets
        var rackets = GetRackets();

        // new arrivals
        NewArrivals newArrivals = new NewArrivals()
        {
            Items = new List<ShopItem>() {
                rackets[2],
                clothings.Where(c => c.Type == Enums.Shirt && c.Gender && c.Rating == 0).First(),
                clothings.Where(c => c.Type == Enums.Shirt && c.Gender == false && c.Rating == 0).First(),
                shoes.Where(c => c.Gender && c.Rating == 0).First(),
                shoes.Where(c => c.Gender == false && c.Rating == 0).First(),
                accessories.Where(c => c.Type == Enums.Bag && c.Rating == 0).First(),
                accessories.Where(c => c.Type == Enums.Balls && c.Rating == 0).First()
                }
        };


        // top sellers
        TopSeller topSeller = new TopSeller()
        {
            Items = new List<ShopItem>() {
                rackets.Where(r => r.Rating >= 4.7).First(),
                shoes.Where(s => s.Rating >= 4.7 && s.Brand == Enums.Adidas).First(),
                shoes.Where(s => s.Rating >= 4.7 && s.Brand == Enums.Nike).First(),
                clothings.Where(c => c.Type == Enums.Shirt && c.Brand == Enums.Adidas && c.Rating >= 4.7).First(),
                clothings.Where(c => c.Type == Enums.Shirt && c.Brand == Enums.Nike && c.Rating >= 4.7).First(),
                clothings.Where(c => c.Type == Enums.Shorts && c.Brand == Enums.Nike && c.Rating >= 4.7).First(),
                clothings.Where(c => c.Type == Enums.Shorts && c.Brand == Enums.Adidas && c.Rating >= 4.7).First(),
                accessories.Where(a => a.Rating >= 4.7).First()
             }
        };

        // address
        Address address = new Address()
        {
            Country = "Denmark",
            City = "Horsens",
            PostalCode = "8700",
            Street = "Borgergade 12",
            ApartmentNo = 15
        };

        // payment method
        PaymentMethod paymentMethod = new PaymentMethod()
        {
            Name = "MasterCard",
            Number = 5170253685781452,
            Valid = new DateTime(2025, 12, 31)
        };

        // user
        User user = new User()
        {
            Name = "Fernando de Silva",
            Email = "fernandosilva@gmail.com",
            Address = address,
            PaymentMethod = paymentMethod
        };

        // order
        Order order = new Order
        {
            OrderNo = "Ord235698",
            Date = new DateTime(2023, 3, 27),
            Total = 220,
            OrderStatus = "Delivered",
            Items = new List<OrderItem>() {
                new OrderItem() {
                    Item = rackets[0],
                    Quantity = 1
                },
                new OrderItem() {
                    Item = clothings[0],
                    Quantity = 1
                }
            },
            User = user
        };




        // add data to context
        _context.Accessories.AddRange(accessories);
        _context.Shoes.AddRange(shoes);
        _context.Clothings.AddRange(clothings);
        _context.Rackets.AddRange(rackets);
        _context.NewArrivals.Add(newArrivals);
        _context.TopSellers.Add(topSeller);
        _context.Addresses.Add(address);
        _context.PaymentMethods.Add(paymentMethod);
        _context.Orders.Add(order);
        _context.Users.Add(user);
        _context.SaveChanges();

    }

    private List<Accessory> GetAccessories()
    {

        var accessories = new List<Accessory>() {

            // bags
            new Accessory() {
            Name = "Tour Team 12R Monstercombi Tournament Bag Special Edition",
            Brand = Enums.Head,
            Price = 79.95,
            SalePrice = 64.95,
            Quantity = 10,
            Rating = 4.6,
            Popular = true,
            Type = Enums.Bag,
            Color = Enums.Grey,
            Size = Enums.Standard,
            Description = "You don't want just any bag, you want THE bag. With the HEAD Tour Team 12R Monstercombi in the Special Edition you have a bag that fulfills all your wishes. Up to twelve rackets fit into this bag, which is also used by professionals on the tour. Two main compartments are available to you, one of which is equipped with a special CCT+ technology to protect your equipment.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw15a9fce7/images/006/356/0236000000_000.jpg?q=80&sw=640"
            },

            new Accessory() {
            Name = "Tour Combi 6R Racket Bag Special Edition",
            Brand = Enums.Head,
            Price = 60,
            SalePrice = 0,
            Quantity = 10,
            Rating = 4.7,
            Popular = true,
            Type = Enums.Bag,
            Color = Enums.Black,
            Size = Enums.Standard,
            Description = "The Head bag collection is equipped with exactly the individual comfort that no player wants to do without today and leaves nothing to be desired in terms of versatility.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwa9942da5/images/006/340/0210300000_000.jpg?q=80&sw=640"
            },

            new Accessory() {
            Name = "Elite 9R Racket Bag 9 Pack",
            Brand = Enums.Head,
            Price = 75,
            SalePrice = 0,
            Quantity = 10,
            Rating = 4.5,
            Popular = false,
            Type = Enums.Bag,
            Color = Enums.Blue,
            Size = Enums.Standard,
            Description = "Refreshed with a new choice of modern colorways, the ELITE 9R SUPERCOMBI TENNIS BAG supplies modern style as well as lots of space, with room for up to 9 racquets. Along with two compartments, the bag has two front zipper pockets that give you quick and easy access to your smaller essentials such as your phone, keys and wallet. For extra flexibility when you are walking on to court or travelling to your weekend match, the 2-way carry system gives you the option of carrying the bag on your back or shoulder. As an illustration of how HEAD is trying to reduce plastic usage, the hangtag is made from recycled paper and tied with hemp cord.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw166ff02f/images/006/358/0243200000_000.jpg?q=80&sw=640"
            },

            new Accessory() {
            Name = "Roger Federer DNA Racket Bag 12 Pack",
            Brand = Enums.Wilson,
            Price = 170,
            SalePrice = 89.95,
            Quantity = 10,
            Rating = 4.7,
            Popular = true,
            Type = Enums.Bag,
            Color = Enums.Red,
            Size = Enums.Standard,
            Description = "With the Wilson Super Tour 3 Comp you get a bag that sets new standards. Two huge main compartments offer space for up to six rackets. But that's not all: You can also store shoes, clothing and accessories in the main compartments. Never again will you have to leave some of your equipment at home, because there is enough space in this bag.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw52f53893/images/007/350/0217300000_000.jpg?q=80&sw=640"
            },

            new Accessory() {
            Name = "Super Tour RG Racket Bag 9 Pack",
            Brand = Enums.Wilson,
            Price = 130,
            SalePrice = 0,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Type = Enums.Bag,
            Color = Enums.Blue,
            Size = Enums.Standard,
            Description = "Padded compartment with lockable zippers for up to 2 rackets. Additional compartment with padded laptop/tablet sleeve. Ventilated pocket for shoes or dirty clothes. Side zip pocket lined with Thermoguard to keep water or snacks cool. Side zip pocket for personal items. Adjustable chest strap for easy transport. Webbing loop for hanging.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw7a11ea16/images/007/362/0236200000_000.jpg?q=80&sw=640"
            },

            new Accessory() {
            Name = "Super Tour Racket Bag 9 Pack",
            Brand = Enums.Wilson,
            Price = 130,
            SalePrice = 0,
            Quantity = 10,
            Rating = 4.7,
            Popular = true,
            Type = Enums.Bag,
            Color = Enums.Black,
            Size = Enums.Standard,
            Description = "Marrying a design that pays tribute to the iconic Pro Staff franchise with top-tier functional performance, the Super Tour Pro Staff Collection is designed for tennis purists worldwide. This Pro Staff 9 Pack houses up to nine rackets in two primary compartments, one of which is lined with Thermoguard to protect contents from extreme heat. Additional features include a pair of large exterior side pockets, a dual carrying system for optimal transportation and reinforced side panels that help prevent fabric from ripping at the seams.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw6664521b/images/007/351/0219900000_000.jpg?q=80&sw=640"
            },

            new Accessory() {
            Name = "Pro Racquet Bag Racket Bag 9 Pack",
            Brand = Enums.Yonex,
            Price = 140,
            SalePrice = 100,
            Quantity = 10,
            Rating = 5.0,
            Popular = true,
            Type = Enums.Bag,
            Color = Enums.Black,
            Size = Enums.Standard,
            Description = "Thermobag with a capacity of up to 10 rackets.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw1cb64527/images/019/358/0152100000_000.jpg?q=80&sw=640"
            },

            new Accessory() {
            Name = "Pro Racquet Bag Racket Bag 8er",
            Brand = Enums.Yonex,
            Price = 115,
            SalePrice = 80,
            Quantity = 10,
            Rating = 3.0,
            Popular = false,
            Type = Enums.Bag,
            Color = Enums.Red,
            Size = Enums.Standard,
            Description = "Thermobag with a capacity of up to 8 rackets.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw73ebb8bf/images/019/362/0155600000_000.jpg?q=80&sw=640"
            },

            new Accessory() {
            Name = "Pro Racquet Bag Racket Bag 9 Pack",
            Brand = Enums.Yonex,
            Price = 140,
            SalePrice = 100,
            Quantity = 10,
            Rating = 5.0,
            Popular = true,
            Type = Enums.Bag,
            Color = Enums.Blue,
            Size = Enums.Standard,
            Description = "Thermobag with a capacity of up to 10 rackets.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw5d8bf38d/images/019/358/0152300000_000.jpg?q=80&sw=640"
            },

            // balls
            new Accessory() {
            Name = "Triniti 3er 3 Ball Tube",
            Brand = Enums.Wilson,
            Price = 8,
            SalePrice = 0,
            Quantity = 100,
            Rating = 4.3,
            Popular = true,
            Type = Enums.Balls,
            Color = Enums.Yellow,
            Size = Enums.Standard,
            Description = "The first performance tennis ball designed with 100% recyclable packaging, Triniti pushes the limits of sustainable performance. Featuring a unique octagonal paper container, the Triniti sleeve is fully recyclable after use. The ball core comprises a unique plastomer material that impressively extends ball liveliness, while STR Felt is 50% more flexible than the standard ball for more core compression and longer dwell times. Between a combination of innovative ball technology and unique sustainable packaging, Triniti ushers in a new era for performance tennis balls both on and off the court.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw559f7fd4/images/007/248/0163100000_000.jpg?q=80&sw=640"
            },

            new Accessory() {
            Name = "Roland Garros Official 4 Ball Tube",
            Brand = Enums.Wilson,
            Price = 11,
            SalePrice = 0,
            Quantity = 100,
            Rating = 4.2,
            Popular = false,
            Type = Enums.Balls,
            Color = Enums.Yellow,
            Size = Enums.Standard,
            Description = "Taking center court on the red clay at Roland-Garros, the Wilson Roland Garros tennis ball continues the brand's rich tradition of high performance tennis balls on the biggest stages in the sport. Boasting a core designed for longer rallies and a felt that limits moisture and dirt pick-up for peak consistency during grueling points, the Wilson Roland Garros ball produces performance fit for the zenith of the clay court season.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwae54f75c/images/007/250/0162200000_000.jpg?q=80&sw=640"
            },

            new Accessory() {
            Name = "US Open 4 Ball Tube",
            Brand = Enums.Wilson,
            Price = 10,
            SalePrice = 0,
            Quantity = 100,
            Rating = 4.5,
            Popular = true,
            Type = Enums.Balls,
            Color = Enums.Yellow,
            Size = Enums.Standard,
            Description = "This tennis ball is ideal for any tennis match. The US Open has been the ideal ball for demanding Grand Slam tournaments since 1978, which speaks for itself regarding excellent quality. The tennis ball is equipped with a thick felt assuring a high level of resilience and perfect playing characteristics.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw6505ba6d/images/007/226/0153700000_000.jpg?q=80&sw=640"
            },


            new Accessory() {
            Name = "Tour 4 Ball Tube",
            Brand = Enums.Head,
            Price = 12,
            SalePrice = 10.5,
            Quantity = 100,
            Rating = 4.7,
            Popular = true,
            Type = Enums.Balls,
            Color = Enums.Yellow,
            Size = Enums.Standard,
            Description = "The HEAD Tour was designed by ATP professional players to give you the perfect mix of spin and control. Even hard serves and aggressive topspins can be played precisely and controlled with the HEAD Tour. The bounce of this sturdy ball remains longer thanks to Encore technology - for a feel like the first day. The SmartOptik felt also ensures that you never lose sight of the ball, no matter on which surface you play.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw07e9caf8/images/006/246/0151600000_000.jpg?q=80&sw=640"
            },

            new Accessory() {
            Name = "Pro 4 Ball Tube",
            Brand = Enums.Head,
            Price = 11,
            SalePrice = 0,
            Quantity = 100,
            Rating = 4.2,
            Popular = false,
            Type = Enums.Balls,
            Color = Enums.Yellow,
            Size = Enums.Standard,
            Description = "The HEAD Pro has already proven itself on numerous ATP tournaments. It is extremely durable and features awesome bounce properties thanks to the innovative Encore technology. While playing, you will keep the upper hand, because the unique rubber compound gives you excellent playing characteristics and the SmartOptik felt ensures that you always have the ball in view.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw6e6c83db/images/006/238/0147900000_000.jpg?q=80&sw=640"
            },

            new Accessory() {
            Name = "Pro Coach 4 Ball Tube",
            Brand = Enums.Head,
            Price = 7,
            SalePrice = 0,
            Quantity = 100,
            Rating = 4.3,
            Popular = false,
            Type = Enums.Balls,
            Color = Enums.Yellow,
            Size = Enums.Standard,
            Description = "Players around the world appreciate the playing features of the Head Pro ball. The Pro Coach is the even shorter training version. The innovative Encore technology distinguishes this ball. Longevity and lasting good bouncing properties are the result. With the Head Pro Coach you can train excellently and reach your next goals guaranteed!",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw3d35cf8c/images/006/238/0149100000_000.jpg?q=80&sw=640"
            },


            new Accessory() {
            Name = "Fort All Court 4 Ball Tube",
            Brand = Enums.Dunlop,
            Price = 9,
            SalePrice = 0,
            Quantity = 100,
            Rating = 4.8,
            Popular = true,
            Type = Enums.Balls,
            Color = Enums.Yellow,
            Size = Enums.Standard,
            Description = "This iconic, much-loved Dunlop premium tennis ball is ideal for elite tournament and club play on all surfaces, thanks to it's consistent and durable construction.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw380cdb1e/images/016/246/0162400000_000.jpg?q=80&sw=2000"
            },

            new Accessory() {
            Name = "Fort Tournament 4 Ball Tube",
            Brand = Enums.Dunlop,
            Price = 14,
            SalePrice = 0,
            Quantity = 100,
            Rating = 4.5,
            Popular = false,
            Type = Enums.Balls,
            Color = Enums.Yellow,
            Size = Enums.Standard,
            Description = "Get a super-premium feel. This super-premium ball features superior pressure retention for enhanced durability. All of this combines to make it the number one ball in Germany.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw13fb6683/images/016/246/0162200000_000.jpg?q=80&sw=640"
            },

            new Accessory() {
            Name = "Dunlop Trainer VDT 4 Ball Tube",
            Brand = Enums.Dunlop,
            Price = 9,
            SalePrice = 0,
            Quantity = 100,
            Rating = 0,
            Popular = false,
            Type = Enums.Balls,
            Color = Enums.Yellow,
            Size = Enums.Standard,
            Description = "With the new Dunlop BTV 1.0, you can now play a uniform ball, because the BTV 1.0 will be used throughout the Bavarian Tennis Association. The ball shines with its long durability and robust workmanship.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwc816d326/images/016/262/0171100000_000.jpg?q=80&sw=640"
            },

            //strings

            // strings head
            new Accessory() {
            Name = "Velocity MLT String Reel 200m",
            Brand = Enums.Head,
            Price = 90,
            SalePrice = 0,
            Quantity = 10,
            Rating = 4.2,
            Popular = false,
            Type = Enums.Strings,
            Color = Enums.Yellow,
            Size = Enums.String120,
            Description = "The HEAD Velocity MLT has a multi-filament core surrounded by thicker fibres. This increases energy efficiency and gives you even more power than other multi-filament strings. The low-friction coating also ensures a high spin potential. Look forward to a lively match that lasts for a long time.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwae669216/images/006/554/02325000_000.jpg?q=80&sw=640"
            },
            new Accessory() {
            Name = "Velocity MLT String Reel 200m",
            Brand = Enums.Head,
            Price = 90,
            SalePrice = 0,
            Quantity = 10,
            Rating = 4.2,
            Popular = false,
            Type = Enums.Strings,
            Color = Enums.Yellow,
            Size = Enums.String125,
            Description = "The HEAD Velocity MLT has a multi-filament core surrounded by thicker fibres. This increases energy efficiency and gives you even more power than other multi-filament strings. The low-friction coating also ensures a high spin potential. Look forward to a lively match that lasts for a long time.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwae669216/images/006/554/02325000_000.jpg?q=80&sw=640"
            },
            new Accessory() {
            Name = "Velocity MLT String Reel 200m",
            Brand = Enums.Head,
            Price = 90,
            SalePrice = 0,
            Quantity = 10,
            Rating = 4.2,
            Popular = false,
            Type = Enums.Strings,
            Color = Enums.Yellow,
            Size = Enums.String130,
            Description = "The HEAD Velocity MLT has a multi-filament core surrounded by thicker fibres. This increases energy efficiency and gives you even more power than other multi-filament strings. The low-friction coating also ensures a high spin potential. Look forward to a lively match that lasts for a long time.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwae669216/images/006/554/02325000_000.jpg?q=80&sw=640"
            },


            new Accessory() {
            Name = "Sonic Pro String Reel 200m",
            Brand = Enums.Head,
            Price = 100,
            SalePrice = 70,
            Quantity = 10,
            Rating = 4.7,
            Popular = true,
            Type = Enums.Strings,
            Color = Enums.Black,
            Size = Enums.String130,
            Description = "You are looking for strings for weekly training and weekend matches? The HEAD Sonic Pro strings are durable and help you to control your game. You can expect a pleasant feeling thanks to unique copolymer-polyester with a soft molecular structure. In addition, the mono-filament strings provide you with extra power.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwa1cc1979/images/006/500/02204000_000.jpg?q=80&sw=640"
            },
            new Accessory() {
            Name = "Sonic Pro String Reel 200m",
            Brand = Enums.Head,
            Price = 100,
            SalePrice = 70,
            Quantity = 10,
            Rating = 4.7,
            Popular = true,
            Type = Enums.Strings,
            Color = Enums.Black,
            Size = Enums.String125,
            Description = "You are looking for strings for weekly training and weekend matches? The HEAD Sonic Pro strings are durable and help you to control your game. You can expect a pleasant feeling thanks to unique copolymer-polyester with a soft molecular structure. In addition, the mono-filament strings provide you with extra power.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwa1cc1979/images/006/500/02204000_000.jpg?q=80&sw=640"
            },


            new Accessory() {
            Name = "Sonic Pro String Reel 200m",
            Brand = Enums.Head,
            Price = 100,
            SalePrice = 75,
            Quantity = 10,
            Rating = 4.8,
            Popular = true,
            Type = Enums.Strings,
            Color = Enums.White,
            Size = Enums.String125,
            Description = "You are looking for strings for weekly training and weekend matches? The HEAD Sonic Pro strings are durable and help you to control your game. You can expect a pleasant feeling thanks to unique copolymer-polyester with a soft molecular structure. In addition, the mono-filament strings provide you with extra power.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwd335e167/images/006/500/02112000_000.jpg?q=80&sw=640"
            },
            new Accessory() {
            Name = "Sonic Pro String Reel 200m",
            Brand = Enums.Head,
            Price = 100,
            SalePrice = 75,
            Quantity = 10,
            Rating = 4.8,
            Popular = true,
            Type = Enums.Strings,
            Color = Enums.White,
            Size = Enums.String130,
            Description = "You are looking for strings for weekly training and weekend matches? The HEAD Sonic Pro strings are durable and help you to control your game. You can expect a pleasant feeling thanks to unique copolymer-polyester with a soft molecular structure. In addition, the mono-filament strings provide you with extra power.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwd335e167/images/006/500/02112000_000.jpg?q=80&sw=640"
            },

            // strings tecnifibre
            new Accessory() {
            Name = "Razor Soft 200m String Reel",
            Brand = Enums.Tecnifibre,
            Price = 200,
            SalePrice = 130,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Type = Enums.Strings,
            Color = Enums.Grey,
            Size = Enums.String130,
            Description = "For players who seek precision and comfort. Thanks to the use of high modulus co-polyester, Tecnifibre offers players the opportunity to enhance control. The RAZOR SOFT string offers 2 main advantages: precision for maximum performance and comfort for most people.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwb2b1cf87/images/012/562/01892000_000.jpg?q=80&sw=640"
            },
            new Accessory() {
            Name = "Razor Soft 200m String Reel",
            Brand = Enums.Tecnifibre,
            Price = 200,
            SalePrice = 130,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Type = Enums.Strings,
            Color = Enums.Grey,
            Size = Enums.String125,
            Description = "For players who seek precision and comfort. Thanks to the use of high modulus co-polyester, Tecnifibre offers players the opportunity to enhance control. The RAZOR SOFT string offers 2 main advantages: precision for maximum performance and comfort for most people.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwb2b1cf87/images/012/562/01892000_000.jpg?q=80&sw=640"
            },

            new Accessory() {
            Name = "Duramix HD 200m String Reel",
            Brand = Enums.Tecnifibre,
            Price = 270,
            SalePrice = 230,
            Quantity = 10,
            Rating = 5.0,
            Popular = true,
            Type = Enums.Strings,
            Color = Enums.White,
            Size = Enums.String125,
            Description = "Mulitilament string composed of both polyester and polyamide fibres, surrounded by PU HD (a PU resin with limited elasiticity). This blend allows for a better durability, a firm feeling and excellent resistance.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwe9f634eb/images/012/548/01874000_000.jpg?q=80&sw=640"
            },
            new Accessory() {
            Name = "Duramix HD 200m String Reel",
            Brand = Enums.Tecnifibre,
            Price = 270,
            SalePrice = 230,
            Quantity = 10,
            Rating = 5.0,
            Popular = true,
            Type = Enums.Strings,
            Color = Enums.White,
            Size = Enums.String120,
            Description = "Mulitilament string composed of both polyester and polyamide fibres, surrounded by PU HD (a PU resin with limited elasiticity). This blend allows for a better durability, a firm feeling and excellent resistance.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwe9f634eb/images/012/548/01874000_000.jpg?q=80&sw=640"
            },
            new Accessory() {
            Name = "Duramix HD 200m String Reel",
            Brand = Enums.Tecnifibre,
            Price = 270,
            SalePrice = 230,
            Quantity = 10,
            Rating = 5.0,
            Popular = true,
            Type = Enums.Strings,
            Color = Enums.White,
            Size = Enums.String130,
            Description = "Mulitilament string composed of both polyester and polyamide fibres, surrounded by PU HD (a PU resin with limited elasiticity). This blend allows for a better durability, a firm feeling and excellent resistance.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwe9f634eb/images/012/548/01874000_000.jpg?q=80&sw=640"
            },

            // strings wilson
            new Accessory() {
            Name = "Poly Pro String Reel 200m",
            Brand = Enums.Wilson,
            Price = 85,
            SalePrice = 75,
            Quantity = 10,
            Rating = 4.8,
            Popular = true,
            Type = Enums.Strings,
            Color = Enums.Grey,
            Size = Enums.String130,
            Description = "The Poly Pro from Wilson is a typical polyester string with which control and solid strength development can be achieved. It assures a constant long lasting crisp playing feeling because the Poly Pro stands out for good durability. A good remedy for players who are hard on strings.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw2068e99b/images/007/530/02004000_000.jpg?q=80&sw=640"
            },
            new Accessory() {
            Name = "Poly Pro String Reel 200m",
            Brand = Enums.Wilson,
            Price = 85,
            SalePrice = 75,
            Quantity = 10,
            Rating = 4.8,
            Popular = true,
            Type = Enums.Strings,
            Color = Enums.Grey,
            Size = Enums.String125,
            Description = "The Poly Pro from Wilson is a typical polyester string with which control and solid strength development can be achieved. It assures a constant long lasting crisp playing feeling because the Poly Pro stands out for good durability. A good remedy for players who are hard on strings.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw2068e99b/images/007/530/02004000_000.jpg?q=80&sw=640"
            },


            new Accessory() {
            Name = "Revolve String Reel 200m - White",
            Brand = Enums.Wilson,
            Price = 155,
            SalePrice = 0,
            Quantity = 10,
            Rating = 4.9,
            Popular = true,
            Type = Enums.Strings,
            Color = Enums.White,
            Size = Enums.String125,
            Description = "The Wilson Revolve has been constructed with interwoven Esterpolymer and UHM In this way the return snap of the strings assures that optimal spin power is transferred to the ball. This string movement assists balls played with twist to be more comfortably played. Simultaneously this string offers a high level of stability and perfect user comfort. Whoever anyway relies on the quality of a Wilson Spin racket can improve their spin performance even more by using this string.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw23a00b86/images/007/530/02002000_000.jpg?q=80&sw=640"
            },
            new Accessory() {
            Name = "Revolve String Reel 200m - White",
            Brand = Enums.Wilson,
            Price = 155,
            SalePrice = 0,
            Quantity = 10,
            Rating = 4.9,
            Popular = true,
            Type = Enums.Strings,
            Color = Enums.White,
            Size = Enums.String130,
            Description = "The Wilson Revolve has been constructed with interwoven Esterpolymer and UHM In this way the return snap of the strings assures that optimal spin power is transferred to the ball. This string movement assists balls played with twist to be more comfortably played. Simultaneously this string offers a high level of stability and perfect user comfort. Whoever anyway relies on the quality of a Wilson Spin racket can improve their spin performance even more by using this string.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw23a00b86/images/007/530/02002000_000.jpg?q=80&sw=640"
            },


            new Accessory() {
            Name = "Sensation Plus String Reel 200m - Black",
            Brand = Enums.Wilson,
            Price = 100,
            SalePrice = 0,
            Quantity = 10,
            Rating = 4.0,
            Popular = false,
            Type = Enums.Strings,
            Color = Enums.Black,
            Size = Enums.String130,
            Description = "Sensation Plus takes the highly elastic nylon fibers present in Sensation and wraps them in metallic ribbons for elevated comfort and durability. Available in two gauges and colors to suit a variety of player interests, this string is a great value option for beginner or intermediate players who would prefer not to break the bank.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwf1e6922c/images/007/546/02019000_000.jpg?q=80&sw=640"
            },
            new Accessory() {
            Name = "Sensation Plus String Reel 200m - Black",
            Brand = Enums.Wilson,
            Price = 100,
            SalePrice = 0,
            Quantity = 10,
            Rating = 4.0,
            Popular = false,
            Type = Enums.Strings,
            Color = Enums.Black,
            Size = Enums.String125,
            Description = "Sensation Plus takes the highly elastic nylon fibers present in Sensation and wraps them in metallic ribbons for elevated comfort and durability. Available in two gauges and colors to suit a variety of player interests, this string is a great value option for beginner or intermediate players who would prefer not to break the bank.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwf1e6922c/images/007/546/02019000_000.jpg?q=80&sw=640"
            },



        };

        return accessories;

    }

    private List<Clothing> GetClothings()
    {
        var clothings = new List<Clothing>() {

            // hoodies

            // under armour hoodies
            new Clothing()
            {
            Name = "Rival Fleece Big Logo Hoody Men",
            Brand = Enums.UnderArmour,
            Price = 50,
            SalePrice = 0,
            Quantity = 10,
            Rating = 5.0,
            Popular = true,
            Type = Enums.Hoodie,
            Gender = true,
            Color = Enums.Green,
            Size = Enums.Small,
            Description = "Experience unbeatable comfort and style with the Under Armour Hoody. Designed for men who value both fashion and functionality, this hoody combines a sleek and modern aesthetic with the renowned performance of Under Armour. Crafted with high-quality materials, it offers a cozy and comfortable fit that's perfect for everyday wear. With its versatile design and attention to detail, this Under Armour hoody is a timeless addition to your wardrobe, providing a reliable and stylish option for any occasion. Whether you're heading to the gym, running errands, or simply relaxing, this hoody has got you covered with its combination of comfort, durability, and athletic appeal.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw24fafe6a/images/022/460/08180000_000.jpg?q=80&sw=640"
            },

            new Clothing()
            {
            Name = "Essential Hoody Men",
            Brand = Enums.UnderArmour,
            Price = 60,
            SalePrice = 0,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Type = Enums.Hoodie,
            Gender = true,
            Color = Enums.Grey,
            Size = Enums.Medium,
            Description = "Experience unbeatable comfort and style with the Under Armour Hoody. Designed for men who value both fashion and functionality, this hoody combines a sleek and modern aesthetic with the renowned performance of Under Armour. Crafted with high-quality materials, it offers a cozy and comfortable fit that's perfect for everyday wear. With its versatile design and attention to detail, this Under Armour hoody is a timeless addition to your wardrobe, providing a reliable and stylish option for any occasion. Whether you're heading to the gym, running errands, or simply relaxing, this hoody has got you covered with its combination of comfort, durability, and athletic appeal.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw069064e2/images/022/462/09606000_000.jpg?q=80&sw=640"
            },

            new Clothing()
            {
            Name = "Rival Fleece Big Logo Hoody Men",
            Brand = Enums.UnderArmour,
            Price = 60,
            SalePrice = 50,
            Quantity = 10,
            Rating = 5.0,
            Popular = true,
            Type = Enums.Hoodie,
            Gender = true,
            Color = Enums.Yellow,
            Size = Enums.Small,
            Description = "Experience unbeatable comfort and style with the Under Armour Hoody. Designed for men who value both fashion and functionality, this hoody combines a sleek and modern aesthetic with the renowned performance of Under Armour. Crafted with high-quality materials, it offers a cozy and comfortable fit that's perfect for everyday wear. With its versatile design and attention to detail, this Under Armour hoody is a timeless addition to your wardrobe, providing a reliable and stylish option for any occasion. Whether you're heading to the gym, running errands, or simply relaxing, this hoody has got you covered with its combination of comfort, durability, and athletic appeal.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwbbb90440/images/022/460/08183000_000.jpg?q=80&sw=640"
            },


            new Clothing()
            {
            Name = "Rival Terry Hoody Women",
            Brand = Enums.UnderArmour,
            Price = 50,
            SalePrice = 0,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Type = Enums.Hoodie,
            Gender = false,
            Color = Enums.Red,
            Size = Enums.Small,
            Description = "Experience unbeatable comfort and style with the Under Armour Hoody. Designed for women who value both fashion and functionality, this hoody combines a sleek and modern aesthetic with the renowned performance of Under Armour. Crafted with high-quality materials, it offers a cozy and comfortable fit that's perfect for everyday wear. With its versatile design and attention to detail, this Under Armour hoody is a timeless addition to your wardrobe, providing a reliable and stylish option for any occasion. Whether you're heading to the gym, running errands, or simply relaxing, this hoody has got you covered with its combination of comfort, durability, and athletic appeal.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw60d2bf5b/images/022/462/09605000_000.jpg?q=80&sw=640"
            },


            new Clothing()
            {
            Name = "Rival Logo Hoody Women",
            Brand = Enums.UnderArmour,
            Price = 55,
            SalePrice = 0,
            Quantity = 10,
            Rating = 4.7,
            Popular = true,
            Type = Enums.Hoodie,
            Gender = false,
            Color = Enums.Blue,
            Size = Enums.Small,
            Description = "Experience unbeatable comfort and style with the Under Armour Hoody. Designed for men who value both fashion and functionality, this hoody combines a sleek and modern aesthetic with the renowned performance of Under Armour. Crafted with high-quality materials, it offers a cozy and comfortable fit that's perfect for everyday wear. With its versatile design and attention to detail, this Under Armour hoody is a timeless addition to your wardrobe, providing a reliable and stylish option for any occasion. Whether you're heading to the gym, running errands, or simply relaxing, this hoody has got you covered with its combination of comfort, durability, and athletic appeal.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw23ac9403/images/022/462/08495000_000.jpg?q=80&sw=640"
            },

            // nike hoodies
            new Clothing()
            {
            Name = "Dri-Fit Heritage Slim Hoody Men",
            Brand = Enums.Nike,
            Price = 75,
            SalePrice = 60,
            Quantity = 10,
            Rating = 4.6,
            Popular = true,
            Type = Enums.Hoodie,
            Gender = true,
            Color = Enums.Black,
            Size = Enums.Medium,
            Description = "Experience the epitome of sporty style and unbeatable comfort with the Nike Hoody. Designed to elevate your casual wardrobe, this iconic hoody combines the classic Nike aesthetic with superior craftsmanship. Crafted with premium materials, it offers a soft and cozy feel, ensuring all-day comfort. The signature Nike logo adds a touch of authenticity, while the adjustable hood and kangaroo pocket provide both functionality and style. Whether you're hitting the gym, going for a run, or simply lounging around, this Nike hoody is the perfect choice for those who seek a perfect blend of fashion and performance. Embrace the legacy of Nike and make a statement with this must-have hoody.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw265ef1dd/images/004/457/54778000_000.jpg?q=80&sw=640"
            },

            new Clothing()
            {
            Name = "Dri-Fit Court Heritage Hoody Men",
            Brand = Enums.Nike,
            Price = 75,
            SalePrice = 65,
            Quantity = 10,
            Rating = 4.7,
            Popular = true,
            Type = Enums.Hoodie,
            Gender = true,
            Color = Enums.Yellow,
            Size = Enums.Medium,
            Description = "Experience the epitome of sporty style and unbeatable comfort with the Nike Hoody. Designed to elevate your casual wardrobe, this iconic hoody combines the classic Nike aesthetic with superior craftsmanship. Crafted with premium materials, it offers a soft and cozy feel, ensuring all-day comfort. The signature Nike logo adds a touch of authenticity, while the adjustable hood and kangaroo pocket provide both functionality and style. Whether you're hitting the gym, going for a run, or simply lounging around, this Nike hoody is the perfect choice for those who seek a perfect blend of fashion and performance. Embrace the legacy of Nike and make a statement with this must-have hoody.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwc0fd6391/images/004/462/56753000_000.jpg?q=80&sw=640"
            },


            new Clothing()
            {
            Name = "Dri-Fit Heritage Fleece Hoody Women",
            Brand = Enums.Nike,
            Price = 75,
            SalePrice = 65,
            Quantity = 10,
            Rating = 4.7,
            Popular = true,
            Type = Enums.Hoodie,
            Gender = false,
            Color = Enums.White,
            Size = Enums.Medium,
            Description = "Experience the epitome of sporty style and unbeatable comfort with the Nike Hoody. Designed to elevate your casual wardrobe, this iconic hoody combines the classic Nike aesthetic with superior craftsmanship. Crafted with premium materials, it offers a soft and cozy feel, ensuring all-day comfort. The signature Nike logo adds a touch of authenticity, while the adjustable hood and kangaroo pocket provide both functionality and style. Whether you're hitting the gym, going for a run, or simply lounging around, this Nike hoody is the perfect choice for those who seek a perfect blend of fashion and performance. Embrace the legacy of Nike and make a statement with this must-have hoody.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw80550083/images/004/457/54605000_000.jpg?q=80&sw=640"
            },

            new Clothing()
            {
            Name = "Dri-Fit Heritage Fleece Hoody Women",
            Brand = Enums.Nike,
            Price = 75,
            SalePrice = 65,
            Quantity = 10,
            Rating = 4.7,
            Popular = true,
            Type = Enums.Hoodie,
            Gender = false,
            Color = Enums.Blue,
            Size = Enums.Small,
            Description = "Experience the epitome of sporty style and unbeatable comfort with the Nike Hoody. Designed to elevate your casual wardrobe, this iconic hoody combines the classic Nike aesthetic with superior craftsmanship. Crafted with premium materials, it offers a soft and cozy feel, ensuring all-day comfort. The signature Nike logo adds a touch of authenticity, while the adjustable hood and kangaroo pocket provide both functionality and style. Whether you're hitting the gym, going for a run, or simply lounging around, this Nike hoody is the perfect choice for those who seek a perfect blend of fashion and performance. Embrace the legacy of Nike and make a statement with this must-have hoody.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw23e9e642/images/004/462/56608000_000.jpg?q=80&sw=640"
            },


            new Clothing()
            {
            Name = "Dri-Fit Heritage Fleece Hoody Women",
            Brand = Enums.Nike,
            Price = 75,
            SalePrice = 65,
            Quantity = 10,
            Rating = 4.7,
            Popular = true,
            Type = Enums.Hoodie,
            Gender = false,
            Color = Enums.Red,
            Size = Enums.Small,
            Description = "Experience the epitome of sporty style and unbeatable comfort with the Nike Hoody. Designed to elevate your casual wardrobe, this iconic hoody combines the classic Nike aesthetic with superior craftsmanship. Crafted with premium materials, it offers a soft and cozy feel, ensuring all-day comfort. The signature Nike logo adds a touch of authenticity, while the adjustable hood and kangaroo pocket provide both functionality and style. Whether you're hitting the gym, going for a run, or simply lounging around, this Nike hoody is the perfect choice for those who seek a perfect blend of fashion and performance. Embrace the legacy of Nike and make a statement with this must-have hoody.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw2d25c9ef/images/004/463/57032000_000.jpg?q=80&sw=2000"
            },

            //adidas hoodies
            new Clothing()
            {
            Name = "3-Stripes French Terry Hoody Men",
            Brand = Enums.Adidas,
            Price = 50,
            SalePrice = 0,
            Quantity = 10,
            Rating = 4.0,
            Popular = false,
            Type = Enums.Hoodie,
            Gender = true,
            Color = Enums.Black,
            Size = Enums.Large,
            Description = "Step up your streetwear game with the Adidas Hoody. A perfect blend of style and functionality, this iconic hoody showcases the timeless Adidas design and superior craftsmanship. Crafted with premium materials, it offers a comfortable and cozy fit, making it ideal for everyday wear. The Adidas logo adds a touch of authenticity and street cred, while the adjustable hood and kangaroo pocket provide practicality and convenience. Whether you're hitting the gym, running errands, or hanging out with friends, this Adidas hoody is a versatile choice that effortlessly combines fashion and performance. Embrace the sporty-chic vibe and make a bold statement with this essential piece of Adidas apparel.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwdc57927c/images/005/456/15724000_000.jpg?q=80&sw=640"
            },


            new Clothing()
            {
            Name = "Future Icon Badge Of Sport Hoody Men",
            Brand = Enums.Adidas,
            Price = 60,
            SalePrice = 0,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Type = Enums.Hoodie,
            Gender = true,
            Color = Enums.White,
            Size = Enums.Small,
            Description = "Step up your streetwear game with the Adidas Hoody. A perfect blend of style and functionality, this iconic hoody showcases the timeless Adidas design and superior craftsmanship. Crafted with premium materials, it offers a comfortable and cozy fit, making it ideal for everyday wear. The Adidas logo adds a touch of authenticity and street cred, while the adjustable hood and kangaroo pocket provide practicality and convenience. Whether you're hitting the gym, running errands, or hanging out with friends, this Adidas hoody is a versatile choice that effortlessly combines fashion and performance. Embrace the sporty-chic vibe and make a bold statement with this essential piece of Adidas apparel.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwadb23460/images/005/464/18346000_000.jpg?q=80&sw=640"
            },


            new Clothing()
            {
            Name = "Essentials Linear Hoody Women",
            Brand = Enums.Adidas,
            Price = 55,
            SalePrice = 0,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Type = Enums.Hoodie,
            Gender = false,
            Color = Enums.Black,
            Size = Enums.Medium,
            Description = "Step up your streetwear game with the Adidas Hoody. A perfect blend of style and functionality, this iconic hoody showcases the timeless Adidas design and superior craftsmanship. Crafted with premium materials, it offers a comfortable and cozy fit, making it ideal for everyday wear. The Adidas logo adds a touch of authenticity and street cred, while the adjustable hood and kangaroo pocket provide practicality and convenience. Whether you're hitting the gym, running errands, or hanging out with friends, this Adidas hoody is a versatile choice that effortlessly combines fashion and performance. Embrace the sporty-chic vibe and make a bold statement with this essential piece of Adidas apparel.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw50515dc3/images/005/462/17759000_000.jpg?q=80&sw=640"
            },


            new Clothing()
            {
            Name = "Essentials Linear Hoody Women",
            Brand = Enums.Adidas,
            Price = 55,
            SalePrice = 0,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Type = Enums.Hoodie,
            Gender = false,
            Color = Enums.Grey,
            Size = Enums.Small,
            Description = "Step up your streetwear game with the Adidas Hoody. A perfect blend of style and functionality, this iconic hoody showcases the timeless Adidas design and superior craftsmanship. Crafted with premium materials, it offers a comfortable and cozy fit, making it ideal for everyday wear. The Adidas logo adds a touch of authenticity and street cred, while the adjustable hood and kangaroo pocket provide practicality and convenience. Whether you're hitting the gym, running errands, or hanging out with friends, this Adidas hoody is a versatile choice that effortlessly combines fashion and performance. Embrace the sporty-chic vibe and make a bold statement with this essential piece of Adidas apparel.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw5f631074/images/005/462/17765000_000.jpg?q=80&sw=640"
            },


            new Clothing()
            {
            Name = "Essentials Linear Hoody Women",
            Brand = Enums.Adidas,
            Price = 55,
            SalePrice = 0,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Type = Enums.Hoodie,
            Gender = false,
            Color = Enums.Blue,
            Size = Enums.Small,
            Description = "Step up your streetwear game with the Adidas Hoody. A perfect blend of style and functionality, this iconic hoody showcases the timeless Adidas design and superior craftsmanship. Crafted with premium materials, it offers a comfortable and cozy fit, making it ideal for everyday wear. The Adidas logo adds a touch of authenticity and street cred, while the adjustable hood and kangaroo pocket provide practicality and convenience. Whether you're hitting the gym, running errands, or hanging out with friends, this Adidas hoody is a versatile choice that effortlessly combines fashion and performance. Embrace the sporty-chic vibe and make a bold statement with this essential piece of Adidas apparel.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw7777e68d/images/005/462/17767000_000.jpg?q=80&sw=640"
            },

            //under armour pants
            new Clothing()
            {
            Name = "Rival Training Pants Men",
            Brand = Enums.UnderArmour,
            Price = 60,
            SalePrice = 0,
            Quantity = 10,
            Rating = 4.4,
            Popular = false,
            Type = Enums.Pants,
            Gender = true,
            Color = Enums.Black,
            Size = Enums.Medium,
            Description = "Elevate your athletic wardrobe with Under Armour Pants, a perfect fusion of style and performance. Designed with the modern athlete in mind, these pants offer exceptional comfort and functionality. Crafted with high-quality materials, they provide a soft and flexible fit that allows for unrestricted movement during workouts or everyday activities. The signature Under Armour logo adds a touch of authenticity, while the innovative moisture-wicking technology keeps you dry and comfortable throughout your training sessions. Whether you're hitting the gym, going for a jog, or simply running errands, Under Armour Pants deliver the perfect combination of style and practicality, making them a must-have addition to your activewear collection. Stay motivated, stay comfortable, and stay ahead of the game with Under Armour Pants.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw1fb70d65/images/022/452/07047000_000.jpg?q=80&sw=640"
            },


            new Clothing()
            {
            Name = "Rival Training Pants Men",
            Brand = Enums.UnderArmour,
            Price = 60,
            SalePrice = 0,
            Quantity = 10,
            Rating = 4.4,
            Popular = false,
            Type = Enums.Pants,
            Gender = true,
            Color = Enums.Blue,
            Size = Enums.Large,
            Description = "Elevate your athletic wardrobe with Under Armour Pants, a perfect fusion of style and performance. Designed with the modern athlete in mind, these pants offer exceptional comfort and functionality. Crafted with high-quality materials, they provide a soft and flexible fit that allows for unrestricted movement during workouts or everyday activities. The signature Under Armour logo adds a touch of authenticity, while the innovative moisture-wicking technology keeps you dry and comfortable throughout your training sessions. Whether you're hitting the gym, going for a jog, or simply running errands, Under Armour Pants deliver the perfect combination of style and practicality, making them a must-have addition to your activewear collection. Stay motivated, stay comfortable, and stay ahead of the game with Under Armour Pants.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw4003dcc8/images/022/462/08527000_000.jpg?q=80&sw=640"
            },


            new Clothing()
            {
            Name = "Sportstyle Tricot Training Pants Men",
            Brand = Enums.UnderArmour,
            Price = 70,
            SalePrice = 55,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Type = Enums.Pants,
            Gender = true,
            Color = Enums.Black,
            Size = Enums.Small,
            Description = "Elevate your athletic wardrobe with Under Armour Pants, a perfect fusion of style and performance. Designed with the modern athlete in mind, these pants offer exceptional comfort and functionality. Crafted with high-quality materials, they provide a soft and flexible fit that allows for unrestricted movement during workouts or everyday activities. The signature Under Armour logo adds a touch of authenticity, while the innovative moisture-wicking technology keeps you dry and comfortable throughout your training sessions. Whether you're hitting the gym, going for a jog, or simply running errands, Under Armour Pants deliver the perfect combination of style and practicality, making them a must-have addition to your activewear collection. Stay motivated, stay comfortable, and stay ahead of the game with Under Armour Pants.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwd8007843/images/022/462/08560000_000.jpg?q=80&sw=640"
            },

            new Clothing()
            {
            Name = "Rival Training Pants Women",
            Brand = Enums.UnderArmour,
            Price = 70,
            SalePrice = 50,
            Quantity = 10,
            Rating = 4.6,
            Popular = true,
            Type = Enums.Pants,
            Gender = false,
            Color = Enums.Blue,
            Size = Enums.Small,
            Description = "Elevate your athletic wardrobe with Under Armour Pants, a perfect fusion of style and performance. Designed with the modern athlete in mind, these pants offer exceptional comfort and functionality. Crafted with high-quality materials, they provide a soft and flexible fit that allows for unrestricted movement during workouts or everyday activities. The signature Under Armour logo adds a touch of authenticity, while the innovative moisture-wicking technology keeps you dry and comfortable throughout your training sessions. Whether you're hitting the gym, going for a jog, or simply running errands, Under Armour Pants deliver the perfect combination of style and practicality, making them a must-have addition to your activewear collection. Stay motivated, stay comfortable, and stay ahead of the game with Under Armour Pants.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw12ad82c8/images/022/462/08497000_000.jpg?q=80&sw=640"
            },


            new Clothing()
            {
            Name = "Rival Training Pants Women",
            Brand = Enums.UnderArmour,
            Price = 50,
            SalePrice = 30,
            Quantity = 10,
            Rating = 4.6,
            Popular = true,
            Type = Enums.Pants,
            Gender = false,
            Color = Enums.Red,
            Size = Enums.Medium,
            Description = "Elevate your athletic wardrobe with Under Armour Pants, a perfect fusion of style and performance. Designed with the modern athlete in mind, these pants offer exceptional comfort and functionality. Crafted with high-quality materials, they provide a soft and flexible fit that allows for unrestricted movement during workouts or everyday activities. The signature Under Armour logo adds a touch of authenticity, while the innovative moisture-wicking technology keeps you dry and comfortable throughout your training sessions. Whether you're hitting the gym, going for a jog, or simply running errands, Under Armour Pants deliver the perfect combination of style and practicality, making them a must-have addition to your activewear collection. Stay motivated, stay comfortable, and stay ahead of the game with Under Armour Pants.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw81d18243/images/022/460/08629000_000.jpg?q=80&sw=2000"
            },


            new Clothing()
            {
            Name = "Rival Training Pants Women",
            Brand = Enums.UnderArmour,
            Price = 50,
            SalePrice = 30,
            Quantity = 10,
            Rating = 4.6,
            Popular = true,
            Type = Enums.Pants,
            Gender = false,
            Color = Enums.White,
            Size = Enums.Small,
            Description = "Elevate your athletic wardrobe with Under Armour Pants, a perfect fusion of style and performance. Designed with the modern athlete in mind, these pants offer exceptional comfort and functionality. Crafted with high-quality materials, they provide a soft and flexible fit that allows for unrestricted movement during workouts or everyday activities. The signature Under Armour logo adds a touch of authenticity, while the innovative moisture-wicking technology keeps you dry and comfortable throughout your training sessions. Whether you're hitting the gym, going for a jog, or simply running errands, Under Armour Pants deliver the perfect combination of style and practicality, making them a must-have addition to your activewear collection. Stay motivated, stay comfortable, and stay ahead of the game with Under Armour Pants.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwe8b8f42d/images/022/458/07889000_000.jpg?q=80&sw=640"
            },

            //nike pants
            new Clothing()
            {
            Name = "Advantage Training Pants Men",
            Brand = Enums.Nike,
            Price = 50,
            SalePrice = 0,
            Quantity = 10,
            Rating = 5.0,
            Popular = true,
            Type = Enums.Pants,
            Gender = true,
            Color = Enums.Black,
            Size = Enums.Medium,
            Description = "Elevate your sporty style and performance with Nike Pants, the perfect choice for athletes and casual enthusiasts alike. These iconic pants combine comfort, versatility, and sleek design to take your athletic wardrobe to the next level. Crafted with premium materials, they offer a soft and lightweight feel, allowing for unrestricted movement during workouts or everyday activities. The classic Nike logo adds a touch of authenticity and style, while the innovative moisture-wicking technology keeps you dry and comfortable throughout your active pursuits. With their modern fit and functional details, Nike Pants are the go-to option for those seeking a perfect blend of fashion and performance. Whether you're hitting the gym, running errands, or simply lounging around, embrace the sporty-chic vibe and make a bold statement with Nike Pants.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwc0f5a348/images/004/460/55549000_000.jpg?q=80&sw=640"
            },

            new Clothing()
            {
            Name = "Advantage Training Pants Men",
            Brand = Enums.Nike,
            Price = 50,
            SalePrice = 0,
            Quantity = 10,
            Rating = 5.0,
            Popular = true,
            Type = Enums.Pants,
            Gender = true,
            Color = Enums.Blue,
            Size = Enums.Large,
            Description = "Elevate your sporty style and performance with Nike Pants, the perfect choice for athletes and casual enthusiasts alike. These iconic pants combine comfort, versatility, and sleek design to take your athletic wardrobe to the next level. Crafted with premium materials, they offer a soft and lightweight feel, allowing for unrestricted movement during workouts or everyday activities. The classic Nike logo adds a touch of authenticity and style, while the innovative moisture-wicking technology keeps you dry and comfortable throughout your active pursuits. With their modern fit and functional details, Nike Pants are the go-to option for those seeking a perfect blend of fashion and performance. Whether you're hitting the gym, running errands, or simply lounging around, embrace the sporty-chic vibe and make a bold statement with Nike Pants.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwcb00b19a/images/004/462/56748000_000.jpg?q=80&sw=640"
            },


            new Clothing()
            {
            Name = "Advantage Training Pants Men",
            Brand = Enums.Nike,
            Price = 50,
            SalePrice = 0,
            Quantity = 10,
            Rating = 5.0,
            Popular = true,
            Type = Enums.Pants,
            Gender = true,
            Color = Enums.White,
            Size = Enums.Large,
            Description = "Elevate your sporty style and performance with Nike Pants, the perfect choice for athletes and casual enthusiasts alike. These iconic pants combine comfort, versatility, and sleek design to take your athletic wardrobe to the next level. Crafted with premium materials, they offer a soft and lightweight feel, allowing for unrestricted movement during workouts or everyday activities. The classic Nike logo adds a touch of authenticity and style, while the innovative moisture-wicking technology keeps you dry and comfortable throughout your active pursuits. With their modern fit and functional details, Nike Pants are the go-to option for those seeking a perfect blend of fashion and performance. Whether you're hitting the gym, running errands, or simply lounging around, embrace the sporty-chic vibe and make a bold statement with Nike Pants.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw8964e19d/images/004/460/55550000_000.jpg?q=80&sw=640"
            },


            new Clothing()
            {
            Name = "Dri-Fit One MR Tight Women",
            Brand = Enums.Nike,
            Price = 50,
            SalePrice = 0,
            Quantity = 10,
            Rating = 5.0,
            Popular = true,
            Type = Enums.Pants,
            Gender = false,
            Color = Enums.Blue,
            Size = Enums.Small,
            Description = "Elevate your sporty style and performance with Nike Pants, the perfect choice for athletes and casual enthusiasts alike. These iconic pants combine comfort, versatility, and sleek design to take your athletic wardrobe to the next level. Crafted with premium materials, they offer a soft and lightweight feel, allowing for unrestricted movement during workouts or everyday activities. The classic Nike logo adds a touch of authenticity and style, while the innovative moisture-wicking technology keeps you dry and comfortable throughout your active pursuits. With their modern fit and functional details, Nike Pants are the go-to option for those seeking a perfect blend of fashion and performance. Whether you're hitting the gym, running errands, or simply lounging around, embrace the sporty-chic vibe and make a bold statement with Nike Pants.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwdd0a7654/images/004/462/56675000_000.jpg?q=80&sw=640"
            },


            new Clothing()
            {
            Name = "Dri-Fit One MR Tight Women",
            Brand = Enums.Nike,
            Price = 50,
            SalePrice = 0,
            Quantity = 10,
            Rating = 5.0,
            Popular = true,
            Type = Enums.Pants,
            Gender = false,
            Color = Enums.Grey,
            Size = Enums.Small,
            Description = "Elevate your sporty style and performance with Nike Pants, the perfect choice for athletes and casual enthusiasts alike. These iconic pants combine comfort, versatility, and sleek design to take your athletic wardrobe to the next level. Crafted with premium materials, they offer a soft and lightweight feel, allowing for unrestricted movement during workouts or everyday activities. The classic Nike logo adds a touch of authenticity and style, while the innovative moisture-wicking technology keeps you dry and comfortable throughout your active pursuits. With their modern fit and functional details, Nike Pants are the go-to option for those seeking a perfect blend of fashion and performance. Whether you're hitting the gym, running errands, or simply lounging around, embrace the sporty-chic vibe and make a bold statement with Nike Pants.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw1850eceb/images/004/459/55863000_000.jpg?q=80&sw=2000"
            },


            new Clothing()
            {
            Name = "Dri-Fit One MR Tight Women",
            Brand = Enums.Nike,
            Price = 50,
            SalePrice = 0,
            Quantity = 10,
            Rating = 5.0,
            Popular = true,
            Type = Enums.Pants,
            Gender = false,
            Color = Enums.Black,
            Size = Enums.Medium,
            Description = "Elevate your sporty style and performance with Nike Pants, the perfect choice for athletes and casual enthusiasts alike. These iconic pants combine comfort, versatility, and sleek design to take your athletic wardrobe to the next level. Crafted with premium materials, they offer a soft and lightweight feel, allowing for unrestricted movement during workouts or everyday activities. The classic Nike logo adds a touch of authenticity and style, while the innovative moisture-wicking technology keeps you dry and comfortable throughout your active pursuits. With their modern fit and functional details, Nike Pants are the go-to option for those seeking a perfect blend of fashion and performance. Whether you're hitting the gym, running errands, or simply lounging around, embrace the sporty-chic vibe and make a bold statement with Nike Pants.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw42f273d2/images/004/454/51951000_000.jpg?q=80&sw=2000"
            },

            //adidas pants
            new Clothing()
            {
            Name = "Training Essential Base 3 Training Pants Men",
            Brand = Enums.Adidas,
            Price = 50,
            SalePrice = 0,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Type = Enums.Pants,
            Gender = true,
            Color = Enums.Blue,
            Size = Enums.Large,
            Description = "Step up your sporty style with Adidas Pants, the ultimate combination of comfort and athletic appeal. These iconic pants feature the timeless Adidas design and superior craftsmanship, making them a must-have addition to your activewear collection. Crafted with premium materials, they provide a soft and flexible fit that allows for unrestricted movement during workouts or everyday activities. The iconic Adidas logo adds a touch of authenticity and street cred, while the innovative moisture-wicking technology keeps you cool and dry, even during intense training sessions. Whether you're hitting the gym, practicing your favorite sport, or simply running errands, Adidas Pants offer the perfect blend of style and functionality. Embrace the sporty-chic vibe and make a statement with these essential Adidas Pants.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw14f16ba7/images/005/464/18529000_000.jpg?q=80&sw=640"
            },


            new Clothing()
            {
            Name = "Training Essential Base 3 Training Pants Men",
            Brand = Enums.Adidas,
            Price = 50,
            SalePrice = 0,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Type = Enums.Pants,
            Gender = true,
            Color = Enums.Black,
            Size = Enums.Medium,
            Description = "Step up your sporty style with Adidas Pants, the ultimate combination of comfort and athletic appeal. These iconic pants feature the timeless Adidas design and superior craftsmanship, making them a must-have addition to your activewear collection. Crafted with premium materials, they provide a soft and flexible fit that allows for unrestricted movement during workouts or everyday activities. The iconic Adidas logo adds a touch of authenticity and street cred, while the innovative moisture-wicking technology keeps you cool and dry, even during intense training sessions. Whether you're hitting the gym, practicing your favorite sport, or simply running errands, Adidas Pants offer the perfect blend of style and functionality. Embrace the sporty-chic vibe and make a statement with these essential Adidas Pants.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwb312e487/images/005/464/18528000_000.jpg?q=80&sw=2000"
            },


            new Clothing()
            {
            Name = "3 Stripes Woven 7/8 Women",
            Brand = Enums.Adidas,
            Price = 50,
            SalePrice = 0,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Type = Enums.Pants,
            Gender = false,
            Color = Enums.Black,
            Size = Enums.Small,
            Description = "Step up your sporty style with Adidas Pants, the ultimate combination of comfort and athletic appeal. These iconic pants feature the timeless Adidas design and superior craftsmanship, making them a must-have addition to your activewear collection. Crafted with premium materials, they provide a soft and flexible fit that allows for unrestricted movement during workouts or everyday activities. The iconic Adidas logo adds a touch of authenticity and street cred, while the innovative moisture-wicking technology keeps you cool and dry, even during intense training sessions. Whether you're hitting the gym, practicing your favorite sport, or simply running errands, Adidas Pants offer the perfect blend of style and functionality. Embrace the sporty-chic vibe and make a statement with these essential Adidas Pants.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw6d2daa25/images/005/464/18373000_000.jpg?q=80&sw=640"
            },


            new Clothing()
            {
            Name = "Linear Tight Women",
            Brand = Enums.Adidas,
            Price = 30,
            SalePrice = 0,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Type = Enums.Pants,
            Gender = false,
            Color = Enums.Red,
            Size = Enums.Small,
            Description = "Step up your sporty style with Adidas Pants, the ultimate combination of comfort and athletic appeal. These iconic pants feature the timeless Adidas design and superior craftsmanship, making them a must-have addition to your activewear collection. Crafted with premium materials, they provide a soft and flexible fit that allows for unrestricted movement during workouts or everyday activities. The iconic Adidas logo adds a touch of authenticity and street cred, while the innovative moisture-wicking technology keeps you cool and dry, even during intense training sessions. Whether you're hitting the gym, practicing your favorite sport, or simply running errands, Adidas Pants offer the perfect blend of style and functionality. Embrace the sporty-chic vibe and make a statement with these essential Adidas Pants.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw877838a9/images/005/464/18390000_000.jpg?q=80&sw=2000"
            },


            //bidi badu dresses
            new Clothing()
            {
            Name = "Crew Dress Women",
            Brand = Enums.BidiBadu,
            Price = 60,
            SalePrice = 50,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Type = Enums.Dress,
            Gender = false,
            Color = Enums.Red,
            Size = Enums.Small,
            Description = "Experience the perfect fusion of style and performance with the BIDI BADU Dress. Designed for the confident and fashion-forward athlete, this dress showcases a unique blend of elegance and athleticism. Crafted with premium materials, it offers a comfortable and flattering fit that accentuates your silhouette while allowing for unrestricted movement on the court. The eye-catching design and vibrant colors of the BIDI BADU Dress ensure you stand out from the crowd, making a bold statement both on and off the tennis court. With its superior craftsmanship and attention to detail, this dress combines fashion-forward aesthetics with high-performance functionality. Whether you're competing in a tournament or hitting the practice courts, the BIDI BADU Dress is the perfect choice to showcase your style and enhance your performance.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwefdca5a0/images/162/462/01954000_000.jpg?q=80&sw=640"
            },


            new Clothing()
            {
            Name = "Crew Dress Women",
            Brand = Enums.BidiBadu,
            Price = 60,
            SalePrice = 50,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Type = Enums.Dress,
            Gender = false,
            Color = Enums.White,
            Size = Enums.Small,
            Description = "Experience the perfect fusion of style and performance with the BIDI BADU Dress. Designed for the confident and fashion-forward athlete, this dress showcases a unique blend of elegance and athleticism. Crafted with premium materials, it offers a comfortable and flattering fit that accentuates your silhouette while allowing for unrestricted movement on the court. The eye-catching design and vibrant colors of the BIDI BADU Dress ensure you stand out from the crowd, making a bold statement both on and off the tennis court. With its superior craftsmanship and attention to detail, this dress combines fashion-forward aesthetics with high-performance functionality. Whether you're competing in a tournament or hitting the practice courts, the BIDI BADU Dress is the perfect choice to showcase your style and enhance your performance.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw415b5e72/images/162/462/01957000_000.jpg?q=80&sw=2000"
            },


            new Clothing()
            {
            Name = "Crew Dress Women",
            Brand = Enums.BidiBadu,
            Price = 60,
            SalePrice = 50,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Type = Enums.Dress,
            Gender = false,
            Color = Enums.Black,
            Size = Enums.Small,
            Description = "Experience the perfect fusion of style and performance with the BIDI BADU Dress. Designed for the confident and fashion-forward athlete, this dress showcases a unique blend of elegance and athleticism. Crafted with premium materials, it offers a comfortable and flattering fit that accentuates your silhouette while allowing for unrestricted movement on the court. The eye-catching design and vibrant colors of the BIDI BADU Dress ensure you stand out from the crowd, making a bold statement both on and off the tennis court. With its superior craftsmanship and attention to detail, this dress combines fashion-forward aesthetics with high-performance functionality. Whether you're competing in a tournament or hitting the practice courts, the BIDI BADU Dress is the perfect choice to showcase your style and enhance your performance.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwdc5cb326/images/162/462/01956000_000.jpg?q=80&sw=2000"
            },


            //adidas dresses
            new Clothing()
            {
            Name = "Club Dress Women",
            Brand = Enums.Adidas,
            Price = 50,
            SalePrice = 0,
            Quantity = 10,
            Rating = 4.8,
            Popular = true,
            Type = Enums.Dress,
            Gender = false,
            Color = Enums.Yellow,
            Size = Enums.Medium,
            Description = "Step up your style game with the Adidas Dress, a perfect blend of sporty elegance and fashion-forward design. This iconic dress combines the classic Adidas aesthetic with superior craftsmanship, making it a versatile choice for any occasion. Crafted with high-quality materials, it offers a comfortable and flattering fit that accentuates your figure. The Adidas logo adds a touch of authenticity and street cred, while the sleek design and attention to detail elevate your overall look. Whether you're heading to the gym, attending a casual outing, or simply running errands, the Adidas Dress effortlessly combines style and functionality. Embrace the sporty-chic vibe and make a bold fashion statement with this essential piece of Adidas apparel.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwa5deac80/images/005/460/17341000_000.jpg?q=80&sw=640"
            },


            new Clothing()
            {
            Name = "Club Dress Women",
            Brand = Enums.Adidas,
            Price = 50,
            SalePrice = 0,
            Quantity = 10,
            Rating = 4.8,
            Popular = true,
            Type = Enums.Dress,
            Gender = false,
            Color = Enums.Grey,
            Size = Enums.Medium,
            Description = "Step up your style game with the Adidas Dress, a perfect blend of sporty elegance and fashion-forward design. This iconic dress combines the classic Adidas aesthetic with superior craftsmanship, making it a versatile choice for any occasion. Crafted with high-quality materials, it offers a comfortable and flattering fit that accentuates your figure. The Adidas logo adds a touch of authenticity and street cred, while the sleek design and attention to detail elevate your overall look. Whether you're heading to the gym, attending a casual outing, or simply running errands, the Adidas Dress effortlessly combines style and functionality. Embrace the sporty-chic vibe and make a bold fashion statement with this essential piece of Adidas apparel.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwb28f3abc/images/005/460/17342000_000.jpg?q=80&sw=2000"
            },


            new Clothing()
            {
            Name = "Club Dress Women",
            Brand = Enums.Adidas,
            Price = 50,
            SalePrice = 0,
            Quantity = 10,
            Rating = 4.8,
            Popular = true,
            Type = Enums.Dress,
            Gender = false,
            Color = Enums.Black,
            Size = Enums.Small,
            Description = "Step up your style game with the Adidas Dress, a perfect blend of sporty elegance and fashion-forward design. This iconic dress combines the classic Adidas aesthetic with superior craftsmanship, making it a versatile choice for any occasion. Crafted with high-quality materials, it offers a comfortable and flattering fit that accentuates your figure. The Adidas logo adds a touch of authenticity and street cred, while the sleek design and attention to detail elevate your overall look. Whether you're heading to the gym, attending a casual outing, or simply running errands, the Adidas Dress effortlessly combines style and functionality. Embrace the sporty-chic vibe and make a bold fashion statement with this essential piece of Adidas apparel.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw31516f37/images/005/458/16604000_000.jpg?q=80&sw=2000"
            },

            //head dresses
            new Clothing()
            {
            Name = "Spirit Dress Women",
            Brand = Enums.Head,
            Price = 80,
            SalePrice = 0,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Type = Enums.Dress,
            Gender = false,
            Color = Enums.Blue,
            Size = Enums.Small,
            Description = "Step up your style game with the HEAD Dress, a perfect blend of sporty elegance and fashion-forward design. This iconic dress combines the classic HEADaesthetic with superior craftsmanship, making it a versatile choice for any occasion. Crafted with high-quality materials, it offers a comfortable and flattering fit that accentuates your figure. The HEADlogo adds a touch of authenticity and street cred, while the sleek design and attention to detail elevate your overall look. Whether you're heading to the gym, attending a casual outing, or simply running errands, the HEAD Dress effortlessly combines style and functionality. Embrace the sporty-chic vibe and make a bold fashion statement with this essential piece of HEADapparel.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwb3196475/images/006/462/08038000_000.jpg?q=80&sw=640"
            },

            new Clothing()
            {
            Name = "Spirit Dress Women",
            Brand = Enums.Head,
            Price = 80,
            SalePrice = 0,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Type = Enums.Dress,
            Gender = false,
            Color = Enums.White,
            Size = Enums.Small,
            Description = "Step up your style game with the HEAD Dress, a perfect blend of sporty elegance and fashion-forward design. This iconic dress combines the classic HEADaesthetic with superior craftsmanship, making it a versatile choice for any occasion. Crafted with high-quality materials, it offers a comfortable and flattering fit that accentuates your figure. The HEADlogo adds a touch of authenticity and street cred, while the sleek design and attention to detail elevate your overall look. Whether you're heading to the gym, attending a casual outing, or simply running errands, the HEAD Dress effortlessly combines style and functionality. Embrace the sporty-chic vibe and make a bold fashion statement with this essential piece of HEADapparel.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw83edd937/images/006/462/08037000_000.jpg?q=80&sw=2000"
            },

            new Clothing()
            {
            Name = "Spirit Dress Women",
            Brand = Enums.Head,
            Price = 80,
            SalePrice = 0,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Type = Enums.Dress,
            Gender = false,
            Color = Enums.Green,
            Size = Enums.Small,
            Description = "Step up your style game with the HEAD Dress, a perfect blend of sporty elegance and fashion-forward design. This iconic dress combines the classic HEADaesthetic with superior craftsmanship, making it a versatile choice for any occasion. Crafted with high-quality materials, it offers a comfortable and flattering fit that accentuates your figure. The HEADlogo adds a touch of authenticity and street cred, while the sleek design and attention to detail elevate your overall look. Whether you're heading to the gym, attending a casual outing, or simply running errands, the HEAD Dress effortlessly combines style and functionality. Embrace the sporty-chic vibe and make a bold fashion statement with this essential piece of HEADapparel.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw874ac278/images/006/462/08039000_000.jpg?q=80&sw=2000"
            },


            //nike skirts
            new Clothing()
            {
            Name = "Dri-Fit Court Pleated Skirt Women",
            Brand = Enums.Nike,
            Price = 75,
            SalePrice = 50,
            Quantity = 10,
            Rating = 4.8,
            Popular = true,
            Type = Enums.Skirt,
            Gender = false,
            Color = Enums.Blue,
            Size = Enums.Small,
            Description = "Elevate your athletic style with the Nike Skirt, a perfect combination of sporty flair and feminine elegance. Designed with the modern athlete in mind, this skirt offers both comfort and performance. Crafted with premium materials, it provides a lightweight and breathable feel, allowing for unrestricted movement on and off the court. The sleek design and flattering fit add a touch of sophistication, while the iconic Nike logo showcases your sporty spirit. Whether you're playing tennis, hitting the track, or simply going for a casual outing, the Nike Skirt effortlessly blends fashion and functionality. Embrace the sporty-chic vibe and make a statement with this essential piece of Nike apparel.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw4674adb2/images/004/462/56618000_000.jpg?q=80&sw=640"
            },


            new Clothing()
            {
            Name = "Dri-Fit Court Pleated Skirt Women",
            Brand = Enums.Nike,
            Price = 75,
            SalePrice = 50,
            Quantity = 10,
            Rating = 4.8,
            Popular = true,
            Type = Enums.Skirt,
            Gender = false,
            Color = Enums.White,
            Size = Enums.Small,
            Description = "Elevate your athletic style with the Nike Skirt, a perfect combination of sporty flair and feminine elegance. Designed with the modern athlete in mind, this skirt offers both comfort and performance. Crafted with premium materials, it provides a lightweight and breathable feel, allowing for unrestricted movement on and off the court. The sleek design and flattering fit add a touch of sophistication, while the iconic Nike logo showcases your sporty spirit. Whether you're playing tennis, hitting the track, or simply going for a casual outing, the Nike Skirt effortlessly blends fashion and functionality. Embrace the sporty-chic vibe and make a statement with this essential piece of Nike apparel.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwcc186718/images/004/461/56200000_000.jpg?q=80&sw=2000"
            },


            new Clothing()
            {
            Name = "Dri-Fit Court Pleated Skirt Women",
            Brand = Enums.Nike,
            Price = 75,
            SalePrice = 50,
            Quantity = 10,
            Rating = 4.8,
            Popular = true,
            Type = Enums.Skirt,
            Gender = false,
            Color = Enums.Black,
            Size = Enums.Medium,
            Description = "Elevate your athletic style with the Nike Skirt, a perfect combination of sporty flair and feminine elegance. Designed with the modern athlete in mind, this skirt offers both comfort and performance. Crafted with premium materials, it provides a lightweight and breathable feel, allowing for unrestricted movement on and off the court. The sleek design and flattering fit add a touch of sophistication, while the iconic Nike logo showcases your sporty spirit. Whether you're playing tennis, hitting the track, or simply going for a casual outing, the Nike Skirt effortlessly blends fashion and functionality. Embrace the sporty-chic vibe and make a statement with this essential piece of Nike apparel.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwca8133e8/images/004/461/56199000_000.jpg?q=80&sw=2000"
            },


            //adidas skirts
            new Clothing()
            {
            Name = "Club Women",
            Brand = Enums.Adidas,
            Price = 45,
            SalePrice = 0,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Type = Enums.Skirt,
            Gender = false,
            Color = Enums.Red,
            Size = Enums.Small,
            Description = "Elevate your athletic style with the Adidas Skirt, a perfect combination of sporty flair and feminine elegance. Designed with the modern athlete in mind, this skirt offers both comfort and performance. Crafted with premium materials, it provides a lightweight and breathable feel, allowing for unrestricted movement on and off the court. The sleek design and flattering fit add a touch of sophistication, while the iconic Adidas logo showcases your sporty spirit. Whether you're playing tennis, hitting the track, or simply going for a casual outing, the Adidas Skirt effortlessly blends fashion and functionality. Embrace the sporty-chic vibe and make a statement with this essential piece of Adidas apparel.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwdb42fd99/images/005/464/18430000_000.jpg?q=80&sw=2000"
            },


            new Clothing()
            {
            Name = "Club Women",
            Brand = Enums.Adidas,
            Price = 45,
            SalePrice = 0,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Type = Enums.Skirt,
            Gender = false,
            Color = Enums.Blue,
            Size = Enums.Small,
            Description = "Elevate your athletic style with the Adidas Skirt, a perfect combination of sporty flair and feminine elegance. Designed with the modern athlete in mind, this skirt offers both comfort and performance. Crafted with premium materials, it provides a lightweight and breathable feel, allowing for unrestricted movement on and off the court. The sleek design and flattering fit add a touch of sophistication, while the iconic Adidas logo showcases your sporty spirit. Whether you're playing tennis, hitting the track, or simply going for a casual outing, the Adidas Skirt effortlessly blends fashion and functionality. Embrace the sporty-chic vibe and make a statement with this essential piece of Adidas apparel.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwc7cea945/images/005/462/17781000_000.jpg?q=80&sw=2000"
            },


            new Clothing()
            {
            Name = "Club Women",
            Brand = Enums.Adidas,
            Price = 45,
            SalePrice = 0,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Type = Enums.Skirt,
            Gender = false,
            Color = Enums.White,
            Size = Enums.Small,
            Description = "Elevate your athletic style with the Adidas Skirt, a perfect combination of sporty flair and feminine elegance. Designed with the modern athlete in mind, this skirt offers both comfort and performance. Crafted with premium materials, it provides a lightweight and breathable feel, allowing for unrestricted movement on and off the court. The sleek design and flattering fit add a touch of sophistication, while the iconic Adidas logo showcases your sporty spirit. Whether you're playing tennis, hitting the track, or simply going for a casual outing, the Adidas Skirt effortlessly blends fashion and functionality. Embrace the sporty-chic vibe and make a statement with this essential piece of Adidas apparel.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwb3cdb963/images/005/462/17780000_000.jpg?q=80&sw=2000"
            },


            //nike shirts
            new Clothing()
            {
            Name = "Dri-Fit Court Slam RG T-Shirt Men",
            Brand = Enums.Nike,
            Price = 75,
            SalePrice = 0,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Type = Enums.Shirt,
            Gender = true,
            Color = Enums.Green,
            Size = Enums.Small,
            Description = "Experience ultimate comfort and iconic style with the Nike Shirt. Designed for athletes and sporty enthusiasts, this shirt combines a sleek and modern aesthetic with the renowned performance of Nike. Crafted with high-quality materials, it offers a soft and breathable feel, ensuring maximum comfort during your workouts or everyday activities. The classic Nike logo adds a touch of authenticity and sporty appeal, while the versatile design makes it suitable for both training sessions and casual wear. Whether you're hitting the gym, going for a run, or simply lounging around, the Nike Shirt delivers the perfect balance of style and functionality. Stay motivated, stay comfortable, and stay ahead of the game with the Nike Shirt.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw67553fd0/images/004/463/57143000_000.jpg?q=80&sw=640"
            },

            new Clothing()
            {
            Name = "Dri-Fit Court Slam RG T-Shirt Men",
            Brand = Enums.Nike,
            Price = 75,
            SalePrice = 0,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Type = Enums.Shirt,
            Gender = true,
            Color = Enums.Blue,
            Size = Enums.Medium,
            Description = "Experience ultimate comfort and iconic style with the Nike Shirt. Designed for athletes and sporty enthusiasts, this shirt combines a sleek and modern aesthetic with the renowned performance of Nike. Crafted with high-quality materials, it offers a soft and breathable feel, ensuring maximum comfort during your workouts or everyday activities. The classic Nike logo adds a touch of authenticity and sporty appeal, while the versatile design makes it suitable for both training sessions and casual wear. Whether you're hitting the gym, going for a run, or simply lounging around, the Nike Shirt delivers the perfect balance of style and functionality. Stay motivated, stay comfortable, and stay ahead of the game with the Nike Shirt.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw96b300eb/images/004/463/57144000_000.jpg?q=80&sw=2000"
            },

            new Clothing()
            {
            Name = "Dri-Fit Court Slam RG T-Shirt Men",
            Brand = Enums.Nike,
            Price = 75,
            SalePrice = 0,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Type = Enums.Shirt,
            Gender = true,
            Color = Enums.Red,
            Size = Enums.Small,
            Description = "Experience ultimate comfort and iconic style with the Nike Shirt. Designed for athletes and sporty enthusiasts, this shirt combines a sleek and modern aesthetic with the renowned performance of Nike. Crafted with high-quality materials, it offers a soft and breathable feel, ensuring maximum comfort during your workouts or everyday activities. The classic Nike logo adds a touch of authenticity and sporty appeal, while the versatile design makes it suitable for both training sessions and casual wear. Whether you're hitting the gym, going for a run, or simply lounging around, the Nike Shirt delivers the perfect balance of style and functionality. Stay motivated, stay comfortable, and stay ahead of the game with the Nike Shirt.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw73b69198/images/004/463/57145000_000.jpg?q=80&sw=640"
            },


            new Clothing()
            {
            Name = "Dri-Fit One Luxe STD T-Shirt Women",
            Brand = Enums.Nike,
            Price = 50,
            SalePrice = 40,
            Quantity = 10,
            Rating = 4.2,
            Popular = false,
            Type = Enums.Shirt,
            Gender = false,
            Color = Enums.Red,
            Size = Enums.Small,
            Description = "Experience ultimate comfort and iconic style with the Nike Shirt. Designed for athletes and sporty enthusiasts, this shirt combines a sleek and modern aesthetic with the renowned performance of Nike. Crafted with high-quality materials, it offers a soft and breathable feel, ensuring maximum comfort during your workouts or everyday activities. The classic Nike logo adds a touch of authenticity and sporty appeal, while the versatile design makes it suitable for both training sessions and casual wear. Whether you're hitting the gym, going for a run, or simply lounging around, the Nike Shirt delivers the perfect balance of style and functionality. Stay motivated, stay comfortable, and stay ahead of the game with the Nike Shirt.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwebb55e90/images/004/463/57067000_000.jpg?q=80&sw=640"
            },

            new Clothing()
            {
            Name = "Dri-Fit One Luxe STD T-Shirt Women",
            Brand = Enums.Nike,
            Price = 50,
            SalePrice = 40,
            Quantity = 10,
            Rating = 4.2,
            Popular = false,
            Type = Enums.Shirt,
            Gender = false,
            Color = Enums.Blue,
            Size = Enums.Small,
            Description = "Experience ultimate comfort and iconic style with the Nike Shirt. Designed for athletes and sporty enthusiasts, this shirt combines a sleek and modern aesthetic with the renowned performance of Nike. Crafted with high-quality materials, it offers a soft and breathable feel, ensuring maximum comfort during your workouts or everyday activities. The classic Nike logo adds a touch of authenticity and sporty appeal, while the versatile design makes it suitable for both training sessions and casual wear. Whether you're hitting the gym, going for a run, or simply lounging around, the Nike Shirt delivers the perfect balance of style and functionality. Stay motivated, stay comfortable, and stay ahead of the game with the Nike Shirt.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwa7f63a51/images/004/462/56680000_000.jpg?q=80&sw=2000"
            },

            new Clothing()
            {
            Name = "Dri-Fit One Luxe STD T-Shirt Women",
            Brand = Enums.Nike,
            Price = 50,
            SalePrice = 40,
            Quantity = 10,
            Rating = 4.2,
            Popular = false,
            Type = Enums.Shirt,
            Gender = false,
            Color = Enums.Black,
            Size = Enums.Small,
            Description = "Experience ultimate comfort and iconic style with the Nike Shirt. Designed for athletes and sporty enthusiasts, this shirt combines a sleek and modern aesthetic with the renowned performance of Nike. Crafted with high-quality materials, it offers a soft and breathable feel, ensuring maximum comfort during your workouts or everyday activities. The classic Nike logo adds a touch of authenticity and sporty appeal, while the versatile design makes it suitable for both training sessions and casual wear. Whether you're hitting the gym, going for a run, or simply lounging around, the Nike Shirt delivers the perfect balance of style and functionality. Stay motivated, stay comfortable, and stay ahead of the game with the Nike Shirt.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw170c93f0/images/004/458/56124000_000.jpg?q=80&sw=2000"
            },


            new Clothing()
            {
            Name = "Dri-Fit One STD T-Shirt Women",
            Brand = Enums.Nike,
            Price = 35,
            SalePrice = 0,
            Quantity = 10,
            Rating = 4.7,
            Popular = true,
            Type = Enums.Shirt,
            Gender = false,
            Color = Enums.Blue,
            Size = Enums.Small,
            Description = "Experience ultimate comfort and iconic style with the Nike Shirt. Designed for athletes and sporty enthusiasts, this shirt combines a sleek and modern aesthetic with the renowned performance of Nike. Crafted with high-quality materials, it offers a soft and breathable feel, ensuring maximum comfort during your workouts or everyday activities. The classic Nike logo adds a touch of authenticity and sporty appeal, while the versatile design makes it suitable for both training sessions and casual wear. Whether you're hitting the gym, going for a run, or simply lounging around, the Nike Shirt delivers the perfect balance of style and functionality. Stay motivated, stay comfortable, and stay ahead of the game with the Nike Shirt.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw5f84d4b5/images/004/463/57070000_000.jpg?q=80&sw=640"
            },


            //adidas shirts
            new Clothing()
            {
            Name = "Melbourne Ergo HEAT.RDY T-Shirt Men",
            Brand = Enums.Adidas,
            Price = 70,
            SalePrice = 40,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Type = Enums.Shirt,
            Gender = true,
            Color = Enums.Red,
            Size = Enums.Medium,
            Description = "Experience ultimate comfort and iconic style with the Adidas Shirt. Designed for athletes and sporty enthusiasts, this shirt combines a sleek and modern aesthetic with the renowned performance of Adidas . Crafted with high-quality materials, it offers a soft and breathable feel, ensuring maximum comfort during your workouts or everyday activities. The classic Adidas logo adds a touch of authenticity and sporty appeal, while the versatile design makes it suitable for both training sessions and casual wear. Whether you're hitting the gym, going for a run, or simply lounging around, the Adidas Shirt delivers the perfect balance of style and functionality. Stay motivated, stay comfortable, and stay ahead of the game with the Adidas Shirt.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwa08f4c18/images/005/462/17960000_000.jpg?q=80&sw=640"
            },

            new Clothing()
            {
            Name = "Melbourne Ergo HEAT.RDY T-Shirt Men",
            Brand = Enums.Adidas,
            Price = 70,
            SalePrice = 40,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Type = Enums.Shirt,
            Gender = true,
            Color = Enums.Black,
            Size = Enums.Large,
            Description = "Experience ultimate comfort and iconic style with the Adidas Shirt. Designed for athletes and sporty enthusiasts, this shirt combines a sleek and modern aesthetic with the renowned performance of Adidas . Crafted with high-quality materials, it offers a soft and breathable feel, ensuring maximum comfort during your workouts or everyday activities. The classic Adidas logo adds a touch of authenticity and sporty appeal, while the versatile design makes it suitable for both training sessions and casual wear. Whether you're hitting the gym, going for a run, or simply lounging around, the Adidas Shirt delivers the perfect balance of style and functionality. Stay motivated, stay comfortable, and stay ahead of the game with the Adidas Shirt.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw11e22faf/images/005/462/17958000_000.jpg?q=80&sw=640"
            },

            new Clothing()
            {
            Name = "Melbourne Ergo HEAT.RDY T-Shirt Men",
            Brand = Enums.Adidas,
            Price = 70,
            SalePrice = 40,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Type = Enums.Shirt,
            Gender = true,
            Color = Enums.Blue,
            Size = Enums.Medium,
            Description = "Experience ultimate comfort and iconic style with the Adidas Shirt. Designed for athletes and sporty enthusiasts, this shirt combines a sleek and modern aesthetic with the renowned performance of Adidas . Crafted with high-quality materials, it offers a soft and breathable feel, ensuring maximum comfort during your workouts or everyday activities. The classic Adidas logo adds a touch of authenticity and sporty appeal, while the versatile design makes it suitable for both training sessions and casual wear. Whether you're hitting the gym, going for a run, or simply lounging around, the Adidas Shirt delivers the perfect balance of style and functionality. Stay motivated, stay comfortable, and stay ahead of the game with the Adidas Shirt.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw976054e7/images/005/462/17959000_000.png?q=80&sw=2000"
            },


            new Clothing()
            {
            Name = "Paris Freelift Polo Men",
            Brand = Enums.Adidas,
            Price = 70,
            SalePrice = 45,
            Quantity = 10,
            Rating = 4.8,
            Popular = true,
            Type = Enums.Shirt,
            Gender = true,
            Color = Enums.Grey,
            Size = Enums.Medium,
            Description = "Experience ultimate comfort and iconic style with the Adidas Shirt. Designed for athletes and sporty enthusiasts, this shirt combines a sleek and modern aesthetic with the renowned performance of Adidas . Crafted with high-quality materials, it offers a soft and breathable feel, ensuring maximum comfort during your workouts or everyday activities. The classic Adidas logo adds a touch of authenticity and sporty appeal, while the versatile design makes it suitable for both training sessions and casual wear. Whether you're hitting the gym, going for a run, or simply lounging around, the Adidas Shirt delivers the perfect balance of style and functionality. Stay motivated, stay comfortable, and stay ahead of the game with the Adidas Shirt.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw914c7424/images/005/462/17971000_000.jpg?q=80&sw=640"
            },


            new Clothing()
            {
            Name = "Club T-Shirt Women",
            Brand = Enums.Adidas,
            Price = 45,
            SalePrice = 38,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Type = Enums.Shirt,
            Gender = false,
            Color = Enums.Grey,
            Size = Enums.Small,
            Description = "Experience ultimate comfort and iconic style with the Adidas Shirt. Designed for athletes and sporty enthusiasts, this shirt combines a sleek and modern aesthetic with the renowned performance of Adidas . Crafted with high-quality materials, it offers a soft and breathable feel, ensuring maximum comfort during your workouts or everyday activities. The classic Adidas logo adds a touch of authenticity and sporty appeal, while the versatile design makes it suitable for both training sessions and casual wear. Whether you're hitting the gym, going for a run, or simply lounging around, the Adidas Shirt delivers the perfect balance of style and functionality. Stay motivated, stay comfortable, and stay ahead of the game with the Adidas Shirt.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw3053c7ce/images/005/462/17798000_000.jpg?q=80&sw=640"
            },

            new Clothing()
            {
            Name = "Club T-Shirt Women",
            Brand = Enums.Adidas,
            Price = 45,
            SalePrice = 38,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Type = Enums.Shirt,
            Gender = false,
            Color = Enums.Blue,
            Size = Enums.Medium,
            Description = "Experience ultimate comfort and iconic style with the Adidas Shirt. Designed for athletes and sporty enthusiasts, this shirt combines a sleek and modern aesthetic with the renowned performance of Adidas . Crafted with high-quality materials, it offers a soft and breathable feel, ensuring maximum comfort during your workouts or everyday activities. The classic Adidas logo adds a touch of authenticity and sporty appeal, while the versatile design makes it suitable for both training sessions and casual wear. Whether you're hitting the gym, going for a run, or simply lounging around, the Adidas Shirt delivers the perfect balance of style and functionality. Stay motivated, stay comfortable, and stay ahead of the game with the Adidas Shirt.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw14bdccf4/images/005/462/17775000_000.jpg?q=80&sw=640"
            },

            new Clothing()
            {
            Name = "Club T-Shirt Women",
            Brand = Enums.Adidas,
            Price = 45,
            SalePrice = 38,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Type = Enums.Shirt,
            Gender = false,
            Color = Enums.White,
            Size = Enums.Small,
            Description = "Experience ultimate comfort and iconic style with the Adidas Shirt. Designed for athletes and sporty enthusiasts, this shirt combines a sleek and modern aesthetic with the renowned performance of Adidas . Crafted with high-quality materials, it offers a soft and breathable feel, ensuring maximum comfort during your workouts or everyday activities. The classic Adidas logo adds a touch of authenticity and sporty appeal, while the versatile design makes it suitable for both training sessions and casual wear. Whether you're hitting the gym, going for a run, or simply lounging around, the Adidas Shirt delivers the perfect balance of style and functionality. Stay motivated, stay comfortable, and stay ahead of the game with the Adidas Shirt.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwbe222ca5/images/005/462/17776000_000.jpg?q=80&sw=2000"
            },


            //nike shorts
            new Clothing()
            {
            Name = "Dri-Fit Advantage Court Shorts Women",
            Brand = Enums.Nike,
            Price = 65,
            SalePrice = 45,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Type = Enums.Shorts,
            Gender = false,
            Color = Enums.Red,
            Size = Enums.Small,
            Description = "Step up your athletic game with Nike Shorts, the perfect blend of style and performance. Designed for the modern athlete, these shorts offer unbeatable comfort and functionality. Crafted with high-quality materials, they provide a lightweight and breathable feel, keeping you cool and dry during intense workouts or everyday activities. The iconic Nike logo adds a touch of authenticity and sporty flair, while the versatile design allows for unrestricted movement. Whether you're hitting the basketball court, going for a jog, or simply lounging around, Nike Shorts are a go-to choice for both sporty and casual occasions. Embrace the athletic spirit and make a statement with these essential Nike Shorts.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw33aba5fb/images/004/463/57037000_000.jpg?q=80&sw=640"
            },

            new Clothing()
            {
            Name = "Dri-Fit Advantage Court Shorts Women",
            Brand = Enums.Nike,
            Price = 65,
            SalePrice = 45,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Type = Enums.Shorts,
            Gender = false,
            Color = Enums.Blue,
            Size = Enums.Medium,
            Description = "Step up your athletic game with Nike Shorts, the perfect blend of style and performance. Designed for the modern athlete, these shorts offer unbeatable comfort and functionality. Crafted with high-quality materials, they provide a lightweight and breathable feel, keeping you cool and dry during intense workouts or everyday activities. The iconic Nike logo adds a touch of authenticity and sporty flair, while the versatile design allows for unrestricted movement. Whether you're hitting the basketball court, going for a jog, or simply lounging around, Nike Shorts are a go-to choice for both sporty and casual occasions. Embrace the athletic spirit and make a statement with these essential Nike Shorts.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwf3a296d4/images/004/462/56616000_000.jpg?q=80&sw=640"
            },

            new Clothing()
            {
            Name = "Dri-Fit Advantage Court Shorts Women",
            Brand = Enums.Nike,
            Price = 65,
            SalePrice = 45,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Type = Enums.Shorts,
            Gender = false,
            Color = Enums.White,
            Size = Enums.Small,
            Description = "Step up your athletic game with Nike Shorts, the perfect blend of style and performance. Designed for the modern athlete, these shorts offer unbeatable comfort and functionality. Crafted with high-quality materials, they provide a lightweight and breathable feel, keeping you cool and dry during intense workouts or everyday activities. The iconic Nike logo adds a touch of authenticity and sporty flair, while the versatile design allows for unrestricted movement. Whether you're hitting the basketball court, going for a jog, or simply lounging around, Nike Shorts are a go-to choice for both sporty and casual occasions. Embrace the athletic spirit and make a statement with these essential Nike Shorts.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw87895b32/images/004/462/56615000_000.jpg?q=80&sw=2000"
            },


            new Clothing()
            {
            Name = "Dri-Fit Advantage 9in Shorts Men",
            Brand = Enums.Nike,
            Price = 60,
            SalePrice = 52,
            Quantity = 10,
            Rating = 4.6,
            Popular = true,
            Type = Enums.Shorts,
            Gender = true,
            Color = Enums.Black,
            Size = Enums.Small,
            Description = "Step up your athletic game with Nike Shorts, the perfect blend of style and performance. Designed for the modern athlete, these shorts offer unbeatable comfort and functionality. Crafted with high-quality materials, they provide a lightweight and breathable feel, keeping you cool and dry during intense workouts or everyday activities. The iconic Nike logo adds a touch of authenticity and sporty flair, while the versatile design allows for unrestricted movement. Whether you're hitting the basketball court, going for a jog, or simply lounging around, Nike Shorts are a go-to choice for both sporty and casual occasions. Embrace the athletic spirit and make a statement with these essential Nike Shorts.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwdb78c910/images/004/458/55298000_000.jpg?q=80&sw=640"
            },

            new Clothing()
            {
            Name = "Dri-Fit Advantage 9in Shorts Men",
            Brand = Enums.Nike,
            Price = 60,
            SalePrice = 52,
            Quantity = 10,
            Rating = 4.6,
            Popular = true,
            Type = Enums.Shorts,
            Gender = true,
            Color = Enums.White,
            Size = Enums.Medium,
            Description = "Step up your athletic game with Nike Shorts, the perfect blend of style and performance. Designed for the modern athlete, these shorts offer unbeatable comfort and functionality. Crafted with high-quality materials, they provide a lightweight and breathable feel, keeping you cool and dry during intense workouts or everyday activities. The iconic Nike logo adds a touch of authenticity and sporty flair, while the versatile design allows for unrestricted movement. Whether you're hitting the basketball court, going for a jog, or simply lounging around, Nike Shorts are a go-to choice for both sporty and casual occasions. Embrace the athletic spirit and make a statement with these essential Nike Shorts.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw0d4cc731/images/004/458/55299000_000.jpg?q=80&sw=2000"
            },

            new Clothing()
            {
            Name = "Dri-Fit Advantage 9in Shorts Men",
            Brand = Enums.Nike,
            Price = 60,
            SalePrice = 52,
            Quantity = 10,
            Rating = 4.6,
            Popular = true,
            Type = Enums.Shorts,
            Gender = true,
            Color = Enums.Green,
            Size = Enums.Small,
            Description = "Step up your athletic game with Nike Shorts, the perfect blend of style and performance. Designed for the modern athlete, these shorts offer unbeatable comfort and functionality. Crafted with high-quality materials, they provide a lightweight and breathable feel, keeping you cool and dry during intense workouts or everyday activities. The iconic Nike logo adds a touch of authenticity and sporty flair, while the versatile design allows for unrestricted movement. Whether you're hitting the basketball court, going for a jog, or simply lounging around, Nike Shorts are a go-to choice for both sporty and casual occasions. Embrace the athletic spirit and make a statement with these essential Nike Shorts.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwdcca517f/images/004/463/57130000_000.jpg?q=80&sw=640"
            },


            new Clothing()
            {
            Name = "Dri-Fit Advantage Rafa 7in Shorts Men",
            Brand = Enums.Nike,
            Price = 70,
            SalePrice = 40,
            Quantity = 10,
            Rating = 4.9,
            Popular = true,
            Type = Enums.Shorts,
            Gender = true,
            Color = Enums.Red,
            Size = Enums.Small,
            Description = "Step up your athletic game with Nike Shorts, the perfect blend of style and performance. Designed for the modern athlete, these shorts offer unbeatable comfort and functionality. Crafted with high-quality materials, they provide a lightweight and breathable feel, keeping you cool and dry during intense workouts or everyday activities. The iconic Nike logo adds a touch of authenticity and sporty flair, while the versatile design allows for unrestricted movement. Whether you're hitting the basketball court, going for a jog, or simply lounging around, Nike Shorts are a go-to choice for both sporty and casual occasions. Embrace the athletic spirit and make a statement with these essential Nike Shorts.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw4b062941/images/004/460/55584000_000.jpg?q=80&sw=640"
            },


            //adidas shorts
            new Clothing()
            {
            Name = "Melbourne Ergo Graphic Shorts Men",
            Brand = Enums.Adidas,
            Price = 65,
            SalePrice = 45,
            Quantity = 10,
            Rating = 4.7,
            Popular = true,
            Type = Enums.Shorts,
            Gender = true,
            Color = Enums.Blue,
            Size = Enums.Small,
            Description = "Step up your athletic game with Adidas Shorts, the perfect blend of style and performance. Designed for the modern athlete, these shorts offer unbeatable comfort and functionality. Crafted with high-quality materials, they provide a lightweight and breathable feel, keeping you cool and dry during intense workouts or everyday activities. The iconic Adidas logo adds a touch of authenticity and sporty flair, while the versatile design allows for unrestricted movement. Whether you're hitting the basketball court, going for a jog, or simply lounging around, Adidas Shorts are a go-to choice for both sporty and casual occasions. Embrace the athletic spirit and make a statement with these essential Adidas Shorts.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw7cae5a84/images/005/462/17962000_000.jpg?q=80&sw=640"
            },


            new Clothing()
            {
            Name = "Essentials Train Woven Training 9in Shorts Men",
            Brand = Enums.Adidas,
            Price = 30,
            SalePrice = 0,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Type = Enums.Shorts,
            Gender = true,
            Color = Enums.Black,
            Size = Enums.Small,
            Description = "Step up your athletic game with Adidas Shorts, the perfect blend of style and performance. Designed for the modern athlete, these shorts offer unbeatable comfort and functionality. Crafted with high-quality materials, they provide a lightweight and breathable feel, keeping you cool and dry during intense workouts or everyday activities. The iconic Adidas logo adds a touch of authenticity and sporty flair, while the versatile design allows for unrestricted movement. Whether you're hitting the basketball court, going for a jog, or simply lounging around, Adidas Shorts are a go-to choice for both sporty and casual occasions. Embrace the athletic spirit and make a statement with these essential Adidas Shorts.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwc09c5192/images/005/462/17997000_000.jpg?q=80&sw=640"
            },

            new Clothing()
            {
            Name = "Essentials Train Woven Training 9in Shorts Men",
            Brand = Enums.Adidas,
            Price = 30,
            SalePrice = 0,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Type = Enums.Shorts,
            Gender = true,
            Color = Enums.Red,
            Size = Enums.Medium,
            Description = "Step up your athletic game with Adidas Shorts, the perfect blend of style and performance. Designed for the modern athlete, these shorts offer unbeatable comfort and functionality. Crafted with high-quality materials, they provide a lightweight and breathable feel, keeping you cool and dry during intense workouts or everyday activities. The iconic Adidas logo adds a touch of authenticity and sporty flair, while the versatile design allows for unrestricted movement. Whether you're hitting the basketball court, going for a jog, or simply lounging around, Adidas Shorts are a go-to choice for both sporty and casual occasions. Embrace the athletic spirit and make a statement with these essential Adidas Shorts.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwe058823a/images/005/462/18000000_000.jpg?q=80&sw=640"
            },

            new Clothing()
            {
            Name = "Essentials Train Woven Training 9in Shorts Men",
            Brand = Enums.Adidas,
            Price = 30,
            SalePrice = 0,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Type = Enums.Shorts,
            Gender = true,
            Color = Enums.Blue,
            Size = Enums.Medium,
            Description = "Step up your athletic game with Adidas Shorts, the perfect blend of style and performance. Designed for the modern athlete, these shorts offer unbeatable comfort and functionality. Crafted with high-quality materials, they provide a lightweight and breathable feel, keeping you cool and dry during intense workouts or everyday activities. The iconic Adidas logo adds a touch of authenticity and sporty flair, while the versatile design allows for unrestricted movement. Whether you're hitting the basketball court, going for a jog, or simply lounging around, Adidas Shorts are a go-to choice for both sporty and casual occasions. Embrace the athletic spirit and make a statement with these essential Adidas Shorts.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw7ca32cbc/images/005/464/18533000_000.jpg?q=80&sw=2000"
            },


            new Clothing()
            {
            Name = "Club Shorts Women",
            Brand = Enums.Adidas,
            Price = 40,
            SalePrice = 0,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Type = Enums.Shorts,
            Gender = false,
            Color = Enums.Red,
            Size = Enums.Small,
            Description = "Step up your athletic game with Adidas Shorts, the perfect blend of style and performance. Designed for the modern athlete, these shorts offer unbeatable comfort and functionality. Crafted with high-quality materials, they provide a lightweight and breathable feel, keeping you cool and dry during intense workouts or everyday activities. The iconic Adidas logo adds a touch of authenticity and sporty flair, while the versatile design allows for unrestricted movement. Whether you're hitting the basketball court, going for a jog, or simply lounging around, Adidas Shorts are a go-to choice for both sporty and casual occasions. Embrace the athletic spirit and make a statement with these essential Adidas Shorts.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwc2337c18/images/005/462/17778000_000.jpg?q=80&sw=640"
            },

            new Clothing()
            {
            Name = "Club Shorts Women",
            Brand = Enums.Adidas,
            Price = 40,
            SalePrice = 0,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Type = Enums.Shorts,
            Gender = false,
            Color = Enums.Black,
            Size = Enums.Medium,
            Description = "Step up your athletic game with Adidas Shorts, the perfect blend of style and performance. Designed for the modern athlete, these shorts offer unbeatable comfort and functionality. Crafted with high-quality materials, they provide a lightweight and breathable feel, keeping you cool and dry during intense workouts or everyday activities. The iconic Adidas logo adds a touch of authenticity and sporty flair, while the versatile design allows for unrestricted movement. Whether you're hitting the basketball court, going for a jog, or simply lounging around, Adidas Shorts are a go-to choice for both sporty and casual occasions. Embrace the athletic spirit and make a statement with these essential Adidas Shorts.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwd88b1839/images/005/462/17799000_000.jpg?q=80&sw=640"
            },

            new Clothing()
            {
            Name = "Club Shorts Women",
            Brand = Enums.Adidas,
            Price = 40,
            SalePrice = 0,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Type = Enums.Shorts,
            Gender = false,
            Color = Enums.White,
            Size = Enums.Small,
            Description = "Step up your athletic game with Adidas Shorts, the perfect blend of style and performance. Designed for the modern athlete, these shorts offer unbeatable comfort and functionality. Crafted with high-quality materials, they provide a lightweight and breathable feel, keeping you cool and dry during intense workouts or everyday activities. The iconic Adidas logo adds a touch of authenticity and sporty flair, while the versatile design allows for unrestricted movement. Whether you're hitting the basketball court, going for a jog, or simply lounging around, Adidas Shorts are a go-to choice for both sporty and casual occasions. Embrace the athletic spirit and make a statement with these essential Adidas Shorts.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwcd667d26/images/005/462/17815000_000.jpg?q=80&sw=640"
            }
        };

        return clothings;
    }

    private List<Shoes> GetShoes()
    {
        var shoes = new List<Shoes>(){

            //wilson shoes
            new Shoes()
            {
            Name = "Rush 4.0 Clay Court Shoe Men",
            Brand = Enums.Wilson,
            Price = 140,
            SalePrice = 90,
            Quantity = 10,
            Rating = 4.6,
            Popular = true,
            Gender = true,
            Color = Enums.Grey,
            Size = Enums.Shoes41,
            Description = "Elevate your performance on the court with Wilson Shoes, the ultimate fusion of style and functionality. Designed for tennis enthusiasts and athletes, these shoes deliver unmatched comfort and support for intense gameplay. Crafted with precision and expertise, Wilson Shoes offer a secure fit and superior traction, ensuring quick movements and stability on any surface. The sleek design and attention to detail make them a stylish choice both on and off the court. Whether you're sprinting to the net or engaging in intense rallies, Wilson Shoes provide the perfect balance of comfort, durability, and performance. Step up your game and unleash your full potential with Wilson Shoes, the footwear of choice for champions.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw0112000d/images/007/158/02586000_0_1.jpg?q=80&sw=640"
            },

            new Shoes()
            {
            Name = "Rush 4.0 Clay Court Shoe Men",
            Brand = Enums.Wilson,
            Price = 140,
            SalePrice = 90,
            Quantity = 10,
            Rating = 4.6,
            Popular = true,
            Gender = true,
            Color = Enums.Blue,
            Size = Enums.Shoes41,
            Description = "Elevate your performance on the court with Wilson Shoes, the ultimate fusion of style and functionality. Designed for tennis enthusiasts and athletes, these shoes deliver unmatched comfort and support for intense gameplay. Crafted with precision and expertise, Wilson Shoes offer a secure fit and superior traction, ensuring quick movements and stability on any surface. The sleek design and attention to detail make them a stylish choice both on and off the court. Whether you're sprinting to the net or engaging in intense rallies, Wilson Shoes provide the perfect balance of comfort, durability, and performance. Step up your game and unleash your full potential with Wilson Shoes, the footwear of choice for champions.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw7d998073/images/007/158/02584000_0_1.jpg?q=80&sw=640"
            },

            new Shoes()
            {
            Name = "Rush 4.0 Clay Court Shoe Men",
            Brand = Enums.Wilson,
            Price = 140,
            SalePrice = 90,
            Quantity = 10,
            Rating = 4.6,
            Popular = true,
            Gender = true,
            Color = Enums.Black,
            Size = Enums.Shoes41,
            Description = "Elevate your performance on the court with Wilson Shoes, the ultimate fusion of style and functionality. Designed for tennis enthusiasts and athletes, these shoes deliver unmatched comfort and support for intense gameplay. Crafted with precision and expertise, Wilson Shoes offer a secure fit and superior traction, ensuring quick movements and stability on any surface. The sleek design and attention to detail make them a stylish choice both on and off the court. Whether you're sprinting to the net or engaging in intense rallies, Wilson Shoes provide the perfect balance of comfort, durability, and performance. Step up your game and unleash your full potential with Wilson Shoes, the footwear of choice for champions.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw59422e4a/images/007/158/02585000_0_1.jpg?q=80&sw=640"
            },


            new Shoes()
            {
            Name = "Rush Pro 4.0 Clay Court Shoe Women",
            Brand = Enums.Wilson,
            Price = 140,
            SalePrice = 110,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Gender = false,
            Color = Enums.Red,
            Size = Enums.Shoes39,
            Description = "Elevate your performance on the court with Wilson Shoes, the ultimate fusion of style and functionality. Designed for tennis enthusiasts and athletes, these shoes deliver unmatched comfort and support for intense gameplay. Crafted with precision and expertise, Wilson Shoes offer a secure fit and superior traction, ensuring quick movements and stability on any surface. The sleek design and attention to detail make them a stylish choice both on and off the court. Whether you're sprinting to the net or engaging in intense rallies, Wilson Shoes provide the perfect balance of comfort, durability, and performance. Step up your game and unleash your full potential with Wilson Shoes, the footwear of choice for champions.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwc8ba2758/images/007/162/02608000_0_1.jpg?q=80&sw=2000"
            },

            new Shoes()
            {
            Name = "Rush Pro 4.0 Clay Court Shoe Women",
            Brand = Enums.Wilson,
            Price = 140,
            SalePrice = 110,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Gender = false,
            Color = Enums.Red,
            Size = Enums.Shoes395,
            Description = "Elevate your performance on the court with Wilson Shoes, the ultimate fusion of style and functionality. Designed for tennis enthusiasts and athletes, these shoes deliver unmatched comfort and support for intense gameplay. Crafted with precision and expertise, Wilson Shoes offer a secure fit and superior traction, ensuring quick movements and stability on any surface. The sleek design and attention to detail make them a stylish choice both on and off the court. Whether you're sprinting to the net or engaging in intense rallies, Wilson Shoes provide the perfect balance of comfort, durability, and performance. Step up your game and unleash your full potential with Wilson Shoes, the footwear of choice for champions.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwc8ba2758/images/007/162/02608000_0_1.jpg?q=80&sw=2000"
            },


            new Shoes()
            {
            Name = "Rush Pro 4.0 Clay Court Shoe Women",
            Brand = Enums.Wilson,
            Price = 140,
            SalePrice = 110,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Gender = false,
            Color = Enums.Blue,
            Size = Enums.Shoes40,
            Description = "Elevate your performance on the court with Wilson Shoes, the ultimate fusion of style and functionality. Designed for tennis enthusiasts and athletes, these shoes deliver unmatched comfort and support for intense gameplay. Crafted with precision and expertise, Wilson Shoes offer a secure fit and superior traction, ensuring quick movements and stability on any surface. The sleek design and attention to detail make them a stylish choice both on and off the court. Whether you're sprinting to the net or engaging in intense rallies, Wilson Shoes provide the perfect balance of comfort, durability, and performance. Step up your game and unleash your full potential with Wilson Shoes, the footwear of choice for champions.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwc98b6e40/images/007/158/02589000_0_1.jpg?q=80&sw=2000"
            },

            new Shoes()
            {
            Name = "Rush Pro 4.0 Clay Court Shoe Women",
            Brand = Enums.Wilson,
            Price = 140,
            SalePrice = 110,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Gender = false,
            Color = Enums.Black,
            Size = Enums.Shoes40,
            Description = "Elevate your performance on the court with Wilson Shoes, the ultimate fusion of style and functionality. Designed for tennis enthusiasts and athletes, these shoes deliver unmatched comfort and support for intense gameplay. Crafted with precision and expertise, Wilson Shoes offer a secure fit and superior traction, ensuring quick movements and stability on any surface. The sleek design and attention to detail make them a stylish choice both on and off the court. Whether you're sprinting to the net or engaging in intense rallies, Wilson Shoes provide the perfect balance of comfort, durability, and performance. Step up your game and unleash your full potential with Wilson Shoes, the footwear of choice for champions.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwac367ee9/images/007/158/02546000_0_1.jpg?q=80&sw=2000"
            },


            //nike shoes
            new Shoes()
            {
            Name = "Vapor Lite 2 Clay Court Shoe Men",
            Brand = Enums.Nike,
            Price = 70,
            SalePrice = 0,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Gender = true,
            Color = Enums.Black,
            Size = Enums.Shoes40,
            Description = "Elevate your performance on the court with Nike Shoes, the ultimate fusion of style and functionality. Designed for tennis enthusiasts and athletes, these shoes deliver unmatched comfort and support for intense gameplay. Crafted with precision and expertise, Nike Shoes offer a secure fit and superior traction, ensuring quick movements and stability on any surface. The sleek design and attention to detail make them a stylish choice both on and off the court. Whether you're sprinting to the net or engaging in intense rallies, Nike Shoes provide the perfect balance of comfort, durability, and performance. Step up your game and unleash your full potential with Nike Shoes, the footwear of choice for champions.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw353e9912/images/004/163/17342000_0_1.jpg?q=80&sw=2000"
            },


            new Shoes()
            {
            Name = "Air Zoom Vapor Pro 2 All Court Shoe Men",
            Brand = Enums.Nike,
            Price = 130,
            SalePrice = 0,
            Quantity = 10,
           Rating = 4.7,
            Popular = true,
            Gender = true,
            Color = Enums.Black,
            Size = Enums.Shoes40,
            Description = "Elevate your performance on the court with Nike Shoes, the ultimate fusion of style and functionality. Designed for tennis enthusiasts and athletes, these shoes deliver unmatched comfort and support for intense gameplay. Crafted with precision and expertise, Nike Shoes offer a secure fit and superior traction, ensuring quick movements and stability on any surface. The sleek design and attention to detail make them a stylish choice both on and off the court. Whether you're sprinting to the net or engaging in intense rallies, Nike Shoes provide the perfect balance of comfort, durability, and performance. Step up your game and unleash your full potential with Nike Shoes, the footwear of choice for champions.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw43c0e99d/images/004/162/17222000_0_1.jpg?q=80&sw=640"
            },

            new Shoes()
            {
            Name = "Air Zoom Vapor Pro 2 All Court Shoe Men",
            Brand = Enums.Nike,
            Price = 130,
            SalePrice = 0,
            Quantity = 10,
            Rating = 4.7,
            Popular = true,
            Gender = true,
            Color = Enums.Black,
            Size = Enums.Shoes41,
            Description = "Elevate your performance on the court with Nike Shoes, the ultimate fusion of style and functionality. Designed for tennis enthusiasts and athletes, these shoes deliver unmatched comfort and support for intense gameplay. Crafted with precision and expertise, Nike Shoes offer a secure fit and superior traction, ensuring quick movements and stability on any surface. The sleek design and attention to detail make them a stylish choice both on and off the court. Whether you're sprinting to the net or engaging in intense rallies, Nike Shoes provide the perfect balance of comfort, durability, and performance. Step up your game and unleash your full potential with Nike Shoes, the footwear of choice for champions.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw43c0e99d/images/004/162/17222000_0_1.jpg?q=80&sw=640"
            },


            new Shoes()
            {
            Name = "Air Zoom Vapor Pro 2 All Court Shoe Men",
            Brand = Enums.Nike,
            Price = 130,
            SalePrice = 0,
            Quantity = 10,
            Rating = 4.7,
            Popular = true,
            Gender = true,
            Color = Enums.Red,
            Size = Enums.Shoes41,
            Description = "Elevate your performance on the court with Nike Shoes, the ultimate fusion of style and functionality. Designed for tennis enthusiasts and athletes, these shoes deliver unmatched comfort and support for intense gameplay. Crafted with precision and expertise, Nike Shoes offer a secure fit and superior traction, ensuring quick movements and stability on any surface. The sleek design and attention to detail make them a stylish choice both on and off the court. Whether you're sprinting to the net or engaging in intense rallies, Nike Shoes provide the perfect balance of comfort, durability, and performance. Step up your game and unleash your full potential with Nike Shoes, the footwear of choice for champions.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw876f7d3b/images/004/162/17224000_0_1.jpg?q=80&sw=2000"
            },


            new Shoes()
            {
            Name = "Air Zoom Vapor Pro 2 All Court Shoe Men",
            Brand = Enums.Nike,
            Price = 130,
            SalePrice = 0,
            Quantity = 10,
            Rating = 4.7,
            Popular = true,
            Gender = true,
            Color = Enums.White,
            Size = Enums.Shoes42,
            Description = "Elevate your performance on the court with Nike Shoes, the ultimate fusion of style and functionality. Designed for tennis enthusiasts and athletes, these shoes deliver unmatched comfort and support for intense gameplay. Crafted with precision and expertise, Nike Shoes offer a secure fit and superior traction, ensuring quick movements and stability on any surface. The sleek design and attention to detail make them a stylish choice both on and off the court. Whether you're sprinting to the net or engaging in intense rallies, Nike Shoes provide the perfect balance of comfort, durability, and performance. Step up your game and unleash your full potential with Nike Shoes, the footwear of choice for champions.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw792b0d75/images/004/162/17225000_0_1.jpg?q=80&sw=2000"
            },


            new Shoes()
            {
            Name = "Air Zoom Vapor Pro 2 All Court Shoe Men",
            Brand = Enums.Nike,
            Price = 85,
            SalePrice = 0,
            Quantity = 10,
            Rating = 4.7,
            Popular = true,
            Gender = false,
            Color = Enums.Red,
            Size = Enums.Shoes40,
            Description = "Elevate your performance on the court with Nike Shoes, the ultimate fusion of style and functionality. Designed for tennis enthusiasts and athletes, these shoes deliver unmatched comfort and support for intense gameplay. Crafted with precision and expertise, Nike Shoes offer a secure fit and superior traction, ensuring quick movements and stability on any surface. The sleek design and attention to detail make them a stylish choice both on and off the court. Whether you're sprinting to the net or engaging in intense rallies, Nike Shoes provide the perfect balance of comfort, durability, and performance. Step up your game and unleash your full potential with Nike Shoes, the footwear of choice for champions.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw100c327d/images/004/163/17373000_0_1.jpg?q=80&sw=640"
            },

            new Shoes()
            {
            Name = "Air Zoom Vapor Pro 2 All Court Shoe Men",
            Brand = Enums.Nike,
            Price = 85,
            SalePrice = 0,
            Quantity = 10,
            Rating = 4.7,
            Popular = true,
            Gender = false,
            Color = Enums.Black,
            Size = Enums.Shoes42,
            Description = "Elevate your performance on the court with Nike Shoes, the ultimate fusion of style and functionality. Designed for tennis enthusiasts and athletes, these shoes deliver unmatched comfort and support for intense gameplay. Crafted with precision and expertise, Nike Shoes offer a secure fit and superior traction, ensuring quick movements and stability on any surface. The sleek design and attention to detail make them a stylish choice both on and off the court. Whether you're sprinting to the net or engaging in intense rallies, Nike Shoes provide the perfect balance of comfort, durability, and performance. Step up your game and unleash your full potential with Nike Shoes, the footwear of choice for champions.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw0923cee8/images/004/163/17371000_0_1.jpg?q=80&sw=640"
            },

            new Shoes()
            {
            Name = "Air Zoom Vapor Pro 2 All Court Shoe Men",
            Brand = Enums.Nike,
            Price = 85,
            SalePrice = 0,
            Quantity = 10,
            Rating = 4.7,
            Popular = true,
            Gender = false,
            Color = Enums.Blue,
            Size = Enums.Shoes405,
            Description = "Elevate your performance on the court with Nike Shoes, the ultimate fusion of style and functionality. Designed for tennis enthusiasts and athletes, these shoes deliver unmatched comfort and support for intense gameplay. Crafted with precision and expertise, Nike Shoes offer a secure fit and superior traction, ensuring quick movements and stability on any surface. The sleek design and attention to detail make them a stylish choice both on and off the court. Whether you're sprinting to the net or engaging in intense rallies, Nike Shoes provide the perfect balance of comfort, durability, and performance. Step up your game and unleash your full potential with Nike Shoes, the footwear of choice for champions.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw7405cc7d/images/004/163/17372000_0_1.jpg?q=80&sw=640"
            },


            //adidas shoes
            new Shoes()
            {
            Name = "Barricade Clay Court Shoe Men",
            Brand = Enums.Adidas,
            Price = 150,
            SalePrice = 120,
            Quantity = 10,
            Rating = 4.3,
            Popular = true,
            Gender = true,
            Color = Enums.Red,
            Size = Enums.Shoes41,
            Description = "Elevate your performance on the court with Adidas Shoes, the ultimate fusion of style and functionality. Designed for tennis enthusiasts and athletes, these shoes deliver unmatched comfort and support for intense gameplay. Crafted with precision and expertise, AdidasShoes offer a secure fit and superior traction, ensuring quick movements and stability on any surface. The sleek design and attention to detail make them a stylish choice both on and off the court. Whether you're sprinting to the net or engaging in intense rallies, Adidas Shoes provide the perfect balance of comfort, durability, and performance. Step up your game and unleash your full potential with Adidas Shoes, the footwear of choice for champions.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw66cc1a72/images/005/162/05748000_0_1.jpg?q=80&sw=640"
            },

            new Shoes()
            {
            Name = "Barricade Clay Court Shoe Men",
            Brand = Enums.Adidas,
            Price = 150,
            SalePrice = 120,
            Quantity = 10,
            Rating = 4.3,
            Popular = true,
            Gender = true,
            Color = Enums.Blue,
            Size = Enums.Shoes405,
            Description = "Elevate your performance on the court with Adidas Shoes, the ultimate fusion of style and functionality. Designed for tennis enthusiasts and athletes, these shoes deliver unmatched comfort and support for intense gameplay. Crafted with precision and expertise, AdidasShoes offer a secure fit and superior traction, ensuring quick movements and stability on any surface. The sleek design and attention to detail make them a stylish choice both on and off the court. Whether you're sprinting to the net or engaging in intense rallies, Adidas Shoes provide the perfect balance of comfort, durability, and performance. Step up your game and unleash your full potential with Adidas Shoes, the footwear of choice for champions.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw47252ae8/images/005/158/05407000_0_1.jpg?q=80&sw=2000"
            },

            new Shoes()
            {
            Name = "Barricade Clay Court Shoe Men",
            Brand = Enums.Adidas,
            Price = 150,
            SalePrice = 120,
            Quantity = 10,
            Rating = 4.3,
            Popular = true,
            Gender = true,
            Color = Enums.Black,
            Size = Enums.Shoes41,
            Description = "Elevate your performance on the court with Adidas Shoes, the ultimate fusion of style and functionality. Designed for tennis enthusiasts and athletes, these shoes deliver unmatched comfort and support for intense gameplay. Crafted with precision and expertise, AdidasShoes offer a secure fit and superior traction, ensuring quick movements and stability on any surface. The sleek design and attention to detail make them a stylish choice both on and off the court. Whether you're sprinting to the net or engaging in intense rallies, Adidas Shoes provide the perfect balance of comfort, durability, and performance. Step up your game and unleash your full potential with Adidas Shoes, the footwear of choice for champions.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw91890a79/images/005/162/05753000_0_1.jpg?q=80&sw=640"
            },


            new Shoes()
            {
            Name = "Avacourt Clay Court Shoe Women",
            Brand = Enums.Adidas,
            Price = 150,
            SalePrice = 120,
            Quantity = 10,
            Rating = 4.7,
            Popular = true,
            Gender = false,
            Color = Enums.Red,
            Size = Enums.Shoes395,
            Description = "Elevate your performance on the court with Adidas Shoes, the ultimate fusion of style and functionality. Designed for tennis enthusiasts and athletes, these shoes deliver unmatched comfort and support for intense gameplay. Crafted with precision and expertise, AdidasShoes offer a secure fit and superior traction, ensuring quick movements and stability on any surface. The sleek design and attention to detail make them a stylish choice both on and off the court. Whether you're sprinting to the net or engaging in intense rallies, Adidas Shoes provide the perfect balance of comfort, durability, and performance. Step up your game and unleash your full potential with Adidas Shoes, the footwear of choice for champions.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw5d2d7c5b/images/005/162/05756000_0_1.jpg?q=80&sw=640"
            },

            new Shoes()
            {
            Name = "Avacourt Clay Court Shoe Women",
            Brand = Enums.Adidas,
            Price = 150,
            SalePrice = 120,
            Quantity = 10,
            Rating = 4.7,
            Popular = true,
            Gender = false,
            Color = Enums.Blue,
            Size = Enums.Shoes40,
            Description = "Elevate your performance on the court with Adidas Shoes, the ultimate fusion of style and functionality. Designed for tennis enthusiasts and athletes, these shoes deliver unmatched comfort and support for intense gameplay. Crafted with precision and expertise, AdidasShoes offer a secure fit and superior traction, ensuring quick movements and stability on any surface. The sleek design and attention to detail make them a stylish choice both on and off the court. Whether you're sprinting to the net or engaging in intense rallies, Adidas Shoes provide the perfect balance of comfort, durability, and performance. Step up your game and unleash your full potential with Adidas Shoes, the footwear of choice for champions.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw6052cf2d/images/005/160/05558000_0_1.jpg?q=80&sw=640"
            },

            new Shoes()
            {
            Name = "Avacourt Clay Court Shoe Women",
            Brand = Enums.Adidas,
            Price = 150,
            SalePrice = 120,
            Quantity = 10,
            Rating = 4.7,
            Popular = true,
            Gender = false,
            Color = Enums.Yellow,
            Size = Enums.Shoes405,
            Description = "Elevate your performance on the court with Adidas Shoes, the ultimate fusion of style and functionality. Designed for tennis enthusiasts and athletes, these shoes deliver unmatched comfort and support for intense gameplay. Crafted with precision and expertise, AdidasShoes offer a secure fit and superior traction, ensuring quick movements and stability on any surface. The sleek design and attention to detail make them a stylish choice both on and off the court. Whether you're sprinting to the net or engaging in intense rallies, Adidas Shoes provide the perfect balance of comfort, durability, and performance. Step up your game and unleash your full potential with Adidas Shoes, the footwear of choice for champions.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw47349318/images/005/158/05470000_0_1.jpg?q=80&sw=640"
            }
        };

        return shoes;
    }

    private List<Racket> GetRackets()
    {
        var rackets = new List<Racket>() {

            //head rackets
            new Racket()
            {
            Name = "Graphene 360 Radical MP Tour Racket",
            Brand = Enums.Head,
            Price = 250,
            SalePrice = 170,
            Quantity = 10,
            Rating = 4.7,
            Popular = true,
            Weight = Enums.Weight295,
            HeadSize = Enums.Head632,
            GripSize = Enums.Grip1,
            Description = "HEAD's Graphene 360 Radical MP is slightly lighter than the Pro and is designed specifically for all-court tournament players. With this tennis racket, every shot is a bull's-eye.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw7d572ab6/images/006/046/04033000_000.jpg?q=80&sw=640"
            },

            new Racket()
            {
            Name = "Extreme Team 2022 Tour Racket",
            Brand = Enums.Head,
            Price = 230,
            SalePrice = 170,
            Quantity = 10,
            Rating = 5.0,
            Popular = true,
            Weight = Enums.Weight275,
            HeadSize = Enums.Head645,
            GripSize = Enums.Grip2,
            Description = "When it comes to ingenious racquets, one name immediately pops into everyone's head - Extreme! HEAD's Extreme series, even recommended by Matteo Berrettini, combines design and performance like no other. The HEAD Extreme Team 2022 gets, as we are used to from HEAD, the innovative Auxetic technology for a perfect feel. Additional spin is generated by the shaft and unique spin grommets provide more string movement and a powerful trampoline effect. And if those aren't enough arguments to choose any HEAD Extreme Team, one look at the fresh design that sets this racquet apart is enough.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw3209150d/images/006/059/04190000_000.jpg?q=80&sw=640"
            },

            new Racket()
            {
            Name = "Graphene XT Speed MP 2022 Tour Racket",
            Brand = Enums.Head,
            Price = 240,
            SalePrice = 140,
            Quantity = 10,
            Rating = 4.5,
            Popular = true,
            Weight = Enums.Weight295,
            HeadSize = Enums.Head645,
            GripSize = Enums.Grip2,
            Description = "The Graphene XT Speed MP with GRAPHENE XT technology, combined with an open string pattern, makes this frame the first choice for versatile players who want more spin and power. The perfect blend of balance and weight ensures very good racket handling. The medium-sized racket head forgives the odd inaccurate shot and guarantees optimised control and force transfer.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwecf44d7f/images/006/059/04075000_000.jpg?q=80&sw=640"
            },

            //wilson rackets
            new Racket()
            {
            Name = "Pro Staff 97 CV Bronze Tour Racket",
            Brand = Enums.Wilson,
            Price = 260,
            SalePrice = 150,
            Quantity = 10,
            Rating = 4.8,
            Popular = true,
            Weight = Enums.Weight295,
            HeadSize = Enums.Head626,
            GripSize = Enums.Grip3,
            Description = "The Wilson Pro Staff 97 Countervail Black is the lighter version of tennis legend Roger Federer's RF97 Autograph design and also resembles it in its minimalist black and white look. Thanks to an improved carbon fiber technology in the frame, the racket is much lighter and feels better in the hand. This makes the Pro Staff 97 easier to swing and shines with great spin potential. The braided graphite provides a precise and consistent feel, which is essential for the decisive winner point. In addition, the braided construction reduces vibrations in the arm, so even messy shots won't affect the playing arm.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwe45f8e72/images/007/056/03677000_000.jpg?q=80&sw=640"
            },


            new Racket()
            {
            Name = "Clash 100 Pro (Tour) Tour Racket",
            Brand = Enums.Wilson,
            Price = 280,
            SalePrice = 160,
            Quantity = 10,
            Rating = 4.6,
            Popular = true,
            Weight = Enums.Weight295,
            HeadSize = Enums.Head645,
            GripSize = Enums.Grip2,
            Description = "The Wilson Clash 100 Pro has been perfected after years of work, so you get a unique racket. The combination of control and flexibility is what sets the Clash 100 Pro apart. Wilson achieves this through a grip-heavy balance with 3D Bending. This new frame technology with carbon mapping allows for completely new bending dimensions of the frame and along with it perfect ball pocketing. This unique frame geometry offers the best flexibility with maximum stability! Everything expected from a racket, the Clash 100 Pro has on board.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwd71f29ba/images/007/046/03394000_000.jpg?q=80&sw=640"
            },

            //babolat rackets
            new Racket()
            {
            Name = "Rafael Nadal Pure Aero Lite",
            Brand = Enums.Babolat,
            Price = 240,
            SalePrice = 170,
            Quantity = 10,
            Rating = 5.0,
            Popular = true,
            Weight = Enums.Weight275,
            HeadSize = Enums.Head645,
            GripSize = Enums.Grip2,
            Description = "Combativeness, resistance, mind of steel... you’re just like Rafa! It’s time to challenge your toughest adversaries with this Pure Aero in his name and colours, dominating the game with your power and lift.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw76d53cc7/images/009/055/02791000_000.jpg?q=80&sw=640"
            },


            new Racket()
            {
            Name = "Boost Strike",
            Brand = Enums.Babolat,
            Price = 110,
            SalePrice = 0,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Weight = Enums.Weight285,
            HeadSize = Enums.Head645,
            GripSize = Enums.Grip1,
            Description = "Smash, serve, volley, hit winners, drop shots… Whether you’re new to tennis or restarting it with new ambitions, the Boost Strike will help you to do it all. And even better, it performs all of the above at a price that’s affordable for any player’s budget.",
            Img = "https://global.tennis-point.com/dw/image/v2/BBDP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw4b13b02f/images/009/050/02723000_000.jpg?q=80&sw=640"
            }
        };

        return rackets;
    }
}