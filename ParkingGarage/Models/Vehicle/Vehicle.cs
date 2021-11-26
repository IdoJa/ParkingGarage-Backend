﻿using System.ComponentModel.DataAnnotations;
using ParkingGarage.Models.ParkingLot;

namespace Vehicle
{
    public class Vehicle
    {
        [Key] public int LicensePlateId { get; set; }
        
        /// <summary>
        ///     May be: [A, B, C] only.
        /// </summary>
        public string Class { get; set; }
        
        /// <summary>
        ///     May be: [Vip, Value, Regular] only.
        /// </summary>
        public string Ticket { get; set; }
        
        public int Height { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public ParkingLot ParkingLot { get; set; }
    }
}