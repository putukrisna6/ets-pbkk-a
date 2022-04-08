using System.ComponentModel.DataAnnotations;

namespace TravelSweden.Models
{
    public class Airport
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Iata { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }

        public Airport()
        {

        }
    }
}
