using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TravelSweden.Models;

namespace TravelSweden.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TravelSweden.Models.Airport> Airport { get; set; }
        public DbSet<TravelSweden.Models.FlightRoute> FlightRoute { get; set; }
        public DbSet<TravelSweden.Models.Flight> Flight { get; set; }
    }
}