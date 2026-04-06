namespace Ecowithrepo.Models
{
    public interface IOrderItem
    {
        List<OrderItem> GetAll();
        OrderItem GetById(int id);
        void Add(OrderItem orderItem);
        void Update(OrderItem orderItem);
        void Delete(int id);
    }
}
