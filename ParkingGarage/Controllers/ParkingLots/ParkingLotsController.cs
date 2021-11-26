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
        private readonly ParkingLotLogic _parkingLotLogic;

        public ParkingLotsController(ParkingLotLogic parkingLotLogic)
        {
            _parkingLotLogic = parkingLotLogic;
        }
        
        [HttpGet]
        public ActionResult<List<Models.ParkingLot.ParkingLot>> GetAllParkingLots()
        {
            var commandItems = _parkingLotLogic.GetAllParkingLots();

            return Ok(commandItems);
        }
    }
}