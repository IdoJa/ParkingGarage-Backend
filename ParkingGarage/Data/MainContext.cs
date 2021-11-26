using Microsoft.EntityFrameworkCore;
using ParkingGarage.Data.ParkingLot;
using ParkingGarage.Models.ParkingLot;

namespace ParkingGarage.Data
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> opt) : base(opt)
        {
        }

        public DbSet<global::Vehicle.Vehicle> Vehicles { get; set; }
        public DbSet<Models.ParkingLot.ParkingLot> ParkingLots { get; set; }
    }
}