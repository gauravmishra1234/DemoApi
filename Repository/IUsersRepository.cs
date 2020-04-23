using DemoApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoApi.Repository
{
    public interface IUsersRepository
    {
        Task<IEnumerable<UserModel>> GetAllUsersRepository(int pageNum);
        Task<UserModel> GetByUserIdRepository(int userId);
        Task<int> AddUserRepository(UserModel user);
        Task<int> UpdateByUserIdRepository(UserModel user);
        Task<int> DeleteByIdUserRepository(int userId);
    }
}
