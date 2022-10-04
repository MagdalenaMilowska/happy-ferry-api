using Microsoft.AspNetCore.Mvc;
using FerryApi.Models;
using FerryApi.Repositories;
using FerryApi.Interface;

namespace FerryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FerryController : ControllerBase
    {
        private readonly IParkingRepository _parkingRepository;
        private readonly IVehicleValidator _vehicleValidator;

        public FerryController(IParkingRepository parkingRepository, IVehicleValidator vehicleValidator)
        {
            _parkingRepository = parkingRepository;
            _vehicleValidator = vehicleValidator;
        }

        [HttpPost("/parking")]
        public ActionResult<Vehicle> PostVehicle(Vehicle vehicle)
        {
            var isVehicleValid = _vehicleValidator.ValidateVehicle(vehicle);
            if (!isVehicleValid)
            {
                return BadRequest("Please provide valid vehicle");
            }

            var parkingName =  _parkingRepository.AddVehicle(vehicle);
            if (parkingName == null)
            {
                return NotFound("There is no more parking spots to park, the car cannot enter the ferry");
            }

            return Ok(new { LicensePlates = vehicle.LicensePlateId, ParkingName = parkingName });
        }

        [HttpPut("/start")]
        public ActionResult<List<string>> StartFerryAndDisplayNameplates()
        {
            return Ok(_parkingRepository.StartFerry());
        }

        [HttpGet("/parking")]
        public ActionResult<List<Parking>> GetParkingState(string? state)
        {
            if (state is "taken") 
            { 
                return Ok(_parkingRepository.GetTakenSpots()); 
            } 
            else if (state is "free") 
            { 
                return Ok(_parkingRepository.GetFreeSpots()); 
            }

            return Ok(_parkingRepository.GetParkings());
        }

        [HttpGet("/parking/{parkingName}")]
        public ActionResult<Parking> CheckParkingSpot(string parkingName) 
        {
            var checkedParkingSpot = _parkingRepository.CheckParkingSpot(parkingName);

            if ( checkedParkingSpot == null)
            {
                return NotFound($"There is no parking spot with given name: '{parkingName}'. Please provide a correct one");
            }
            
            return checkedParkingSpot;
        }
    }
}
