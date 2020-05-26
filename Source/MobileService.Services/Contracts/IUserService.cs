using MobileService.Services.Models;
using System.Threading.Tasks;

namespace MobileService.Services.Contracts
{
    public interface IUserService
    {
        Task<UserServiceModel> GetUser();
    }
}
