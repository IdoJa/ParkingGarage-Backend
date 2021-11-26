using System.Collections.Generic;

namespace ParkingGarage.Data.Vehicle
{
    public interface IVehicleRepo
    {
        List<global::Vehicle.Vehicle> GetAllVehicles();

        void CreateVehicle(global::Vehicle.Vehicle vehicle);
    }

}