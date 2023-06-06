public interface IUserRepository
{
    public User GetUser();
    public bool CreateOrder(Order order);
}