using FerryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FerryApi.Repositories
{
    public class ParkingRepository : IParkingRepository
    {
        public List<Parking> GetParkings()
        {
            using (var context = new FerryContext())
            {
                return context.ParkingSpots.ToList();
            }
        }

        public string AddVehicle(Vehicle vehicle)
        {
            using (var context = new FerryContext())
            {
                var vehicleSize = (int)vehicle.VehicleType;
                var parking = context.ParkingSpots.FirstOrDefault(parkingSpot => parkingSpot.Size == vehicleSize && !parkingSpot.IsParked);

                if (parking != null)
                {
                    parking.IsParked = true;
                    parking.LicensePlateId = vehicle.LicensePlateId;
                    context.Update(parking);
                    context.Update(vehicle);
                    context.Vehicles.Add(vehicle);
                    context.SaveChanges();
                    return parking.SpaceName;
                }

                return null;
            }
        }

        public List<string> StartFerry()
        {
            using (var context = new FerryContext())
            {
                var takenSpots = GetTakenSpots();
                var parkedCarsLicensePlates = takenSpots.Select(x =>x.LicensePlateId).ToList();

                foreach (var parking in takenSpots)
                {
                    parking.IsParked = false;
                    parking.LicensePlateId = null;
                    context.Entry(parking).State = EntityState.Modified;
                }

                context.SaveChanges();

                return parkedCarsLicensePlates;
            }
        }

        public List<Parking> GetTakenSpots()
        {
            using (var context = new FerryContext())
            {
                return context.ParkingSpots.Where(x => x.IsParked).ToList();
            }
        }

        public List<Parking> GetFreeSpots()
        {
            using (var context = new FerryContext())
            {
                return context.ParkingSpots.Where(x => !x.IsParked).ToList();
            }
        }

        public Parking CheckParkingSpot(string parkingName)
        {        
            using (var context = new FerryContext())
            {
                var checkedParking = context.ParkingSpots.FirstOrDefault(checkedSpot => checkedSpot.SpaceName == parkingName);

                if(checkedParking != null)
                {
                    return checkedParking;
                } 
                
                return null;
            }
        }
    }
}
