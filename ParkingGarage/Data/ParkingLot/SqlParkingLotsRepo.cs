using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ParkingGarage.Data.SharedRepo;

namespace ParkingGarage.Data.ParkingLot
{
    public class SqlParkingLotsRepo : SharedRepo<Models.ParkingLot.ParkingLot>, IParkingLotRepo
    {
        public SqlParkingLotsRepo(MainContext context) : base(context)
        {
        }
        
        public List<Models.ParkingLot.ParkingLot> GetAllParkingLots()
        {
            const string sql = "SELECT * FROM parkinglots";
            return Context.ParkingLots.FromSqlRaw(sql).ToList();
        }

        public Models.ParkingLot.ParkingLot GetFreeParkingLotByParkingLotsIdLimits(int startId, int endId)
        {
            var sql = $"SELECT * FROM parkinglots WHERE Id >= {startId} AND Id <= {endId} AND LicensePlateId IS NULL";
            return Context.ParkingLots.FromSqlRaw(sql).FirstOrDefault();
        }

        public Models.ParkingLot.ParkingLot UpdateParkingLot(Models.ParkingLot.ParkingLot parkingLot)
        {
            //  (NOT IMPLEMENTED)
            var aparkingLot = new Models.ParkingLot.ParkingLot();
            const string sql = "";
            return aparkingLot;
        }
    }
}