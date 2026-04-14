using Hotel.Models;
using Hotel.REPOS.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hotel.REPOS.Implement
{
    public class ServiceTyperepo : IServiceType
    {
        public readonly Context c;
        public ServiceTyperepo(Context c)
        {
            this.c = c;
        }


        public void add(ServiceTypeVM r)
        {
            var t = new ServiceType()
            {
                Id = r.Id,
                Name = r.Name,
                Price = r.Price,
                UserId = r.UserId,

            };
            c.serviceTypes.Add(t);
            c.SaveChanges();
        }

        public void delete(int r)
        {
            var t = c.serviceTypes.Find(r);
            if (t != null)
            {
                c.serviceTypes.Remove(t);
                c.SaveChanges();
            }


        }

        public ServiceType Get(int id)
        {
            return c.serviceTypes.Include(c => c.User).FirstOrDefault(r => r.Id == id);
        }

        public List<ServiceType> GetServices()
        {
            return c.serviceTypes.Include(c => c.User).ToList();  
        }

        public void Update(ServiceTypeVM r)
        {
            var t = c.serviceTypes.Find(r.Id);
            if (t != null)
            {
                t.Price = r.Price;
                t.UserId = r.UserId;
                t.Name = r.Name;
                
                c.serviceTypes.Update(t);
                c.SaveChanges();
            }
        }
    }
}
