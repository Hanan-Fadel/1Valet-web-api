using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace _1Valet_web_api.Models
{
    public class Device
    {
        [Key]
        public Guid Id { get; set; }

        public string DeviceName { get; set; }
        public string DeviceStatus { get; set;}
        public string DeviceUsage { get; set; }
        public string DeviceTemp { get; set; }

        [Required]
        public Guid TypeId { get; set; }
        //Navigation properties shows the relationship with the DevicesTypes table 
        public Type Type { get; set; }



    }
}
