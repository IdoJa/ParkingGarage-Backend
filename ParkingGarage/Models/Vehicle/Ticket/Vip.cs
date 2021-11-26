using ParkingGarage.BusinessLogic.ParkingLot;
using ParkingGarage.Models.ParkingLot;

namespace Vehicle.Ticket
{
    public class Vip : ITicket
    {
        private readonly ParkingLotsLogic _parkingLotsLogic;

        public Vip(ParkingLotsLogic parkingLotsLogic)
        {
            _parkingLotsLogic = parkingLotsLogic;
        }

        public ParkingLot GetFreeParkingLot()
        {
            return _parkingLotsLogic.GetFreeParkingLotByTicketVip();
        }
    }
}