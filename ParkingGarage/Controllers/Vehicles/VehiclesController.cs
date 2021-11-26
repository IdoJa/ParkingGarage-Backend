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
            var vehicleItem = _vehiclesLogic.GetAllVehicles();

            return Ok(vehicleItem);
        }

        [HttpGet("{id}", Name="GetVehicleById")]
        public ActionResult<Vehicle.Vehicle> GetVehicleById(int id)
        {
            var vehicleItem = _vehiclesLogic.GetVehicleById(id);
            if (vehicleItem == null)
            {
                return NotFound();
            }
            
            return Ok(vehicleItem);
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