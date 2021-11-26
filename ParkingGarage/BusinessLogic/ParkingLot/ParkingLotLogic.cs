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
    }
}