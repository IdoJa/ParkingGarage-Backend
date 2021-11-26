using ParkingGarage.Models.ParkingLot;

namespace Vehicle.Ticket
{
    public interface ITicket
    {
         ParkingLot GetFreeParkingLot();
    }
}