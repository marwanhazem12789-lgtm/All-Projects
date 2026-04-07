using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Libirary_MVC_With_Repo.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
public string Authorname { get; set; }
public int AvailableCopies { get; set; }

        public List<Borrow> Borrows { get; set; } = new List<Borrow>();

    }
}
