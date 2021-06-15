using System.Threading.Tasks;
using WorkOutAppApi.Shared.Models;

namespace WorkOutAppApi.Client.Services
{
    public interface IAuthenticationService
    {
        Task<LoginUser> LoginAsync(LoginUser user);
        Task<RegisterModel> RegisterUserAsync(RegisterModel user);
    }
}