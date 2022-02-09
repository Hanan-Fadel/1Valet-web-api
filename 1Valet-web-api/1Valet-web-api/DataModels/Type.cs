using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _1Valet_web_api.Models
{
    public class Type
    {

        [Key]
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }

        //Navigation properties shows the relationship with the Devices table 
        public List<Device> Devices { get; set; }

    }

}
