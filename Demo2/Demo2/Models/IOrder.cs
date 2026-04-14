namespace Demo2.Models
{
    public interface IOrder
    {
        List<Order> orders();
        void AddOrder(OrderVM order);
         void UpdateOrder(OrderVM order);
         void DeleteOrder(int id);
        Order GetOrderById(int id);
    }
}
