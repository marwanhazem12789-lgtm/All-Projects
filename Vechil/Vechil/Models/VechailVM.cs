using System.ComponentModel.DataAnnotations.Schema;

namespace Vechil.Models
{
    public class VechailVM
    {
        public int Id { get; set; }
        public List<User> users { get; set; } =  new List<User>();

        public string PlateNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        public int Year { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

    }
}
