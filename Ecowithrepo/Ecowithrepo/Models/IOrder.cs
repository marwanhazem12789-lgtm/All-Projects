namespace Ecowithrepo.Models
{
    public interface IOrder
    {
        List<Order> GetAll();
        void Add(OrderViewModel order);

    }
}
