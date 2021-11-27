using System.Collections.Generic;
using ParkingGarage.BusinessLogic.ParkingLot;
using Vehicle.Ticket;

namespace ParkingGarage.BusinessLogic.Tickets
{
    public class TicketsLogic
    {
        private readonly ParkingLotsLogic _parkingLotsLogic;

        public TicketsLogic(ParkingLotsLogic parkingLotsLogic)
        {
            _parkingLotsLogic = parkingLotsLogic;
        }

        public Ticket CreateTicket(string ticket)
        {
            Ticket returnValue = null;
            switch (ticket)
            {
                case "Vip":
                    returnValue = new Vip(_parkingLotsLogic);
                    break;
                case "Value":
                    returnValue = new Value(_parkingLotsLogic);
                    break;
                case "Regular":
                    returnValue = new Regular(_parkingLotsLogic);
                    break;
            }

            return returnValue;
        }

        public List<Ticket> GetAllTickets()
        {
            return new List<Ticket>()
            {
                new Vip(_parkingLotsLogic),
                new Value(_parkingLotsLogic),
                new Regular(_parkingLotsLogic)
            };
        }
        
    }
}