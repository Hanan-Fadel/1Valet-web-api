
using _1Valet_web_api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace _1Valet_web_api.Repositories
{
    public interface IDeviceRepository
    {
        Task<List<Device>> GetDevices();
        Task<Device> GetDevice(Guid deviceId);
    }
}
