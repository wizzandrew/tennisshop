using Microsoft.EntityFrameworkCore;
public class OrderRepository : IOrderRepository
{
    private readonly Context _context;

    public OrderRepository(Context context)
    {
        _context = context;
    }

    public bool OrderExists(CreateOrder order)
    {
        return _context.Orders.Where(o => o.OrderNo == order.OrderNo).Any();
    }

    public bool SufficientOrderItems(CreateOrder order)
    {

        // map through array of OrderItems to see if requested quantity can be served
        // do no tracking to ShopItems
        for (int j = 0; j < order.Items.Count; j++)
        {
            var OrderItem = _context.ShopItems.AsNoTracking().Where(i => i.Id == order.Items.ElementAt(j).Item.Id).FirstOrDefault();
            if (OrderItem == null || OrderItem.Quantity - order.Items.ElementAt(j).Quantity < 0)
            {
                return false;
            }
        }

        return true;
    }

    public void ManageOrderItemsQuantity(CreateOrder order)
    {

        // map through array of OrderItems and update quantity in stock
        // do no tracking to ShopItems
        // set state to Detached after saving changes to db

        for (int j = 0; j < order.Items.Count; j++)
        {
            var shopItem = _context.ShopItems.AsNoTracking().Where(i => i.Id == order.Items.ElementAt(j).Item.Id).First();
            shopItem.Quantity = shopItem.Quantity - order.Items.ElementAt(j).Quantity;
            _context.ShopItems.Update(shopItem);
            _context.SaveChanges();
            _context.ShopItems.Entry(shopItem).State = EntityState.Detached;
        }
    }

    public void CreateOrder(CreateOrder order)
    {
        // get user
        var user = _context.Users.Where(u => u.Id == 1).First();

        // create order object
        var newOrder = new Order()
        {
            OrderNo = order.OrderNo,
            Date = order.Date,
            Total = order.Total,
            OrderStatus = order.OrderStatus,
            Items = order.Items,
            User = user
        };

        // track ShopItems by db to insert foreign (OrderItem has ShopItem)
        var shopItems = new List<ShopItem>();
        for (int i = 0; i < order.Items.Count; i++)
        {
            shopItems.Add(order.Items.ElementAt(i).Item);
        }

        _context.ShopItems.AttachRange(shopItems);

        _context.Orders.Add(newOrder);
        _context.SaveChanges();
    }

}