using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ParkingGarage.Data.ParkingLot
{
    public class SqlParkingLotsRepo : IParkingLotRepo
    {
        private readonly ParkingLotContext _context;

        public SqlParkingLotsRepo(ParkingLotContext context)
        {
            _context = context;
        }
        
        public List<Models.ParkingLot.ParkingLot> GetAllParkingLots()
        {
            var sql = "SELECT * FROM parkinglots";
            return _context.ParkingLots.FromSqlRaw(sql).ToList();
        }
    }
}