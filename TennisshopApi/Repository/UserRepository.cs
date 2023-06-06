using Microsoft.EntityFrameworkCore;
public class UserRepository : IUserRepository
{
    private readonly Context _context;

    public UserRepository(Context context)
    {
        _context = context;
    }

    public User GetUser()
    {
        return _context.Users.Include(u => u.Address).Include(u => u.PaymentMethod).FirstOrDefault();
    }

    public bool CreateOrder(Order order)
    {
        var orderExists = _context.Orders.Where(o => o.OrderNo == order.OrderNo).Any();

        if (orderExists)
        {
            return false;
        }
        else
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return true;
        }
    }

}