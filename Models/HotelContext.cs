using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace TrabajoFinal_IGBD.Models
{
    public class HotelContext : IdentityDbContext
    {
        public HotelContext(DbContextOptions<HotelContext> o) : base(o) {

        }
    }
}