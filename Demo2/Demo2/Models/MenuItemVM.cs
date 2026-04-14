namespace Demo2.Models
{
    public class MenuItemVM
    {
        public int Id { get; set; }
        public List<Category> Categores { get; set; } = new List<Category>();
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; } 
        public MenuItemVM()
        {
            Context c = new Context();
            Categores = c.Categories.ToList();
        }
    }
}
