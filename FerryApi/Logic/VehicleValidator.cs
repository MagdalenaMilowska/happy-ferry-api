using FerryApi.Interface;
using FerryApi.Models;

namespace FerryApi.Logic
{
    public class VehicleValidator : IVehicleValidator
    {
        public bool ValidateVehicle(Vehicle vehicle)
        {
            var vehicleType = (int)vehicle.VehicleType;

            return vehicleType >= 1 && vehicleType <= 3 && vehicle.LicensePlateId.Length < 7;
        }
    }
}
