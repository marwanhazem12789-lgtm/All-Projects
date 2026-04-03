using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Real_Orders.Models;

namespace Real_Orders.Controllers
{
    public class OrderController : Controller
    {
public readonly Context c;
        public OrderController()
        {
            c = new Context();
        }


        public IActionResult Index()
        {
            var data = c.Orders.Include(O => O.Customer).ToList();
            return View(data);
        }
        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            var data = c.Orders.Include(O => O.Customer).Include(O => O.OrderItems).ThenInclude(oi => oi.Product).FirstOrDefault(x => x.Id == id);
            if(data == null) { return NotFound(); }
            var dvm = new OrderDetailsViewModel
            {
                OrderId = data.Id,
                CustomerName = data.Customer.Name,
                TotalAmount = data.TotalAmount,
                OrderItems = data.OrderItems.Select(oi => new OrderItemDetailsViewModel
                {
                    ProductName = oi.Product.Name,
                    UnitPrice = oi.Product.Price,
                    Quantity = oi.Quantity
                }).ToList()
            };
            return View(dvm);
        }

        // GET: OrderController/Create
        [HttpGet]
        public IActionResult Create()
        {
            var data = new OrderViewModel
            {
                customers = c.Customers.ToList(),
                avvilableproducts = c.Products.Select(p => new avvilableproducts
                { 
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    StockQuantity = 0


                }).ToList()
            };

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OrderViewModel collection)
        { 
            var selectedProducts = collection.avvilableproducts.Where(p => p.StockQuantity > 0).ToList();

            if (selectedProducts.Any())
            {
                var order = new Order
                {
                    CustomerId = collection.CustomerId,
                    TotalAmount = selectedProducts.Sum(p => p.Price * p.StockQuantity)
                };

                c.Orders.Add(order);
                c.SaveChanges();
                foreach (var item in selectedProducts)
                {
                    var orderItem = new OrderItem
                    {
                        OrderId = order.Id, 
                        PrductId = item.Id,
                        Quantity = item.StockQuantity,
                        UnitPrice = item.Price 
                    };
                    c.OrderItems.Add(orderItem);
                }

                c.SaveChanges(); 
            }
            return RedirectToAction(nameof(Index));

        }

    }
}
