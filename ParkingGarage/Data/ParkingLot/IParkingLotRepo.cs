
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ParkingGarage.Data.ParkingLot
{
    public interface IParkingLotRepo
    {
        List<Models.ParkingLot.ParkingLot> GetAllParkingLots();
        
        Models.ParkingLot.ParkingLot GetParkingLotByLicensePlateId(string licensePlateId);

        Models.ParkingLot.ParkingLot GetFreeParkingLotByParkingLotsIdLimits(int startId, int endId);

        void UpdateParkingLotWithLicensePlateId(Models.ParkingLot.ParkingLot parkingLot, string licensePlateId);

        void UpdateParkingLotWithNull(Models.ParkingLot.ParkingLot parkingLot);
    }
}