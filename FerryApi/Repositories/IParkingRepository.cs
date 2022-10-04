using FerryApi.Models;

namespace FerryApi.Repositories
{
    public interface IParkingRepository
    {
        public List<Parking> GetParkings();

        public string AddVehicle(Vehicle vehicle);

        public List<string> StartFerry();

        public List<Parking> GetTakenSpots();

        public List<Parking> GetFreeSpots();

        public Parking CheckParkingSpot(string parkingName);
    }
}