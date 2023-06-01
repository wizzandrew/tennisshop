using Microsoft.EntityFrameworkCore;

public class Context : DbContext{

    public Context(DbContextOptions<Context> options) : base(options){

    }

    public DbSet<Accessory> Accessories {get;set;}
    public DbSet<Address> Addresses {get;set;}
    public DbSet<Clothing> Clothings {get;set;}
    public DbSet<NewArrivals> NewArrivals {get;set;}
    public DbSet<Order> Orders {get;set;}
    public DbSet<OrderItem> OrderItems {get;set;}
    public DbSet<PaymentMethod> PaymentMethods {get;set;}
    public DbSet<Racket> Rackets {get;set;}
    public DbSet<Shoes> Shoes {get;set;}
    public DbSet<ShopItem> ShopItems {get;set;}
    public DbSet<TopSeller> TopSellers {get;set;}
    public DbSet<User> Users {get;set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ShopItem>().UseTptMappingStrategy();
        
    }

}