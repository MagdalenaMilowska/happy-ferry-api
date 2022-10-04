using FerryApi.Models;

namespace FerryApi.Interface
{
    public interface IVehicleValidator
    {
        bool ValidateVehicle(Vehicle vehicle);
    }
}
