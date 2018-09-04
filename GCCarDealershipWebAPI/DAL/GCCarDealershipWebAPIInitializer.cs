using GCCarDealershipWebAPI.Models;
using System.Data.Entity;

namespace GCCarDealershipWebAPI.DAL
{
    public class GCCarDealershipWebAPIInitializer : CreateDatabaseIfNotExists<CarDbContext>
    {
        protected override void Seed(CarDbContext context)
        {
            context.Cars.Add(new CarModel()
            {
                Id = 1,
                Make = "BMW",
                Model = "M3",
                Year = 2016,
                Color = "Blue"
            });
        }
    }
}