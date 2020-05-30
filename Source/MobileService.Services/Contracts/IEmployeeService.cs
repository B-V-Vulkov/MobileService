namespace MobileService.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Models.Employee;

    public interface IEmployeeService
    {
        Task<EmployeeServiceModel> GetEmployeeAsync(string email, string password);

        Task<IEnumerable<ServiceWorkerServiceModel>> GetAllServiceWorkers();
    }
}
