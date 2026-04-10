using Demo2Web.Models;
using Demo2Web.Repos.Faces;
using Microsoft.EntityFrameworkCore;

namespace Demo2Web.Repos.Implemen
{
    public class OrderRepo : IOrder
    {
        public readonly Context c;
        public OrderRepo(Context c)
        {
            this.c = c;
        }
        public void add(OrderVM order)
            {
                var data = new Order
                {
                    Id = order.Id,
                    OrderDate = DateOnly.FromDateTime(DateTime.Now),
                    Quantity = order.Quantity,
                    MenuItemId = order.MenuItemId
                };
                c.Orders.Add(data);
                c.SaveChanges();
        }
    
            public void delete(int Id)
            {
                var cda = c.Orders.Find(Id);
                if (cda != null)
                {
                    c.Orders.Remove(cda);
                    c.SaveChanges();
            }
        }

        public List<Order> GetAll()
        {
            return c.Orders.Include(c => c.menuItem).ToList();
        }
    
            public Order GetById(int Id)
            {
            return c.Orders.Include(c => c.menuItem).FirstOrDefault(m => m.Id == Id);
        }

        public void Update(OrderVM order)
        {
            var data = c.Orders.Find(order.Id);
            if(data != null)
            {
                data.Quantity = order.Quantity;
                data.MenuItemId = order.MenuItemId;
                data.OrderDate = DateOnly.FromDateTime(DateTime.Now);
               

                c.Orders.Update(data);
                c.SaveChanges();
            }
        }
    }
}
