using System.ComponentModel.DataAnnotations;

namespace TravelSweden.Models
{
    public class Ticket
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int BookedFlightId { get; set; }
        public Flight BookedFlight { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public double Price { get; set; }
        public string PassengerName { get; set; }
        public string PassengerId { get; set; }
        public string PassengerAddress { get; set; }
        public bool IsPaid { get; set; }

        public Ticket()
        {

        }
    }
}
