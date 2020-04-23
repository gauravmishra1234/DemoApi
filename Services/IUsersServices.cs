using DemoApi.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoApi.Services
{
    public interface IUsersServices
    {
        Task<IEnumerable<UserDto>> GetAllUsersServices(int pageNum);
        Task<UserDto> GetByUserIdServices(int userId);
        Task<int> AddUserServices(UserDto userDto);
        Task<int> UpdateByUserIdServices(UserDto userDto);
        Task<int> DeleteByIdServices(int userId);
    }
}
