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

}