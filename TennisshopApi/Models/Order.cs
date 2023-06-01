public class Order{
    public int Id { get; set; }
    public string OrderNo { get; set; }
    public DateTime Date { get; set; }
    public double Total { get; set; }
    public string OrderStatus { get; set; }
    public ICollection<OrderItem> Items { get; set; }
}