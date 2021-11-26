using System.Collections.Generic;

namespace ParkingGarage.Data.ParkingLot
{
    public interface IParkingLotRepo
    {
        List<Models.ParkingLot.ParkingLot> GetAllParkingLots();
    }
}