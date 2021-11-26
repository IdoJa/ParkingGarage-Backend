using System;
using System.Collections.Generic;
using ParkingGarage.BusinessLogic.ParkingLot;
using ParkingGarage.Models.ParkingLot;

namespace Vehicle.Ticket
{
    public class Vip : Ticket
    {
        private readonly ParkingLotsLogic _parkingLotsLogic;

        public Vip(ParkingLotsLogic parkingLotsLogic)
        {
            _parkingLotsLogic = parkingLotsLogic;
            
            Dimensions.Height = Int32.MaxValue;
            Dimensions.Width = Int32.MaxValue;
            Dimensions.Length = Int32.MaxValue;
            ClassList = new List<string>()
            {
                "A", "B", "C"
            };
            Cost = 200;
            TimeLimit = "no limit";
        }

        protected override ParkingLot GetFreeParkingLot()
        {
            return _parkingLotsLogic.GetFreeParkingLotByTicketVip();
        }
    }
}