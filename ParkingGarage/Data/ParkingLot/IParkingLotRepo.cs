
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ParkingGarage.Data.ParkingLot
{
    public interface IParkingLotRepo
    {
        List<Models.ParkingLot.ParkingLot> GetAllParkingLots();

        Models.ParkingLot.ParkingLot GetFreeParkingLotByParkingLotsIdLimits(int startId, int endId);

        Models.ParkingLot.ParkingLot UpdateParkingLot(Models.ParkingLot.ParkingLot parkingLot);
    }
}