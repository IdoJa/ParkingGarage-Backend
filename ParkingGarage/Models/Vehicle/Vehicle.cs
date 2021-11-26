using System.ComponentModel.DataAnnotations;
using Vehicle.Ticket;

namespace Vehicle
{
    public class Vehicle
    {
        [Key] public int LicensePlateId { get; set; }

        public ITicket Ticket { get; }


        private enum VehicleType
        {
            ClassA,
            ClassB,
            ClassC
        }


        public int Height { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
    }
}