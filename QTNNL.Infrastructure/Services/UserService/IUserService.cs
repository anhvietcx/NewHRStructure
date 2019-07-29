using QTNNL.Core.Entities;
using QTNNL.Core.ViewModels.UserViewModels;
using System.Threading.Tasks;

namespace QTNNL.Infrastructure.Services.UserService
{
    public interface IUserService
    {
        Task<User> Authenticate(UserDto user);
    }
}
