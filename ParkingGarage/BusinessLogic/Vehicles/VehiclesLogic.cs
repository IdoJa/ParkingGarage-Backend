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
        
        // get one vehicle
        public Vehicle.Vehicle GetVehicleById(int id)
        {
            return _vehicleRepo.GetVehicleById(id);
        }
        
        // create vehicle
        public void CreateVehicle(Vehicle.Vehicle vehicle)
        {
            _vehicleRepo.CreateVehicle(vehicle);
        }
    }
}