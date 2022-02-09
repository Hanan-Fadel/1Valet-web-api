using _1Valet_web_api.DomainModels;
using _1Valet_web_api.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _1Valet_web_api.Controllers
{
    //We need to inject the device repository 

    [ApiController]
    public class DevicesController : Controller
    {
 
        private readonly IDeviceRepository deviceRepository;
        private readonly IMapper mapper;

        public DevicesController(IDeviceRepository deviceRepository, IMapper mapper)
        {
            this.deviceRepository = deviceRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllDevices()
        {
           var devices = await deviceRepository.GetDevices();

            var domainModelsDevices = new List<Device>();

            foreach (var device in devices)
            {
                domainModelsDevices.Add(new Device()
                {
                    Id = device.Id,
                    DeviceName = device.DeviceName,
                    DeviceStatus = device.DeviceStatus,
                    DeviceUsage = device.DeviceUsage,
                    DeviceTemp = device.DeviceTemp,
                    TypeId = device.TypeId,
                    Type = new DomainModels.Type()
                    {
                        Id = device.Type.Id,
                        Name = device.Type.Name,
                        Description = device.Type.Description
                    }
                });

            }

            return Ok(domainModelsDevices);
           // return Ok(mapper.Map<List<Device>>(devices));

        }

        [HttpGet]
        [Route("[controller]/{deviceId:guid}")]
        public async Task<IActionResult> GetDevice([FromRoute] Guid deviceId)
        {
            //Fetch a signle device details
            var device = await deviceRepository.GetDevice(deviceId);

            if (device == null)
            {
                return NotFound();
            }

            var domainModelsDevice = new Device() 
            { 
                    Id = device.Id,
                    DeviceName = device.DeviceName,
                    DeviceStatus = device.DeviceStatus,
                    DeviceUsage = device.DeviceUsage,
                    DeviceTemp = device.DeviceTemp,
                    TypeId = device.TypeId,
                    Type = new DomainModels.Type()
                    {
                        Id = device.Type.Id,
                        Name = device.Type.Name,
                        Description = device.Type.Description
                    }
            };

            return Ok(domainModelsDevice);
            

        }


    }
}
