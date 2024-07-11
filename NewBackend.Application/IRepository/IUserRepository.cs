using NewBackend.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBackend.Application.IRepository
{
    public interface IUserRepository
    {

        Task<int> CreateSignup(UserModel userModel);
        Task<IEnumerable<UserModel>> GetDetails();
        Task<int> Update(UserModel userModel);
        void Delete(int id);
        Task<int> Validate(LoginDetails loginDetails);
    }
}
