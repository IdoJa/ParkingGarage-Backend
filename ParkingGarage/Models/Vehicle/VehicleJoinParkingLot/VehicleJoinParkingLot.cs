namespace Vehicle.VehicleJoinParkingLot
{
    public class VehicleJoinParkingLot
    {
        public string LicensePlateId { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        /// <summary>
        ///     May be: [Vip, Value, Regular] only.
        /// </summary>
        public string Ticket { get; set; }

        public int Height { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public int ParkingLot { get; set; }
    }
}