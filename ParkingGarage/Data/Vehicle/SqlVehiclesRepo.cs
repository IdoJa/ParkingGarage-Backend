using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ParkingGarage.Data.Vehicle
{
    public class SqlVehiclesRepo : IVehicleRepo
    {
        private readonly MainContext _context;

        public SqlVehiclesRepo(MainContext context)
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