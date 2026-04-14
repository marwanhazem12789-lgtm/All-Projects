using Hotel.Models;
using System.ComponentModel.DataAnnotations;

public class BookingRecord
{
    [Key]
    public int Id { get; set; }
    public double TotalCost { get; set; }
    public DateOnly CheckInDate { get; set; }
    public DateOnly CheckoutDate { get; set; }
    public string Notes { get; set; }

    public int ? RoomId { get; set; }
    public Room Room { get; set; } 

    public int ? UserId { get; set; }
    public User User { get; set; }

    public int ? ServiceTypeId { get; set; }
    public ServiceType ServiceType { get; set; } 
}