using ParkingGarage.BusinessLogic.ParkingLot;
using ParkingGarage.Models.ParkingLot;

namespace Vehicle.Ticket
{
    public class Regular : ITicket
    {
        private readonly ParkingLotsLogic _parkingLotsLogic;

        public Regular(ParkingLotsLogic parkingLotsLogic)
        {
            _parkingLotsLogic = parkingLotsLogic;
        }

        public ParkingLot GetFreeParkingLot()
        {
            return _parkingLotsLogic.GetFreeParkingLotByTicketRegular();
        }
    }
}