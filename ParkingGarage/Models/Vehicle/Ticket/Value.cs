using ParkingGarage.BusinessLogic.ParkingLot;
using ParkingGarage.Models.ParkingLot;

namespace Vehicle.Ticket
{
    public class Value : ITicket
    {
        private readonly ParkingLotLogic _parkingLotLogic;

        public Value(ParkingLotLogic parkingLotLogic)
        {
            _parkingLotLogic = parkingLotLogic;
        }

        public ParkingLot GetFreeParkingLot()
        {
            return _parkingLotLogic.GetFreeParkingLotByTicketValue();
        }
    }
}