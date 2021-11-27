using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ParkingGarage.BusinessLogic;
using ParkingGarage.BusinessLogic.Tickets;
using ParkingGarage.Helpers.HttpStatusException;

namespace ParkingGarage.Controllers.Tickets
{
    [Route("api/tickets")]
    [ApiController]
    
    public class TicketsController : ControllerBase
    {
        private readonly VehiclesLogic _vehiclesLogic;
        private readonly TicketsLogic _ticketsLogic;
        
        public TicketsController(VehiclesLogic vehiclesLogic, TicketsLogic ticketsLogic)
        {
            _vehiclesLogic = vehiclesLogic;
            _ticketsLogic = ticketsLogic;
        }
        
        // POST api/tickets
        [EnableCors("TCAPolicy")]
        [HttpGet("{vehicleName}")]
        public ActionResult <List<string>> GetAllTicketsNamesByVehicle(string vehicleName)
        {
            try
            {
                var vehicle = _vehiclesLogic.CreateVehicleByString(vehicleName);
                return _ticketsLogic.GetAllTicketsNamesByVehicle(vehicle);
            }
            catch (HttpStatusException e)
            {
                return StatusCode(e.StatusCodeResult.StatusCode, e.Msg);
            }
        }
    }
}