
namespace Ecowithrepo.Models
{
    public class CustomerRepo  : ICustomer
    {
        public readonly Context c;
        public CustomerRepo()
        {
            c = new Context();
        }

        public List<Customer> GetAll()
        {
            return c.Customers.ToList();
        }
        public void Add(Customer customer)
        {
            c.Customers.Add(customer);
            c.SaveChanges();
        }

        public void Delete(int id)
        {
            var cv  = c.Customers.Find(id);
            if (cv != null)
            {
                c.Customers.Remove(cv);
                c.SaveChanges();
            }
        }


        public Customer GetById(int id)
        {
            return c.Customers.Find(id);
        }

        public void Update(Customer customer)
        {
            c.Customers.Update(customer);
            c.SaveChanges();
        }
    }
}
