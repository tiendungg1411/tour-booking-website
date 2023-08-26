using Around_VietNam_Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Around_VietNam_Web.Data
{
    public class VieAroundDbContext : IdentityDbContext<AppUser>
    {
        public VieAroundDbContext(DbContextOptions<VieAroundDbContext> option) : base(option) 
        {
            
        }

        public DbSet<Models.Areas> Areas { get; set; }
        public DbSet<TouristAreas> TouristAreas { get; set; }
        public DbSet<ImageDetails> ImageDetails { get; set; }
    }
}
