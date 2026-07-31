using GymSys.Configurations;
using GymSys.Models;
using Microsoft.EntityFrameworkCore;

namespace GymSys.DbContexts
{
    public class GymDbContext: DbContext
    {
        public GymDbContext(DbContextOptions<GymDbContext> options)
            : base(options)
        {
            
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=GymSysDb;Trusted_Connection=true;TrustServerCertificate=true;");
        //}


        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Plan>(new PlanConfiguration());
        }

        public DbSet<Plan> Plans { get; set; }




    }
}
