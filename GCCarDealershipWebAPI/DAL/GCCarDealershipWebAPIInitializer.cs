using GCCarDealership.Domain.Models;
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
            context.Cars.Add(new CarModel()
            {
                Id = 2,
                Make = "Audi",
                Model = "S8",
                Year = 2018,
                Color = "Silver"
            });
            context.Cars.Add(new CarModel()
            {
                Id = 3,
                Make = "Volkswagen",
                Model = "GTI",
                Year = 2010,
                Color = "Silver"
            });
            context.Cars.Add(new CarModel()
            {
                Id = 4,
                Make = "BMW",
                Model = "M6",
                Year = 2018,
                Color = "Red"
            });
            context.Cars.Add(new CarModel()
            {
                Id = 5,
                Make = "Audi",
                Model = "A6",
                Year = 2017,
                Color = "Black"
            });
            context.Cars.Add(new CarModel()
            {
                Id = 6,
                Make = "Volkswagen",
                Model = "R32",
                Year = 2017,
                Color = "Blue"
            });
            context.Cars.Add(new CarModel()
            {
                Id = 7,
                Make = "Volkswagen",
                Model = "Tiguan",
                Year = 2010,
                Color = "Red"
            });
            context.Cars.Add(new CarModel()
            {
                Id = 8,
                Make = "Maserati",
                Model = "GranTurismo",
                Year = 2018,
                Color = "Black"
            });
            context.Cars.Add(new CarModel()
            {
                Id = 9,
                Make = "Maserati",
                Model = "Quattroporte",
                Year = 2017,
                Color = "Silver"
            });
            context.Cars.Add(new CarModel()
            {
                Id = 10,
                Make = "Mercedes",
                Model = "AMG GT",
                Year = 2014,
                Color = "Blue"
            });
            context.SaveChanges();

            base.Seed(context);
        }
    }
}