namespace MobileService.Services
{
    using System.Linq;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using MobileService.Services.Contracts;
    using MobileService.Services.Models;

    public class UserService : IUserService
    {
        private readonly MobileServiceDbContext dbContext;
        private readonly IMapper mapper;

        public UserService(MobileServiceDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<UserServiceModel> GetUser()
        {
            UserServiceModel user = await dbContext.Users
                .ProjectTo<UserServiceModel>(this.mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            return user;
        }
    }
}
