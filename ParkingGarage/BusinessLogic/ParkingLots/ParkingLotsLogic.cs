using System.Collections.Generic;
using ParkingGarage.Data.ParkingLot;

namespace ParkingGarage.BusinessLogic.ParkingLot
{
    public class ParkingLotsLogic
    {
        private readonly IParkingLotRepo _parkingLotRepo;
        
        public ParkingLotsLogic(IParkingLotRepo parkingLotRepo)
        {
            _parkingLotRepo = parkingLotRepo;
        }

        public List<Models.ParkingLot.ParkingLot> GetAllParkingLots()
        {
            return _parkingLotRepo.GetAllParkingLots();
        }

        public Models.ParkingLot.ParkingLot GetFreeParkingLotByTicketVip()
        {
            return _parkingLotRepo.GetFreeParkingLotByTicketVip();
        }

        public Models.ParkingLot.ParkingLot GetFreeParkingLotByTicketValue()
        {
            return _parkingLotRepo.GetFreeParkingLotByTicketValue();
        }

        public Models.ParkingLot.ParkingLot GetFreeParkingLotByTicketRegular()
        {
            return _parkingLotRepo.GetFreeParkingLotByTicketRegular();
        }
    }
}