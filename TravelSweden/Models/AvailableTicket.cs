using System.ComponentModel.DataAnnotations;

namespace TravelSweden.Models
{
    public class AvailableTicket
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int AttachedFlightId { get; set; }
        public Flight AttachedFlight { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public double Price { get; set; }
        public bool IsFreeLuggage { get; set; }
        public bool IsFreeFood { get; set; }
        public bool IsFreeCancellation { get; set; }

        public AvailableTicket()
        {

        }
    }
}
