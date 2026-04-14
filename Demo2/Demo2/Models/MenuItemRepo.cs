using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace Demo2.Models
{
    public class MenuItemRepo : IMenuItem
    {
        public readonly Context c;
        public MenuItemRepo()
        {
            c = new Context();

        }
        public void AddMenuItem(MenuItemVM menuItem)
        {
            MenuItem m = new MenuItem()
            {
                Name = menuItem.Name,
                Price = menuItem.Price,
                CategoryId = menuItem.CategoryId
                
            };
            c.MenuItems.Add(m);
            c.SaveChanges();
        }
        public void DeleteMenuItem(int id)
        {
            MenuItem m = c.MenuItems.Find(id);
            c.MenuItems.Remove(m);
            c.SaveChanges();
        }
        public void UpdateMenuItem(MenuItemVM menuItem)
        {
            MenuItem m = c.MenuItems.Find(menuItem.Id);
            m.Name = menuItem.Name;
            m.Price = menuItem.Price;
            m.CategoryId = menuItem.CategoryId;
            c.SaveChanges();
        }


        public List<MenuItem> menuItems()
        {
            return c.MenuItems.Include(mu => mu.Category).ToList();
        }

        MenuItem IMenuItem.GetMenuItemById(int id)
        {
            var m = c.MenuItems.Find(id);
            return m;
        }
    }
}
