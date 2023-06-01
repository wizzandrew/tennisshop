public class TopSeller {
    public int Id { get; set; }
    public ICollection<ShopItem> Items { get; set; }
}