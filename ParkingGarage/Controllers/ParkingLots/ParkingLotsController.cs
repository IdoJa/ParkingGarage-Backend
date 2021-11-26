using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingGarage.Data.ParkingLot;

namespace ParkingGarage.Controllers.ParkingLot
{
    
    [Route("api/parkinglots")] 
    [ApiController]
    
    public class ParkingLotsController : ControllerBase
    {
        private readonly IParkingLotRepo _repository;

        public ParkingLotsController(IParkingLotRepo repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        public ActionResult<List<Models.ParkingLot.ParkingLot>> GetAllParkingLots()
        {
            var commandItems = _repository.GetAllParkingLots();

            return Ok(commandItems);
        }
    }
}