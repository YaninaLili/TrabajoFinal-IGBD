using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace TrabajoFinal_IGBD.Models
{
    public class HotelContext : IdentityDbContext
    {
        public DbSet<Reserva> Reservas {get; set;}
        public DbSet<Habitacion> Habitaciones {get; set;}
        public HotelContext(DbContextOptions<HotelContext> o) : base(o) {

        }
    }
}