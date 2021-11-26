using System.Collections.Generic;
using ParkingGarage.BusinessLogic.ParkingLot;
using ParkingGarage.Models.ParkingLot;

namespace Vehicle.Ticket
{
    public class Regular : Ticket
    {
        private readonly ParkingLotsLogic _parkingLotsLogic;

        public Regular(ParkingLotsLogic parkingLotsLogic)
        {
            _parkingLotsLogic = parkingLotsLogic;

            Dimensions.Height = 2000;
            Dimensions.Width = 2000;
            Dimensions.Length = 3000;
            ClassList = new List<string>()
            {
                "A"
            };
            Cost = 50;
            TimeLimit = "24h";
        }

        public override ParkingLot GetFreeParkingLot()
        {
            return _parkingLotsLogic.GetFreeParkingLotByParkingLotsIdLimits(31, 60);
        }
    }
}