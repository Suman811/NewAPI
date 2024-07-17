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

        public Task<ResponseModel> CreateSignup(UserModel userModel)
        {

         return _repository.CreateSignup(userModel);
            
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            return;
        }

       

        public Task<ResponseModel> GetDetails()
        {
           return _repository.GetDetails();
        }

        public async Task<ResponseModel> Update(UserModel userModel)
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
