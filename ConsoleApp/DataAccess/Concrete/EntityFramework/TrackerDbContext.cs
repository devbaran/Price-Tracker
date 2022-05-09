using DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class TrackerDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ShoppingDatabase;Trusted_Connection=true");
            //optionsBuilder.UseSqlServer(@"YOUR_CONNECTION_STRING");
        }

        public DbSet<UserProductTracker> UserProductTrackers { get; set; }
    }
}
