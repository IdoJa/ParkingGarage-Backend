using System.Collections.Generic;
using ParkingGarage.Models.ParkingLot;

namespace Vehicle.Ticket
{
    public abstract class Ticket
    {
        protected Dimensions.Dimensions Dimensions;
        protected List<string> ClassList;
        protected int Cost;
        protected string TimeLimit;
        
        protected abstract ParkingLot GetFreeParkingLot();
    }
}