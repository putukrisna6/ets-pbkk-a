using System.ComponentModel.DataAnnotations;

namespace TravelSweden.Models
{
    public class FlightRoute
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public double Distance { get; set; }
        [Required]
        public int OriginAirportId { get; set; }
        public Airport OriginAirport { get; set; }
        [Required]
        public int DestAirportId { get; set; }
        public Airport DestAirport { get; set; }

        public FlightRoute()
        {

        }
    }
}
