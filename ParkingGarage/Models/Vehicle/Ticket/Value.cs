using ParkingGarage.BusinessLogic.ParkingLot;
using ParkingGarage.Models.ParkingLot;

namespace Vehicle.Ticket
{
    public class Value : ITicket
    {
        private readonly ParkingLotsLogic _parkingLotsLogic;

        public Value(ParkingLotsLogic parkingLotsLogic)
        {
            _parkingLotsLogic = parkingLotsLogic;
        }

        public ParkingLot GetFreeParkingLot()
        {
            return _parkingLotsLogic.GetFreeParkingLotByTicketValue();
        }
    }
}