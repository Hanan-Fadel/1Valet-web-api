using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1Valet_web_api.DomainModels
{
    public class Type
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Device> Devices { get; set; }

    }
}
