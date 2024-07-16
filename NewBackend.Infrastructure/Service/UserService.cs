using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NewBackend.Application.IRepository;
using NewBackend.Application.IService;
using NewBackend.Domain.Entity;
using NewBackend.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace NewBackend.Infrastructure.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IConfiguration _config;
        public UserService(IUserRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _config =configuration;

        }

        public Task<int> CreateSignup(UserModel userModel)
        {

         return  _repository.CreateSignup(userModel);
            
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            return;
        }

        public string GenerateToken(LoginDetails loginDetails)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], null,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
           
        }

        public Task<IEnumerable<UserModel>> GetDetails()
        {
           return _repository.GetDetails();
        }

        public async Task<int> Update(UserModel userModel)
        {
           var result=await _repository.Update(userModel);
           return result;
           
        }
        public async Task<int> Validate(LoginDetails loginDetails)
        {
            return await _repository.Validate(loginDetails);
        }

       
       
    }
}
