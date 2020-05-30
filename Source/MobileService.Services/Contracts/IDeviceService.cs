namespace MobileService.Services.Contracts
{
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Models.Device;

    public interface IDeviceService
    {
        Task<IEnumerable<DeviceModelServiceModel>> GetAllDeviceModelsAsync();
    }
}
