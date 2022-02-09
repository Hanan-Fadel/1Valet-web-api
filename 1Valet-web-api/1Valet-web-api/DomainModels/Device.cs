using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1Valet_web_api.DomainModels
{
    public class Device
    {
        public Guid Id { get; set; }

        public string DeviceName { get; set; }
        public string DeviceStatus { get; set; }
        public string DeviceUsage { get; set; }
        public string DeviceTemp { get; set; }
        public Guid TypeId { get; set; }
        public Type Type { get; set; }

    }
}
