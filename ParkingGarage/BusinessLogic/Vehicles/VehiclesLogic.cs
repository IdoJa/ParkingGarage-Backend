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
        public Vehicle.Vehicle GetVehicleById(string id)
        {
            return _vehicleRepo.GetVehicleById(id);
        }

        // create vehicle
        public void CreateVehicle(Vehicle.Vehicle vehicle)
        {
            // check if license plate id already exists
            if (GetVehicleById(vehicle.LicensePlateId) != null)
            {
                var msg = $"This Vehicle is already parked";
                throw new HttpStatusException(new BadRequestResult(), msg);
            }
            
            Ticket ticket = _ticketsLogic.CreateTicketByString(vehicle.Ticket);
            
            AssertTicketDimensions(vehicle, ticket);

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
            _parkingLotsLogic.UpdateParkingLotWithLicensePlateId(freeParkingLot, vehicle.LicensePlateId);
        }

        private void AssertTicketDimensions(Vehicle.Vehicle vehicle, Ticket ticket)
        {
            if (vehicle.Height > ticket.Dimensions.Height)
            {
                var msg = $"Vehicle Height value is too high, it should not be over than {ticket.Dimensions.Height}.";
                ThrowSubstituteTicketMessage(msg, ticket);
            }

            if (vehicle.Width > ticket.Dimensions.Width)
            {
                var msg = $"Vehicle Width value is too high: it should not be over than {ticket.Dimensions.Width}";
                ThrowSubstituteTicketMessage(msg, ticket);
            }

            if (vehicle.Length > ticket.Dimensions.Length)
            {
                var msg = $"Vehicle Length value is too high: it should not be over than {ticket.Dimensions.Length}";
                ThrowSubstituteTicketMessage(msg, ticket);
            }
        }

        private void ThrowSubstituteTicketMessage(string msg, Ticket ticket)
        {
            var offeredSubstituteTicketList = _ticketsLogic.OfferSubstituteTicket(ticket);
            offeredSubstituteTicketList.ForEach(t =>
                msg += " you may replace with " + t.GetType().Name + " you will have to add " + (t.Cost - ticket.Cost));
            throw new HttpStatusException(new BadRequestResult(), msg);
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

        public void DeleteVehicleByLicensePlateId(string licensePlateId)
        {
            var vehicle = GetVehicleById(licensePlateId);
            var parkingLot = _parkingLotsLogic.GetParkingLotByLicensePlateId(licensePlateId);
            _parkingLotsLogic.UpdateParkingLotWithNull(parkingLot);
            _vehicleRepo.DeleteVehicle(vehicle);
        }
    }
}