using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Mutant.Hamburgueria.Repository
{
    public class RepositoryBase
    {
        protected IConfiguration _configuration;

        protected RepositoryBase(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected IDbConnection Connection => new SqlConnection(_configuration.GetConnectionString("MyConnectionString"));
    }
}
