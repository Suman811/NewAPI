﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace NewBackend.Infrastructure.Data
{
    public class DapperContext
    {
       private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration= configuration;
            _connectionString=configuration.GetConnectionString("connect");
        }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
