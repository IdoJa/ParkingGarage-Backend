
using System.Collections.Generic;

namespace ParkingGarage.Data.ParkingLot
{
    public interface IParkingLotRepo
    {
        List<Models.ParkingLot.ParkingLot> GetAllParkingLots();

        Models.ParkingLot.ParkingLot GetFreeParkingLotIdByTicketVip();
        Models.ParkingLot.ParkingLot GetFreeParkingLotIdByTicketValue();
        Models.ParkingLot.ParkingLot GetFreeParkingLotIdByTicketRegular();
    }
}