using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBackend.Domain.Entity
{
    public static class StaticData
    {
        public static string successMessage = "Successfully logged in";
        public static string errorMessage = "Failed to login";
        public static string createMessage = "created successfully";
        public static string updateMessage = "updated successfully";
        public static string deleteMessage = "deleted successfully";
        public static int successcode = 200;
        public static int errorCode =500;
        public static object? data = null;

    }
}
