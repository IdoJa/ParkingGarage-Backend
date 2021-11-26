
using System.Collections.Generic;

namespace ParkingGarage.Data.ParkingLot
{
    public interface IParkingLotRepo
    {
        List<Models.ParkingLot.ParkingLot> GetAllParkingLots();

        Models.ParkingLot.ParkingLot GetFreeParkingLotByTicketVip();
        
        Models.ParkingLot.ParkingLot GetFreeParkingLotByTicketValue();
        
        Models.ParkingLot.ParkingLot GetFreeParkingLotByTicketRegular();
        
    }
}