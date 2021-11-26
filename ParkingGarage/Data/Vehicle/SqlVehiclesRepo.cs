﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ParkingGarage.Data.SharedRepo;

namespace ParkingGarage.Data.Vehicle
{
    public class SqlVehiclesRepo : SharedRepo<global::Vehicle.Vehicle>, IVehicleRepo
    {
        public SqlVehiclesRepo(MainContext context) : base(context)
        {
        }

        public List<global::Vehicle.Vehicle> GetAllVehicles()
        {
            const string sql = "SELECT * FROM vehicles";
            return Context.Vehicles.FromSqlRaw(sql).ToList();
        }

        public global::Vehicle.Vehicle GetVehicleById(int id)
        {
            var sql = $"SELECT * FROM vehicles WHERE LicensePlateId={id}";
            return Context.Vehicles.FromSqlRaw(sql).FirstOrDefault();
        }

        // Create
        public void CreateVehicle(global::Vehicle.Vehicle vehicle)
        {
            Create(Context.Vehicles, vehicle);
        }
    }
}