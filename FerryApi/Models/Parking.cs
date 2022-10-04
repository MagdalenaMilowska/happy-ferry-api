using System.ComponentModel.DataAnnotations.Schema;

namespace FerryApi.Models
{
    public class Parking
    {
        public Guid Id { get; set; }
        
        public VehicleType TypeOfParkingSpot { get; set; }

        public int Size { get; set; }

        public bool IsParked { get; set; }

        public string SpaceName { get; set; }

        [ForeignKey("Vehicle")]
        public string? LicensePlateId { get; set; }
    }
}
