using GoHappy.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GoHappy.API.Data
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)    
        {
                
        }

        public DbSet<Listing> Listings { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
