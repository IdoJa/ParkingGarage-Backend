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
        private readonly VehiclesLogic _vehiclesLogic;

        public VehiclesController(VehiclesLogic vehiclesLogic)
        {
            _vehiclesLogic = vehiclesLogic;
        }

        [HttpGet]
        public ActionResult<List<Vehicle.Vehicle>> GetAllVehicles()
        {
            var commandItems = _vehiclesLogic.GetAllVehicles();

            return Ok(commandItems);
        }
        
        // POST api/vehicle
        [HttpPost]
        public ActionResult<Vehicle.Vehicle> CreateVehicle(Vehicle.Vehicle vehicle)
        {
            _vehiclesLogic.CreateVehicle(vehicle);

            return Ok();

        }
        
    }
}