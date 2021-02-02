﻿using Microsoft.Extensions.Configuration;

namespace WebPortal.Logic.Helpers.Sql
{
    public interface IConnectionStringHelper
        {
            public string ConnectionString { get; }
        }

    public class ConnectionStringHelper : IConnectionStringHelper
    {
        public string ConnectionString { get; set; }
        public ConnectionStringHelper(IConfiguration connectionString)
        {
            ConnectionString = connectionString["ConnectionStrings:DefaultConnection"];
        }
    }
}