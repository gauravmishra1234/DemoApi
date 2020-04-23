using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DemoApi.DTOs;
using DemoApi.Helpers;
using DemoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUsersServices _iUsersServices = null;
        public UsersController(IUsersServices iUsersServices)
        {
            _iUsersServices = iUsersServices;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers(int pageNum)
        {
            try
            {
                IEnumerable<UserDto> users = await _iUsersServices.GetAllUsersServices(pageNum);
                return Ok(users);
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog("UsersController=> GetAllUsers=> Catch=> " + ex.Message);
                throw ex;
            }
        }
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetByUserId(int userId)
        {
            try
            {
                UserDto user = await _iUsersServices.GetByUserIdServices(userId);
                return Ok(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public async Task<int> AddUser([FromBody] UserDto userDto)
        {

            try
            {
                return await _iUsersServices.AddUserServices(userDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public async Task<int> UpdateByUserId([FromBody] UserDto userDto)
        {
            try
            {
                return await _iUsersServices.UpdateByUserIdServices(userDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete]
        public async Task<int> DeleteByIdUser(int userId)
        {
            try
            {
                return await _iUsersServices.DeleteByIdServices(userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}