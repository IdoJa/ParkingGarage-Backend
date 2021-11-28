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
        

        public void UpdateParkingLot(Models.ParkingLot.ParkingLot parkingLot, string licensePlateId)
        {
            //  (NOT IMPLEMENTED)
            var sql = $"UPDATE parkinglots SET LicensePlateId = {licensePlateId} WHERE Id = {parkingLot.Id}";
            
        }
    }
}