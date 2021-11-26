using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingGarage.BusinessLogic.ParkingLot;
using ParkingGarage.Data.ParkingLot;

namespace ParkingGarage.Controllers.ParkingLot
{
    
    [Route("api/parkinglots")] 
    [ApiController]
    
    public class ParkingLotsController : ControllerBase
    {
        private readonly ParkingLotsLogic _parkingLotsLogic;

        public ParkingLotsController(ParkingLotsLogic parkingLotsLogic)
        {
            _parkingLotsLogic = parkingLotsLogic;
        }
        
        [HttpGet]
        public ActionResult<List<Models.ParkingLot.ParkingLot>> GetAllParkingLots()
        {
            var commandItems = _parkingLotsLogic.GetAllParkingLots();

            return Ok(commandItems);
        }
        
        
    }
}