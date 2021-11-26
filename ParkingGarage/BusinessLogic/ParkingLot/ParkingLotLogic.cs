using System.Collections.Generic;
using ParkingGarage.Data.ParkingLot;

namespace ParkingGarage.BusinessLogic.ParkingLot
{
    public class ParkingLotLogic
    {
        private readonly IParkingLotRepo _parkingLotRepo;
        
        public ParkingLotLogic(IParkingLotRepo parkingLotRepo)
        {
            _parkingLotRepo = parkingLotRepo;
        }

        public List<Models.ParkingLot.ParkingLot> GetAllParkingLots()
        {
            return _parkingLotRepo.GetAllParkingLots();
        }

        public Models.ParkingLot.ParkingLot GetFreeParkingLotIdByTicketVip()
        {
            return _parkingLotRepo.GetFreeParkingLotIdByTicketVip();
        }

        public Models.ParkingLot.ParkingLot GetFreeParkingLotIdByTicketValue()
        {
            return _parkingLotRepo.GetFreeParkingLotIdByTicketValue();
        }

        public Models.ParkingLot.ParkingLot GetFreeParkingLotIdByTicketRegular()
        {
            return _parkingLotRepo.GetFreeParkingLotIdByTicketRegular();
        }
    }
}