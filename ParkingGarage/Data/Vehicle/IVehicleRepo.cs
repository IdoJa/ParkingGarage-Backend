using System.Collections.Generic;

namespace ParkingGarage.Data.Vehicle
{
    public interface IVehicleRepo
    {
        List<global::Vehicle.Vehicle> GetAllVehicles();

        global::Vehicle.Vehicle GetVehicleById(int id);

        void CreateVehicle(global::Vehicle.Vehicle vehicle);
    }

}