using Microsoft.EntityFrameworkCore;

namespace Demo2.Models
{
    public class OrderRepo : IOrder
    {
        public readonly Context c;
        public OrderRepo()
        {
            c = new Context();
        }
        public List<Order> orders()
        {
            return c.Orders.Include(c => c.MenuItem).ToList();
        }
        public void AddOrder(OrderVM order)
        {
            Order o = new Order()
            {
                Quantity = order.Quantity
                , Id = order.Id,
                OrderDate = DateOnly.FromDateTime(DateTime.Now),
                    MenuItemId = order.MenuItemId

            };
            c.Orders.Add(o);
            c.SaveChanges();
        }
        public void DeleteOrder(int id)
        {
            Order o = c.Orders.Find(id);
            c.Orders.Remove(o);
            c.SaveChanges();
        }
        public Order GetOrderById(int id)
        {
            Order o = c.Orders.Find(id);
            return o;
        }
        public void UpdateOrder(OrderVM order)
        {
            Order o = c.Orders.Find(order.Id);
            o.Quantity = order.Quantity;
            c.Orders.Update(o);
            c.SaveChanges();
        }

    
    }
}
