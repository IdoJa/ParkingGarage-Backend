using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ParkingGarage.Data.Vehicle
{
    public class SqlVehiclesRepo : IVehicleRepo
    {
        private readonly VehicleContext _context;

        public SqlVehiclesRepo(VehicleContext context)
        {
            _context = context;
        }
        
        // returns list
        public List<global::Vehicle.Vehicle> GetAllVehicles()
        {
            const string sql = "SELECT * FROM vehicles";
            return _context.Vehicles.FromSqlRaw(sql).ToList();
        }
    }
}