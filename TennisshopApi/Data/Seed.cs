public class Seed {
    private readonly Context _context;
    public Seed(Context context) {
        _context = context;
    }

    public void SeedContext() {

        // accessory
        Accessory accessory = new Accessory() {
            Name = "Roger Federer DNA Racket Bag",
            Brand = "Wilson",
            Price = 89.95,
            SalePrice = 0,
            Quantity = 10,
            Rating = 4.7,
            Popular = true,
            Type = "Bag",
            Color = "Red",
            Size = "L"
        };

        // clothing
        Clothing clothing = new Clothing() {
            Name = "Dri-Fit Court Slam RG T-Shirt Men",
            Brand = "Nike",
            Price = 74.95,
            SalePrice = 0,
            Quantity = 10,
            Rating = 0,
            Popular = false,
            Type = "Shirt",
            Gender = true,
            Color = "Lilac",
            Size = "M"
        };

        // shoes
        Shoes shoes = new Shoes() {
            Name = "Solution Swift FF All Court Shoe Women",
            Brand = "Asics",
            Price = 89.95,
            SalePrice = 0,
            Quantity = 5,
            Rating = 4.2,
            Popular = true,
            Gender = false,
            Color = "White",
            Size = 39
        };

        // racket
        Racket racket = new Racket() {
            Name = "Graphene 360 Radical MP Tour Racket",
            Brand = "Head",
            Price = 169.95,
            SalePrice = 0,
            Quantity = 5,
            Rating = 4.7,
            Popular = true,
            Weight = 295,
            HeadSize = 630,
            GripSize = 2
        };

        // new arrivals
        NewArrivals newArrivals = new NewArrivals() {
            Items = new List<ShopItem>() {racket}
        };


        // top sellers
        TopSeller topSeller = new TopSeller() {
            Items = new List<ShopItem>() {clothing, shoes}
        };

        // address
        Address address = new Address() {
            Country = "Denmark",
            City = "Horsens",
            PostalCode = "8700",
            Street = "Borgergade 12",
            ApartmentNo = 15
        };

        // payment method
        PaymentMethod paymentMethod = new PaymentMethod() {
            Name = "MasterCard",
            Number = 5170253685781452,
            Valid = new DateTime(2025,12,31)
        };

        // order
        Order order = new Order() {
            OrderNo = "Ord235698",
            Date = new DateTime(2023, 3, 27),
            Total = 244.9,
            OrderStatus = "Delivered",
            Items = new List<OrderItem>() {
                new OrderItem() {
                    Item = racket,
                    Quantity = 1
                },
                new OrderItem() {
                    Item = clothing,
                    Quantity = 1
                }
            }
        };

        // user
        User user = new User() {
            Name = "Fernando de Silva",
            Email = "fernandosilva@gmail.com",
            Address = address,
            OrderHistory = new List<Order>() {order},
            PaymentMethod = paymentMethod
        };


        // add data to context
        _context.Accessories.Add(accessory);
        _context.Shoes.Add(shoes);
        _context.Clothings.Add(clothing);
        _context.Rackets.Add(racket);
        _context.NewArrivals.Add(newArrivals);
        _context.TopSellers.Add(topSeller);
        _context.Addresses.Add(address);
        _context.PaymentMethods.Add(paymentMethod);
        _context.Orders.Add(order);
        _context.Users.Add(user);
        _context.SaveChanges();

    }
}