using NewBackend.Application.IRepository;
using NewBackend.Application.IService;
using NewBackend.Domain.Entity;
using NewBackend.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace NewBackend.Infrastructure.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
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

        public Task<IEnumerable<UserModel>> GetDetails()
        {
           return _repository.GetDetails();
        }

        public async Task<int> Update(UserModel userModel)
        {
           var result=await _repository.Update(userModel);
           return result;
           
        }
    }
}
