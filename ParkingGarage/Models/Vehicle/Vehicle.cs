using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ParkingGarage.Models.ParkingLot;

namespace Vehicle
{
    public class Vehicle
    {
        [Key] public string LicensePlateId { get; set; }

        [MaxLength(20)] public string Name { get; set; }

        [MaxLength(15)] public string Phone { get; set; }

        /// <summary>
        ///     May be: [A, B, C] only.
        /// </summary>
        [NotMapped]
        public string Class { get; protected set; }

        /// <summary>
        ///     May be: [Vip, Value, Regular] only.
        /// </summary>
        [MaxLength(10)]
        public string Ticket { get; set; }

        public int Height { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public ParkingLot ParkingLot { get; set; }
    }
}