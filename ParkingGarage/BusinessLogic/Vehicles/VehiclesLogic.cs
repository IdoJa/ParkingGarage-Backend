using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS;
using ParkingGarage.BusinessLogic.ParkingLot;
using ParkingGarage.Data.Vehicle;
using ParkingGarage.Helpers.HttpStatusException;
using Vehicle.Ticket;

namespace ParkingGarage.BusinessLogic
{
    public class VehiclesLogic
    {
        private readonly IVehicleRepo _vehicleRepo;
        private readonly ParkingLotsLogic _parkingLotsLogic;

        public VehiclesLogic(IVehicleRepo vehicleRepo, ParkingLotsLogic parkingLotsLogic)
        {
            _vehicleRepo = vehicleRepo;
            _parkingLotsLogic = parkingLotsLogic;
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
            // check vehicle class
            var freeParkingLot = CreateTicket(vehicle.Ticket).GetFreeParkingLot();
            if (freeParkingLot == null)
            {
                // there is no free lot for this ticket type
                var msg = $"there is no free lot for this ticket type: {vehicle.Ticket}";
                throw new HttpStatusException(new BadRequestResult(), msg);
            }

            _vehicleRepo.CreateVehicle(vehicle);
        }

        public Ticket CreateTicket(string ticket)
        {
            Ticket returnValue = null;
            switch (ticket)
            {
                case "Vip":
                    returnValue = new Vip(_parkingLotsLogic);
                    break;
                case "Value":
                    returnValue = new Value(_parkingLotsLogic);
                    break;
                case "Regular":
                    returnValue = new Regular(_parkingLotsLogic);
                    break;
            }

            return returnValue;
        }
        
        // return valid ticket types based on selected vehicle type
    }
}