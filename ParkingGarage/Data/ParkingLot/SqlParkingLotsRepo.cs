﻿using System.Collections.Generic;
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

        public Models.ParkingLot.ParkingLot GetFreeParkingLotByTicketVip()
        {
            const string sql = "SELECT * FROM parkinglots WHERE Id >= 1 AND Id <= 10 AND LicensePlateId IS NULL";
            return _context.ParkingLots.FromSqlRaw(sql).FirstOrDefault();
        }

        public Models.ParkingLot.ParkingLot GetFreeParkingLotByTicketValue()
        {
            const string sql = "SELECT * FROM parkinglots WHERE Id >= 11 AND Id <= 30 AND LicensePlateId IS NULL";
            return _context.ParkingLots.FromSqlRaw(sql).FirstOrDefault();
        }

        public Models.ParkingLot.ParkingLot GetFreeParkingLotByTicketRegular()
        {
            const string sql = "SELECT * FROM parkinglots WHERE Id >= 31 AND Id <= 60 AND LicensePlateId IS NULL";
            return _context.ParkingLots.FromSqlRaw(sql).FirstOrDefault();
        }
    }
}