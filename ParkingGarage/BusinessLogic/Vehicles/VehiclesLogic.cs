using System.Collections.Generic;
using ParkingGarage.Data.Vehicle;

namespace ParkingGarage.BusinessLogic
{
    public class VehiclesLogic
    {
        private readonly IVehicleRepo _vehicleRepo;
        
        public VehiclesLogic(IVehicleRepo vehicleRepo)
        {
            _vehicleRepo = vehicleRepo;
        }
        
        public List<global::Vehicle.Vehicle> GetAllVehicles()
        {
            return _vehicleRepo.GetAllVehicles();
        }
    }
}