using AutoMapper;
using DemoApi.DTOs;
using DemoApi.Models;
using DemoApi.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoApi.Services
{
    public class UsersServices : IUsersServices
    {
        private readonly IMapper _mapper = null;
        private readonly IUsersRepository _iUsersRepository = null;
        public UsersServices(IUsersRepository iUsersRepository, IMapper mapper)
        {
            _iUsersRepository = iUsersRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<UserDto>> GetAllUsersServices(int pageNum)
        {
            try
            {
                IEnumerable<UserModel> userModel = await _iUsersRepository.GetAllUsersRepository(pageNum);
                IEnumerable<UserDto> userDto = _mapper.Map<IEnumerable<UserDto>>(userModel);
                return userDto;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<UserDto> GetByUserIdServices(int userId)
        {
            try
            {
                UserModel userModel = await _iUsersRepository.GetByUserIdRepository(userId);
                UserDto userDto = _mapper.Map<UserDto>(userModel);
                return userDto;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<int> AddUserServices(UserDto userDto)
        {
            int result = 0;
            try
            {
                UserModel userModel = _mapper.Map<UserModel>(userDto);
                result = await _iUsersRepository.AddUserRepository(userModel);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
        public async Task<int> UpdateByUserIdServices(UserDto userDto)
        {
            int result = 0;
            try
            {
                UserModel userModel = _mapper.Map<UserModel>(userDto);
                result = await _iUsersRepository.UpdateByUserIdRepository(userModel);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
        public async Task<int> DeleteByIdServices(int userId)
        {
            int result = 0;
            try
            {
                result = await _iUsersRepository.DeleteByIdUserRepository(userId);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
