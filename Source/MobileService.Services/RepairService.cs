namespace MobileService.Services
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Data;
    using Contracts;
    using Models.Repair;
    using System.Linq;

    public class RepairService : IRepairService
    {
        private readonly MobileServiceDbContext dbContext;
        private readonly IMapper mapper;

        public RepairService(MobileServiceDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<RepairTypeServiceModel>> GetAllRepairTypesAsync()
        {
            var repairTypes = await this.dbContext.RepairTypes
                .ProjectTo<RepairTypeServiceModel>(this.mapper.ConfigurationProvider)
                .ToListAsync();

            return repairTypes;
        }

        public async Task<double> GetRepairPrice(int repairTypeId, int deviceModelId)
        {
            var price = await this.dbContext.RepairPrices
                .Where(x => x.RepairTypeId == repairTypeId && x.DeviceModelId == deviceModelId)
                .Select(x => x.Price)
                .FirstOrDefaultAsync();

            return price;
        }
    }
}
