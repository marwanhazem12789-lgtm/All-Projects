namespace Demo2.Models
{
    public interface IMenuItem
    {
        List<MenuItem> menuItems();
        void AddMenuItem(MenuItemVM menuItem);
         void UpdateMenuItem(MenuItemVM menuItem);
         void DeleteMenuItem(int id);
        MenuItem GetMenuItemById(int id);
    }
}
