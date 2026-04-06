using Ecowithrepo.Models;
using Microsoft.EntityFrameworkCore;

public class OrderRepo : IOrder
{
    private readonly Context c = new Context();

    public List<Order> GetAll() => c.Orders.Include(o => o.Customer).ToList();

    public void Add(OrderViewModel ovm)
    {
        var order = new Order
        {
            CustomerID = ovm.SelectedCustomerId,
            OrderDate = DateTime.Now,
            TotalAmount = ovm.Products.Where(p => p.Quantity > 0).Sum(p => p.Price * p.Quantity)
        };
        c.Orders.Add(order);
        c.SaveChanges();

        foreach (var item in ovm.Products.Where(p => p.Quantity > 0))
        {
            c.OrderItems.Add(new OrderItem
            {
                OrderID = order.OrderID,
                ProductID = item.ProductId,
                Quantity = item.Quantity,
                UnitPrice = item.Price
            });
        }
        c.SaveChanges();
    }
  
}