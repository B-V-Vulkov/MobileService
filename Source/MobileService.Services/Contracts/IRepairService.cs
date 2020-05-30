namespace MobileService.Services.Contracts
{
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Models.Repair;

    public interface IRepairService
    {
        Task<IEnumerable<RepairTypeServiceModel>> GetAllRepairTypesAsync();

        Task<double> GetRepairPrice(int repairTypeId, int deviceModelId);
    }
}
