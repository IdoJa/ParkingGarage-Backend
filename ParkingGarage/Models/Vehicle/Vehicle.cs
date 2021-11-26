using System.ComponentModel.DataAnnotations;
using ParkingGarage.Models.ParkingLot;

namespace Vehicle
{
    public class Vehicle
    {
        [Key] public int LicensePlateId { get; set; }

        public Ticket.Ticket Ticket { get; }

        /// <summary>
        ///     May be: [A, B, C] only.
        /// </summary>
        public string Class { get; set; }

        public int Height { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public ParkingLot ParkingLot { get; set; }
    }
}