using System.Collections.Generic;
using System.Linq;
using ParkingGarage.BusinessLogic.ParkingLot;
using Vehicle.Impl;
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

        public Ticket CreateTicketByString(string ticket)
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
        
        /// <summary>
        /// for every Vehicle check if its class matches with ticket class list - if no dont return it
        /// example: for <see cref="Van"/> the class is "B" check if match with ticket class "Regular"
        /// in this case, no return. and there is no option to select "Regular"
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns>list of ticket names compatible with the vehicle given to controller</returns>
        public List<string> GetAllTicketsNamesByVehicle(Vehicle.Vehicle vehicle)
        {
            var ticketList = GetAllTickets().Where(ticket => ticket.ClassList.Contains(vehicle.Class)).ToList();
            return GetAllTicketsNames(ticketList);
        }

        /// <summary>
        /// extract the ticket name for every ticket given
        /// </summary>
        /// <param name="ticketList"></param>
        /// <returns></returns>
        private List<string> GetAllTicketsNames(List<Ticket> ticketList)
        {
            return ticketList.Select(ticket => ticket.GetType().Name).ToList();
        }

        public List<Ticket> OfferSubstituteTicket(Ticket ticket)
        {
            // check for valid dimensions for received ticket input (must be valid for every dimension property)
            return GetAllTickets().Where(t =>
                (t.Dimensions.Height >= ticket.Dimensions.Height) &&
                (t.Dimensions.Width >= ticket.Dimensions.Width) &&
                (t.Dimensions.Length >= ticket.Dimensions.Length) &&
                (t.GetType().Name != ticket.GetType().Name)).ToList();
        }
        
    }
}