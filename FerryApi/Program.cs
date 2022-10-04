using FerryApi.Repositories;
using FerryApi.Models;
using FerryApi.Interface;
using FerryApi.Logic;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IParkingRepository, ParkingRepository>();
builder.Services.AddScoped<IVehicleValidator, VehicleValidator>();

var app = builder.Build();

SeedDatabase();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void SeedDatabase()
{
        using (var context = new FerryContext())
        {
            var parkingSpots = new List<Parking>
                {
                    new Parking
                    {
                        Size = 1,
                        Id = Guid.NewGuid(),
                        IsParked = false,
                        SpaceName = "a1",
                        TypeOfParkingSpot = VehicleType.Car
                    },
                    new Parking
                    {
                        Size = 1,
                        Id = Guid.NewGuid(),
                        IsParked = false,
                        SpaceName = "a2",
                        TypeOfParkingSpot = VehicleType.Car
                    },
                    new Parking
                    {
                        Size = 1,
                        Id = Guid.NewGuid(),
                        IsParked = false,
                        SpaceName = "a3",
                        TypeOfParkingSpot = VehicleType.Car
                    },
                    new Parking
                    {
                        Size = 1,
                        Id = Guid.NewGuid(),
                        IsParked = false,
                        SpaceName = "a4",
                        TypeOfParkingSpot = VehicleType.Car
                    },
                    new Parking
                    {
                        Size = 1,
                        Id = Guid.NewGuid(),
                        IsParked = false,
                        SpaceName = "a5",
                        TypeOfParkingSpot = VehicleType.Car
                    },
                    new Parking
                    {
                        Size = 1,
                        Id = Guid.NewGuid(),
                        IsParked = false,
                        SpaceName = "a6",
                        TypeOfParkingSpot = VehicleType.Car
                    },
                    new Parking
                    {
                        Size = 1,
                        Id = Guid.NewGuid(),
                        IsParked = false,
                        SpaceName = "a7",
                        TypeOfParkingSpot = VehicleType.Car
                    },
                    new Parking
                    {
                        Size = 1,
                        Id = Guid.NewGuid(),
                        IsParked = false,
                        SpaceName = "a8",
                        TypeOfParkingSpot = VehicleType.Car
                    },
                    new Parking
                    {
                        Size = 1,
                        Id = Guid.NewGuid(),
                        IsParked = false,
                        SpaceName = "a9",
                        TypeOfParkingSpot = VehicleType.Car
                    },
                    new Parking
                    {
                        Size = 1,
                        Id = Guid.NewGuid(),
                        IsParked = false,
                        SpaceName = "a10",
                        TypeOfParkingSpot = VehicleType.Car
                    }
                    ,
                    new Parking
                    {
                        Size = 2,
                        Id = Guid.NewGuid(),
                        IsParked = false,
                        SpaceName = "b1",
                        TypeOfParkingSpot = VehicleType.Truck
                    },
                    new Parking
                    {
                        Size = 2,
                        Id = Guid.NewGuid(),
                        IsParked = false,
                        SpaceName = "b2",
                        TypeOfParkingSpot = VehicleType.Truck
                    },
                    new Parking
                    {
                        Size = 2,
                        Id = Guid.NewGuid(),
                        IsParked = false,
                        SpaceName = "b3",
                        TypeOfParkingSpot = VehicleType.Truck
                    },
                    new Parking
                    {
                        Size = 2,
                        Id = Guid.NewGuid(),
                        IsParked = false,
                        SpaceName = "b4",
                        TypeOfParkingSpot = VehicleType.Truck
                    },
                    new Parking
                    {
                        Size = 2,
                        Id = Guid.NewGuid(),
                        IsParked = false,
                        SpaceName = "b5",
                        TypeOfParkingSpot = VehicleType.Truck
                    },
                    new Parking
                    {
                        Size = 2,
                        Id = Guid.NewGuid(),
                        IsParked = false,
                        SpaceName = "b6",
                        TypeOfParkingSpot = VehicleType.Truck
                    },
                    new Parking
                    {
                        Size = 2,
                        Id = Guid.NewGuid(),
                        IsParked = false,
                        SpaceName = "c1",
                        TypeOfParkingSpot = VehicleType.Bus
                    },
                    new Parking
                    {
                        Size = 2,
                        Id = Guid.NewGuid(),
                        IsParked = false,
                        SpaceName = "c2",
                        TypeOfParkingSpot = VehicleType.Bus
                    },
                    new Parking
                    {
                        Size = 2,
                        Id = Guid.NewGuid(),
                        IsParked = false,
                        SpaceName = "c3",
                        TypeOfParkingSpot = VehicleType.Bus
                    },
                    new Parking
                    {
                        Size = 3,
                        Id = Guid.NewGuid(),
                        IsParked = false,
                        SpaceName = "c4",
                        TypeOfParkingSpot = VehicleType.Bus
                    }
                };

            context.ParkingSpots.AddRange(parkingSpots);
            context.SaveChanges();
        }
    }

