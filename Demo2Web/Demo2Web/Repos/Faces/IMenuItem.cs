using Demo2Web.Models;

namespace Demo2Web.Repos.Faces
{
    public interface IMenuItem
    {
        List<MenuItem> GetAll();
        void add(MenuItemVM menuItem);
        void Updat(MenuItemVM menuItem);
        void delete(int Id);
        MenuItem GetById (int Id);
    }
}
