using Microsoft.EntityFrameworkCore;

namespace ParkingGarage.Data.ParkingLot
{
    public class ParkingLotContext : DbContext
    {
        public ParkingLotContext(DbContextOptions<ParkingLotContext> opt) : base(opt)
        {
            
        }
        
        public DbSet<Models.ParkingLot.ParkingLot> ParkingLots { get; set; }
    }
}