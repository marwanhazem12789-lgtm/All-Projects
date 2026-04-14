namespace Demo2.Models
{
    public interface ICategory
    {
        List<Category> Getall();
        void AddCategory(Category category);
         void UpdateCategory(Category category);
         void DeleteCategory(int id);
        Category GetCategoryById(int id);

    }
}
