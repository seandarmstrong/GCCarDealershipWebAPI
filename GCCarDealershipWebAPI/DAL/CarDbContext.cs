using GCCarDealership.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Diagnostics;

namespace GCCarDealershipWebAPI.DAL
{
    public class CarDbContext : DbContext

    {
        public CarDbContext() : base("GCCarDealershipWebAPI")
        {
            Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer(new GCCarDealershipWebAPIInitializer());
            Database.Log = message => Trace.WriteLine(message);
        }

        public DbSet<CarModel> Cars { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarModel>().HasKey(x => x.Id).Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}