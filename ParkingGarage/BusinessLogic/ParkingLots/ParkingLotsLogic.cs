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

        public Models.ParkingLot.ParkingLot GetFreeParkingLotByParkingLotsIdLimits(int startId, int endId)
        {
            return _parkingLotRepo.GetFreeParkingLotByParkingLotsIdLimits(startId, endId);
        }
        
        // update 
        public void UpdateParkingLotWithLicensePlateId(Models.ParkingLot.ParkingLot parkingLot, string licensePlateId)
        {
            
            _parkingLotRepo.UpdateParkingLot(parkingLot);
        }
        

    }
}