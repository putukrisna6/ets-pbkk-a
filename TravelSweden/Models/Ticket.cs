using System.ComponentModel.DataAnnotations;

namespace TravelSweden.Models
{
    public class Ticket
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int BookedTicketId { get; set; }
        public AvailableTicket BookedTicket { get; set; }
        public string PassengerName { get; set; }
        public string PassengerId { get; set; }
        public string PassengerAddress { get; set; }
        public bool IsPaid { get; set; }

        public Ticket()
        {

        }
    }
}
