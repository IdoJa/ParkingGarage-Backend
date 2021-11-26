using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingGarage.BusinessLogic;
using ParkingGarage.Data.Vehicle;

namespace ParkingGarage.Controllers
{
    [Route("api/vehicles")] 
    [ApiController]
    
    public class VehiclesController : ControllerBase
    {
        private readonly VehicleLogic _vehicleLogic;

        public VehiclesController(VehicleLogic vehicleLogic)
        {
            _vehicleLogic = vehicleLogic;
        }
        
        [HttpGet]
        public ActionResult<List<Vehicle.Vehicle>> GetAllVehicles()
        {
            var commandItems = _vehicleLogic.GetAllVehicles();

            return Ok(commandItems);
        }

    }
}