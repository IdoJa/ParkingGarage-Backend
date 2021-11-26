using ParkingGarage.BusinessLogic.ParkingLot;
using ParkingGarage.Models.ParkingLot;

namespace Vehicle.Ticket
{
    public class Vip : ITicket
    {
        private readonly ParkingLotLogic _parkingLotLogic;

        public Vip(ParkingLotLogic parkingLotLogic)
        {
            _parkingLotLogic = parkingLotLogic;
        }

        public ParkingLot GetFreeParkingLot()
        {
            return _parkingLotLogic.GetFreeParkingLotByTicketVip();
        }
    }
}