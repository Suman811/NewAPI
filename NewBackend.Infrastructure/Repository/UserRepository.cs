using Dapper;
using Microsoft.IdentityModel.Tokens;
using NewBackend.Application.IRepository;
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
            using (var connection = _dapperContext.CreateConnection())
            {
                var query = "SP_Signup_Suman";
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
        public async Task<IEnumerable<UserModel>> GetDetails()
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var query = "Select * from tbl_UserDetails_Suman u join tbl_LoginCredentials_Suman l on u.UserId=l.UserID";
                var message = await connection.QueryAsync<UserModel>(query, commandType: CommandType.Text);
                return message;
            }
        }
        public async Task<int> Update(UserModel userModel)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var query = "SP_Update_Suman";
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
        public void Delete(int id )
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                var query = "SP_Delete";
                var param = new
                    {
                    id = id
                };
                connection.ExecuteAsync(query,param,commandType:CommandType.StoredProcedure);
            }
        }

    }
}
