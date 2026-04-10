using Demo2Web.Models;
using System.Runtime.InteropServices;

namespace Demo2Web.Repos.Faces
{
    public interface ICategory
    {
        List<Category> GetAll();
        void add(Category category);
        void Updat(Category category);
        void delete(int Id);
        Category GetById (int Id);
    }
}
