using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingGarage.BusinessLogic;
using ParkingGarage.Data.Vehicle;
using ParkingGarage.Helpers.HttpStatusException;

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

            try
            {
                _vehiclesLogic.CreateVehicle(vehicle);
            
                return CreatedAtRoute(nameof(GetVehicleById), new {Id = vehicle.LicensePlateId}, vehicle);
            }
            catch (HttpStatusException e)
            {
                return StatusCode((int) e.Status, e.Msg);
                // return NotFound();
            }
        }
        
    }
}