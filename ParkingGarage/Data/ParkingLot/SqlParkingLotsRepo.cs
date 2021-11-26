using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ParkingGarage.Data.ParkingLot
{
    public class SqlParkingLotsRepo : IParkingLotRepo
    {
        private readonly MainContext _context;

        public SqlParkingLotsRepo(MainContext context)
        {
            _context = context;
        }
        
        public List<Models.ParkingLot.ParkingLot> GetAllParkingLots()
        {
            const string sql = "SELECT * FROM parkinglots";
            return _context.ParkingLots.FromSqlRaw(sql).ToList();
        }

        public Models.ParkingLot.ParkingLot GetFreeParkingLotByParkingLotsIdLimits(int startId, int endId)
        {
            var sql = $"SELECT * FROM parkinglots WHERE Id >= {startId} AND Id <= {endId} AND LicensePlateId IS NULL";
            return _context.ParkingLots.FromSqlRaw(sql).FirstOrDefault();
        }
        
    }
}