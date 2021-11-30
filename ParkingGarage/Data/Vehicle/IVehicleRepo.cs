using System.Collections.Generic;

namespace ParkingGarage.Data.Vehicle
{
    public interface IVehicleRepo
    {
        List<global::Vehicle.Vehicle> GetAllVehicles();

        global::Vehicle.Vehicle GetVehicleById(string id);

        void CreateVehicle(global::Vehicle.Vehicle vehicle);

        void DeleteVehicle(global::Vehicle.Vehicle vehicle);
        
        List<global::Vehicle.Vehicle> GetAllParkingVehiclesByTicket(string ticketName);
    }

}