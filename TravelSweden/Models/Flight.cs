using System.ComponentModel.DataAnnotations;

namespace TravelSweden.Models
{
    public class Flight
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime DepartureTime { get; set; }
        [Required]
        public DateTime ArrivalTime { get; set; }
        [Required]
        public int RouteId { get; set; }
        public FlightRoute Route { get; set; }
        [Required]
        public string Airline { get; set; }

        public Flight()
        {

        }
    }
}
