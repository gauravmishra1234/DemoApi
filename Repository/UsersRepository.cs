using DemoApi.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DemoApi.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IConfiguration _config;
        string conStr = string.Empty;
        public UsersRepository(IConfiguration config)
        {
            _config = config;
            conStr = _config.GetConnectionString("DBConnection");
        }
        public async Task<IEnumerable<UserModel>> GetAllUsersRepository(int pageNum)
        {
            SqlConnection sqlConnection = null;
            SqlDataReader sqlDataReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                sqlConnection = new SqlConnection(conStr);
                await sqlConnection.OpenAsync();
                sqlCommand = new SqlCommand("GetAllUser", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                List<UserModel> resultList = new List<UserModel>();
                if (sqlDataReader != null)
                {
                    while (sqlDataReader.Read())
                    {
                        UserModel entity = new UserModel();
                        entity.UserId = (int)sqlDataReader["UserID"];
                        entity.FirstName = (string)sqlDataReader["FirstName"];
                        entity.LastName = (string)sqlDataReader["LastName"];
                        entity.PhoneNumber = !Convert.IsDBNull(sqlDataReader["PhoneNumber"]) ? (string)sqlDataReader["PhoneNumber"] : null;
                        entity.Email = (string)sqlDataReader["Email"];
                        entity.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
                        entity.CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]);
                        entity.CreatedBy = (int)sqlDataReader["CreatedBy"];
                        entity.UpdatedDate = Convert.ToDateTime(sqlDataReader["UpdatedDate"]);
                        entity.UpdatedBy = (int)sqlDataReader["UpdatedBy"];
                        resultList.Add(entity);
                    }
                }
                return resultList;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConnection.Close();
                sqlDataReader.Close();
                sqlDataReader.Dispose();
            }
        }
        public async Task<UserModel> GetByUserIdRepository(int userId)
        {
            SqlConnection sqlConnection = null;
            SqlDataReader sqlDataReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                sqlConnection = new SqlConnection(conStr);
                await sqlConnection.OpenAsync();
                sqlCommand = new SqlCommand("GetUserProfileByUserID", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@UserID", SqlDbType.VarChar).Value = userId;

                sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                UserModel user = new UserModel();
                if (sqlDataReader != null)
                {
                    while (sqlDataReader.Read())
                    {
                        user.UserId = (int)sqlDataReader["UserID"];
                        user.FirstName = (string)sqlDataReader["FirstName"];
                        user.LastName = (string)sqlDataReader["LastName"];
                        user.PhoneNumber = !Convert.IsDBNull(sqlDataReader["PhoneNumber"]) ? (string)sqlDataReader["PhoneNumber"] : null;
                        user.Email = (string)sqlDataReader["Email"];
                        user.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
                        user.CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]);
                        user.CreatedBy = (int)sqlDataReader["CreatedBy"];
                        user.UpdatedDate = Convert.ToDateTime(sqlDataReader["UpdatedDate"]);
                        user.UpdatedBy = (int)sqlDataReader["UpdatedBy"];
                    }
                }
                return user;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConnection.Close();
                sqlDataReader.Close();
                sqlDataReader.Dispose();
            }
        }
        public async Task<int> AddUserRepository(UserModel user)
        {
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            int RequestStatus = 0;
            sqlConnection = new SqlConnection(conStr);
            try
            {
                await sqlConnection.OpenAsync();
                sqlCommand = new SqlCommand("AddUserDetails", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = user.FirstName;
                sqlCommand.Parameters.Add("@LastName", SqlDbType.VarChar).Value = user.LastName;
                sqlCommand.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = user.PhoneNumber;
                sqlCommand.Parameters.Add("@Email", SqlDbType.NVarChar).Value = user.Email;
                sqlCommand.Parameters.Add("@IsActive", SqlDbType.Bit).Value = true;
                sqlCommand.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = user.CreatedBy;
                sqlCommand.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = user.UpdatedBy;
                SqlParameter RuturnValue = new SqlParameter("@returnValue", SqlDbType.Int);
                RuturnValue.Direction = ParameterDirection.Output;
                sqlCommand.Parameters.Add(RuturnValue);
                await sqlCommand.ExecuteNonQueryAsync();
                RequestStatus = (int)sqlCommand.Parameters["@returnValue"].Value;
                return RequestStatus;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }

        }
        public async Task<int> UpdateByUserIdRepository(UserModel user)
        {
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            int RequestStatus = 0;
            sqlConnection = new SqlConnection(conStr);
            try
            {

                await sqlConnection.OpenAsync();
                sqlCommand = new SqlCommand("UpdateUserDetails", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@UserID", SqlDbType.VarChar).Value = user.UserId;
                sqlCommand.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = user.FirstName;
                sqlCommand.Parameters.Add("@LastName", SqlDbType.VarChar).Value = user.LastName;
                sqlCommand.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = user.PhoneNumber;
                sqlCommand.Parameters.Add("@Email", SqlDbType.NVarChar).Value = user.Email;
                sqlCommand.Parameters.Add("@IsActive", SqlDbType.Bit).Value = true;
                sqlCommand.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = user.CreatedBy;
                sqlCommand.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = user.UpdatedBy;
                SqlParameter RuturnValue = new SqlParameter("@returnValue", SqlDbType.Int);
                RuturnValue.Direction = ParameterDirection.Output;
                sqlCommand.Parameters.Add(RuturnValue);
                await sqlCommand.ExecuteNonQueryAsync();
                RequestStatus = (int)sqlCommand.Parameters["@returnValue"].Value;
                return RequestStatus;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public async Task<int> DeleteByIdUserRepository(int userId)
        {
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            int RequestStatus = 0;
            sqlConnection = new SqlConnection(conStr);
            try
            {

                await sqlConnection.OpenAsync();
                sqlCommand = new SqlCommand("DeleteUserDetails", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@UserID", SqlDbType.Int).Value = userId;
                sqlCommand.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = userId;
                SqlParameter RuturnValue = new SqlParameter("@returnValue", SqlDbType.Int);
                RuturnValue.Direction = ParameterDirection.Output;
                sqlCommand.Parameters.Add(RuturnValue);
                await sqlCommand.ExecuteNonQueryAsync();
                RequestStatus = (int)sqlCommand.Parameters["@returnValue"].Value;
                return RequestStatus;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
