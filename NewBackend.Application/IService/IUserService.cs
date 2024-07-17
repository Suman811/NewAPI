using NewBackend.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBackend.Application.IService
{
    public interface IUserService
    {
        Task<ResponseModel> CreateSignup(UserModel userModel);
        Task<ResponseModel> GetDetails();
        Task <ResponseModel> Update(UserModel userModel);
        void Delete(int id);
        Task<int> Validate(LoginDetails loginDetails);
       // string GenerateToken(LoginDetails loginDetails);
    }
}
