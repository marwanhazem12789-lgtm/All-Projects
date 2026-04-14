
namespace Demo2.Models
{
    public class CategoryRepo : ICategory
    {
        public readonly Context c;
       
        public CategoryRepo()
        {
            c = new Context();
        }
        public void AddCategory(Category category)
        {
            c.Categories.Add(category);
            c.SaveChanges();
        }
        public void UpdateCategory(Category category)
        {
            Category c1 = c.Categories.Find(category.Id);
            c1.Name = category.Name;
            c.SaveChanges();
        }
        public void DeleteCategory(int id)
        {
            Category c1 = c.Categories.Find(id);
            c.Categories.Remove(c1);
            c.SaveChanges();
        }

        public Category GetCategoryById(int id)
        {
            Category c1 = c.Categories.Find(id);
            return c1;
        }

        public List<Category> Getall()
        {
            return c.Categories.ToList();
        }
    }
}
