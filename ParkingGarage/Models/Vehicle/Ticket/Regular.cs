using ParkingGarage.BusinessLogic.ParkingLot;
using ParkingGarage.Models.ParkingLot;

namespace Vehicle.Ticket
{
    public class Regular : ITicket
    {
        private readonly ParkingLotLogic _parkingLotLogic;

        public Regular(ParkingLotLogic parkingLotLogic)
        {
            _parkingLotLogic = parkingLotLogic;
        }

        public ParkingLot GetFreeParkingLot()
        {
            return _parkingLotLogic.GetFreeParkingLotByTicketRegular();
        }
    }
}