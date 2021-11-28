using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingGarage.Models.ParkingLot
{
    public class ParkingLot
    {
        [Key] 
        public int Id { get; set; }
        
        [ForeignKey("Vehicle")]
        public string LicensePlateId { get; set; }
        public Vehicle.Vehicle Vehicle { get; set; }

        // public override string ToString()
        // {
        //     return $"{nameof(Id)}: {Id}, " +
        //            $"{nameof(LicensePlateId)}: {LicensePlateId}, " +
        //            $"{nameof(Vehicle)}: {Vehicle}";
        // }
    }
}