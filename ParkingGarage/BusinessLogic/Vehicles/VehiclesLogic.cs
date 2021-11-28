using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS;
using ParkingGarage.BusinessLogic.ParkingLot;
using ParkingGarage.BusinessLogic.Tickets;
using ParkingGarage.Data.Vehicle;
using ParkingGarage.Helpers.HttpStatusException;
using Vehicle.Impl;
using Vehicle.Ticket;

namespace ParkingGarage.BusinessLogic
{
    public class VehiclesLogic
    {
        private readonly IVehicleRepo _vehicleRepo;
        private readonly ParkingLotsLogic _parkingLotsLogic;
        private readonly TicketsLogic _ticketsLogic;

        public VehiclesLogic(IVehicleRepo vehicleRepo, ParkingLotsLogic parkingLotsLogic, TicketsLogic ticketsLogic)
        {
            _vehicleRepo = vehicleRepo;
            _parkingLotsLogic = parkingLotsLogic;
            _ticketsLogic = ticketsLogic;
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
            Ticket ticket = _ticketsLogic.CreateTicketByString(vehicle.Ticket);
            
            
            // TODO: check for `vehicle.Dimensions` that are 
            if (vehicle.Height > ticket.Dimensions.Height)
            {
                
            }

            if (vehicle.Width > ticket.Dimensions.Width)
            {
                
            }

            if (vehicle.Length > ticket.Dimensions.Length)
            {
                
            }
            
            // check vehicle class
            var freeParkingLot = ticket.GetFreeParkingLot();
            if (freeParkingLot == null)
            {
                // there is no free lot for this ticket type
                var msg = $"there is no free lot for this ticket type: {vehicle.Ticket}";
                throw new HttpStatusException(new BadRequestResult(), msg);
            }

            vehicle.ParkingLot = freeParkingLot;
            
            // TODO: update parking lot with licenseplate - need to create vehicle and then update parking lot
            
            _vehicleRepo.CreateVehicle(vehicle);
        }
        
        // return valid ticket types based on selected vehicle type
        public Vehicle.Vehicle CreateVehicleByString(string vehicle)
        {
            Vehicle.Vehicle returnValue = null;
            switch (vehicle)
            {
                case "Motorcycle":
                    returnValue = new Motorcycle();
                    break;
                case "Private":
                    returnValue = new Private();
                    break;
                case "Crossover":
                    returnValue = new Crossover();
                    break;
                case "SUV":
                    returnValue = new SUV();
                    break;
                case "Van":
                    returnValue = new Van();
                    break;
                case "Truck":
                    returnValue = new Truck();
                    break;
            }

            return returnValue;
        }

        public List<string> GetVehiclesNames()
        {
            return new List<string>()
            {
                "Motorcycle",
                "Private",
                "Crossover",
                "SUV",
                "Van",
                "Truck"
            };
        }
    }
}