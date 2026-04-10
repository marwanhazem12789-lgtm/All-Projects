using Demo2Web.Models;
using Demo2Web.Repos.Faces;

namespace Demo2Web.Repos.Implemen
{
    public class CategoryRepo : ICategory
    {
        public readonly Context c;
        public CategoryRepo(Context cc)
        {
            this.c = cc;
        }

        public void add(Category category)
        {
            c.Categories.Add(category);
            c.SaveChanges();
        }

        public void delete(int Id)
        {
            var d = c.Categories.Find(Id);
            if (d != null)
            {
                c.Categories.Remove(d);
                c.SaveChanges();
            }

        }

        public List<Category> GetAll()
        {
            return c.Categories.ToList();
        }

        public Category GetById(int Id)
        {
            return c.Categories.Find(Id);
        }

        public void Updat(Category category)
        {
            var d = c.Categories.Find(category.Id);
            if (d != null)
            {
                d.Name = category.Name;
                c.Categories.Update(d);
                c.SaveChanges();
            }
        }
    }
}
