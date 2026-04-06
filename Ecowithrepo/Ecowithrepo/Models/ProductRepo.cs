
namespace Ecowithrepo.Models
{
    public class ProductRepo : IProduct
    {
        public readonly Context c;
        public ProductRepo()
        {
            c = new Context();
        }
        public void Add(Product product)
        {
c.Products.Add(product);
            c.SaveChanges();
        }

        public void Delete(int id)
        {
            var v = c.Products.Find(id);
            if(v != null)
            {
                c.Products.Remove(v);
                c.SaveChanges();
            }
        }

        public List<Product> GetAll()
        {
            return c.Products.ToList();
        }

        public Product GetById(int id)
        {
            return c.Products.Find(id);
        }

        public void Update(Product product)
        {
           c.Products.Update(product);
            c.SaveChanges();
        }
    }
}
