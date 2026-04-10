namespace Demo2Web.Models
{
    public class MenuItemVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Category> Categories { get; set; }   = new List<Category>();
        public int CategoryId { get; set; }
        public double Price { get; set; }
        public Category category { get; set; }

    }
}
