namespace MobileService.Services
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Data;
    using Contracts;
    using Models.Device;

    public class DeviceService : IDeviceService
    {
        private readonly MobileServiceDbContext dbContext;
        private readonly IMapper mapper;

        public DeviceService(MobileServiceDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<DeviceModelServiceModel>> GetAllDeviceModelsAsync()
        {
            var deviceModels = await this.dbContext.DeviceModels
                .ProjectTo<DeviceModelServiceModel>(this.mapper.ConfigurationProvider)
                .ToListAsync();

            return deviceModels;
        }
    }
}
