using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingGarage.BusinessLogic.ParkingLot;
using ParkingGarage.Data.ParkingLot;
using ParkingGarage.Helpers.HttpStatusException;

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
            try
            {
                var commandItems = _parkingLotsLogic.GetAllParkingLots();
                return Ok(commandItems);
            }
            catch (HttpStatusException e)
            {
                return StatusCode(e.StatusCodeResult.StatusCode, e.Msg);
            }
        }
        
        
    }
}