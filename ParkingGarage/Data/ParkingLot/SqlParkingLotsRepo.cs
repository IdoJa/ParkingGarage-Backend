using System;
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
            const string sql = "SELECT * FROM parkinglots ORDER BY Id ASC";
            return Context.ParkingLots.FromSqlRaw(sql).ToList();
        }
        
        public Models.ParkingLot.ParkingLot GetParkingLotByLicensePlateId(string licensePlateId)
        {
            var sql = $"SELECT * FROM parkinglots WHERE LicensePlateId = {licensePlateId}";
            return Context.ParkingLots.FromSqlRaw(sql).FirstOrDefault();
        }

        public Models.ParkingLot.ParkingLot GetFreeParkingLotByParkingLotsIdLimits(int startId, int endId)
        {
            var sql = $"SELECT * FROM parkinglots WHERE Id >= {startId} AND Id <= {endId} AND LicensePlateId IS NULL";
            return Context.ParkingLots.FromSqlRaw(sql).FirstOrDefault();
        }
        
        public void UpdateParkingLotWithLicensePlateId(Models.ParkingLot.ParkingLot parkingLot, string licensePlateId)
        {
            var sql = $"UPDATE parkinglots SET LicensePlateId = {licensePlateId} WHERE Id = {parkingLot.Id}";
            Context.ParkingLots.FromSqlRaw(sql);
        }

        public void UpdateParkingLotWithNull(Models.ParkingLot.ParkingLot parkingLot)
        {
            parkingLot.LicensePlateId = null;
            Context.ParkingLots.Update(parkingLot);
            SaveChanges();
        }
        
    }
}