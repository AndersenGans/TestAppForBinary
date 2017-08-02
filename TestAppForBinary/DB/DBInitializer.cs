using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TestAppForBinary.Models;

namespace TestAppForBinary.DB
{
    public static class DBInitializer
    {
        public static void Initialize(DBContext context)
        {
            context.Database.Migrate();

            if(context.Manufacturers.Any())
                return;

            var manufacturers = new List<Manufacturer>();
            var cars = new List<Car>();

            manufacturers.AddRange(new List<Manufacturer>
            {
                new Manufacturer { Name = "Škoda Auto", GenDirector = "Bernhard Maier", HoldingCompany = "Volkswagen AG", WebSite = "www.skoda-auto.com"},
                new Manufacturer { Name = "Rolls-Royce Motor Cars", GenDirector = "David Warren Arthur East", HoldingCompany = "BMW AG", WebSite = "rolls-roycemotorcars.com"},
                new Manufacturer { Name = "Mercedes-Benz", GenDirector = "Dieter Zetsche", HoldingCompany = "Daimler AG", WebSite = "mercedes-benz.de"}
            });

            cars.AddRange(new List<Car>
            {
                new Car {Name = "Škoda Rapid (2017)", ManufacturerId = 1, Class = "Sedan", BodyStyle = "4-door Sedan"},
                new Car {Name = "Škoda Superb B5", ManufacturerId = 1, Class = "Large family car", BodyStyle = "4-door saloon"},
                new Car {Name = "Rolls-Royce 101EX", ManufacturerId = 2, Class = "Luxury car", BodyStyle = "2-door coupe"},
                new Car {Name = "Rolls-Royce Phantom VII", ManufacturerId = 2, Class = "Full-size luxury car", BodyStyle = "4-door saloon"},
                new Car {Name = "Mercedes-Benz SLR McLaren", ManufacturerId = 3, Class = "Grand tourer ", BodyStyle = "2-door coupé"},
                new Car {Name = "Mercedes-Benz W213", ManufacturerId = 3, Class = "	Mid-size luxury car", BodyStyle = "	4-door saloon"}
            });

            foreach (var manufacturer in manufacturers)
            {
                context.Manufacturers.Add(manufacturer);
                context.SaveChanges();
            }

            foreach (var car in cars)
            {
                context.Cars.Add(car);
                context.SaveChanges();
            }

            

        }
    }
}