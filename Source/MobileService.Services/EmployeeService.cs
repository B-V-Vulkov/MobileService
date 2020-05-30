namespace MobileService.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Data;
    using Contracts;
    using Models.Employee;

    using static Security.PasswordHasher;

    public class EmployeeService : IEmployeeService
    {
        private readonly MobileServiceDbContext dbContext;
        private readonly IMapper mapper;

        public EmployeeService(MobileServiceDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ServiceWorkerServiceModel>> GetAllServiceWorkers()
        {
            var serviceWorkers = await this.dbContext.Employees
                .Where(x => x.EmployeePositionId == 3)
                .ProjectTo<ServiceWorkerServiceModel>(this.mapper.ConfigurationProvider)
                .ToListAsync();

            return serviceWorkers;
        }

        public async Task<EmployeeServiceModel> GetEmployeeAsync(string email, string password)
        {
            var employee = await this.dbContext.Employees
                .ProjectTo<EmployeeServiceModel>(this.mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Email == email);

            if (employee == null)
            {
                throw new Exception($"There is no employee with email: {email}");
            }

            if (!VerifyHashedPassword(employee.Password, password))
            {
                throw new Exception($"Invalid password");
            }

            return employee;
        }
    }
}
