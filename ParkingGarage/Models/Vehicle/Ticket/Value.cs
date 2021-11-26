using System.Collections.Generic;
using ParkingGarage.BusinessLogic.ParkingLot;
using ParkingGarage.Models.ParkingLot;

namespace Vehicle.Ticket
{
    public class Value : Ticket
    {
        private readonly ParkingLotsLogic _parkingLotsLogic;

        public Value(ParkingLotsLogic parkingLotsLogic)
        {
            _parkingLotsLogic = parkingLotsLogic;
            
            Dimensions.Height = 2500;
            Dimensions.Width = 2400;
            Dimensions.Length = 5000;
            ClassList = new List<string>()
            {
                "A", "B"
            };
            Cost = 100;
            TimeLimit = "72h";
        }

        protected override ParkingLot GetFreeParkingLot()
        {
            return _parkingLotsLogic.GetFreeParkingLotByParkingLotsIdLimits(11, 30);
        }
    }
}