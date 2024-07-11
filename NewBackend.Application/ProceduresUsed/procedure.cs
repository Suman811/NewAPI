using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBackend.Application.ProceduresUsed
{
    public static class procedure

    {
        public const string Get = "Select * from tbl_UserDetails_Suman u join tbl_LoginCredentials_Suman l on u.UserId=l.UserID";
        public const string Insert = "SP_Signup_Suman";
             public const string Delete = "SP_Delete";
        public const string Update = "SP_Update_Suman";
        public const String Validate = "SP_Match";
    }
}
