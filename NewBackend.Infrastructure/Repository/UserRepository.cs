using Dapper;
using Microsoft.IdentityModel.Tokens;
using NewBackend.Application.IRepository;
using NewBackend.Application.ProceduresUsed;
using NewBackend.Domain.Entity;
using NewBackend.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBackend.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext _dapperContext;
        public UserRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }


        public async Task<int> CreateSignup(UserModel userModel)
        {
            try
            {
                using (var connection = _dapperContext.CreateConnection())
                {
                    var query = procedure.Insert;
                    var parameter = new
                    {
                        firstname = userModel.FirstName,
                        lastname = userModel.LastName,
                        phonenumber = userModel.PhoneNumber,
                        country = userModel.SelectedCountry,
                        state = userModel.SelectedState,
                        gender = userModel.Gender,
                        email = userModel.Email,
                        password = userModel.Password,

                    };
                    var message = await connection.ExecuteAsync(query, parameter, commandType: CommandType.StoredProcedure);
                    return message;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            
        }
        public async Task<IEnumerable<UserModel>> GetDetails()
        {
            try
            {
                using (var connection = _dapperContext.CreateConnection())
                {
                    var query = procedure.Get;
                    var message = await connection.QueryAsync<UserModel>(query, commandType: CommandType.Text);
                    return message;
                }
            }
            catch(Exception ex)
            { 
                Console.WriteLine(ex.Message);
                return Enumerable.Empty<UserModel>();
            }
        }
        public async Task<int> Update(UserModel userModel)
        {
            try
            {
                using (var connection = _dapperContext.CreateConnection())
                {
                    var query = procedure.Update;
                    var parameter = new
                    {
                        Id = userModel.UserID,
                        firstname = userModel.FirstName,
                        lastname = userModel.LastName,
                        phonenumber = userModel.PhoneNumber,
                        country = userModel.SelectedCountry,
                        state = userModel.SelectedState,
                        gender = userModel.Gender,
                        email = userModel.Email,
                        password = userModel.Password,

                    };
                    var result = await connection.ExecuteAsync(query, parameter, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex) 
            {
                
                Console.WriteLine(ex.Message);
                return 0;
            }


        }
        public void Delete(int id)
        {
            try
            {
                using (var connection = _dapperContext.CreateConnection())
                {
                    var query = procedure.Delete;
                    var param = new
                    {
                        id = id
                    };
                    connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
              
            }
        }

        public async Task<int> Validate(LoginDetails loginDetails)
        {
            try
            {
                using (var connection = _dapperContext.CreateConnection())
                {
                    var query = procedure.Validate;
                    var param = new { loginDetails.Email, loginDetails.Password };
                    var result = await connection.QueryFirstOrDefaultAsync<int>(query, param, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;

            }
        }
    } 
}