using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingGarage.Data.Vehicle;

namespace ParkingGarage.Controllers
{
    [Route("api/vehicles")] 
    [ApiController]
    
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleRepo _repository;

        public VehiclesController(IVehicleRepo repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        public ActionResult<List<Vehicle.Vehicle>> GetAllVehicles()
        {
            var commandItems = _repository.GetAllVehicles();

            return Ok(commandItems);
        }

    }
}