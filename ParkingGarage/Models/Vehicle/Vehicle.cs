using System.ComponentModel.DataAnnotations;

namespace Vehicle
{
    public class Vehicle
    {
        [Key] 
        public int LicensePlateId { get; set; }

        public enum ETicketType
        {
            Vip,
            Value,
            Regular
        }
        
        public ETicketType TicketType { get; set; }
        
        private enum VehicleType
        {
            ClassA,
            ClassB,
            ClassC
        }
        
        
        

        public int Height { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        
        
        
    }
}