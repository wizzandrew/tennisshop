public class User {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public Address Address { get; set; }
    public ICollection<Order> OrderHistory { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
}