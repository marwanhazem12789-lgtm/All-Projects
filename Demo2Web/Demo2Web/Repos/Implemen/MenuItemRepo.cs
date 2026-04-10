using Demo2Web.Models;
using Demo2Web.Repos.Faces;
using Microsoft.EntityFrameworkCore;

namespace Demo2Web.Repos.Implemen
{
    public class MenuItemRepo : IMenuItem
    {
        public readonly Context c;
        public MenuItemRepo(Context c)
        {
            this.c = c;
        }

        public List<MenuItem> GetAll()
        {
            return c.MenuItems.Include( m => m.category).ToList();
        }

        public MenuItem GetById(int Id)
        {
            return c.MenuItems.Include(Category => Category.category).FirstOrDefault(m => m.Id == Id);
        }

        public void add(MenuItemVM menuItem)
        {
            var data = new MenuItem
            {
                Id = menuItem.Id,
                Name = menuItem.Name,
                Price = menuItem.Price,
                CategoryId = menuItem.CategoryId

            };
            c.MenuItems.Add(data);
            c.SaveChanges();
        }
       
        public void Updat(MenuItemVM m)
        {
            var dat = c.MenuItems.Find(m.Id);
            if(dat != null)
            {
                dat.Name = m.Name;
                dat.Price = m.Price;
                dat.CategoryId = m.CategoryId;
                c.MenuItems.Update(dat);
                c.SaveChanges();
            }

        }

        public void delete(int Id)
        {
            var cda = c.MenuItems.Find(Id);
            if (cda != null)
            {
                c.MenuItems.Remove(cda);
                c.SaveChanges();
            }
        }
    }
}
