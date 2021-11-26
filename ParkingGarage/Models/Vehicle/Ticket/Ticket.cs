using System.Collections.Generic;
using ParkingGarage.Models.ParkingLot;

namespace Vehicle.Ticket
{
    public abstract class Ticket
    {
        public Dimensions.Dimensions Dimensions = new Dimensions.Dimensions();
        public List<string> ClassList;
        public int Cost;
        public string TimeLimit;
        
        public abstract ParkingLot GetFreeParkingLot();
    }
}