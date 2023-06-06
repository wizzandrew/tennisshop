public interface IOrderRepository
{
    public bool OrderExists(CreateOrder order);
    public bool SufficientOrderItems(CreateOrder order);
    public void ManageOrderItemsQuantity(CreateOrder order);
    public void CreateOrder(CreateOrder order);
}