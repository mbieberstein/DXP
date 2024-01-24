using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Cfg
{
    public static class Configuration
    {
        static Configuration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").AddJsonFile("credentials.json")
                .AddEnvironmentVariables()
                .Build();

            ConnectionString = config.GetConnectionString("dxp");
        }

        public static string ConnectionString { get;}
    }
}
