using _1Valet_web_api.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

namespace _1Valet_web_api.Repositories
{
    public class SQLDeviceRepository : IDeviceRepository
    {
        private readonly DbContextClass context;
        public SQLDeviceRepository(DbContextClass context)
        {
            this.context = context;

        }


        public async Task<List<Device>> GetDevices()
        {
            return await context.Device.Include(nameof(DomainModels.Type)).ToListAsync();
        }

        public async Task<Device> GetDevice(Guid deviceId)
        {
            return await context.Device
                .Include(nameof(DomainModels.Type)).FirstOrDefaultAsync(x => x.Id == deviceId);
        }
    }
}
