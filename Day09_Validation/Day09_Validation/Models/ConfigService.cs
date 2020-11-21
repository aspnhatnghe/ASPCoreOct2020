using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Day09_Validation.Models
{
    public class ConfigService
    {
        public static string GetByKey(string key)
        {
            try
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("mysettings.json");
                var config = builder.Build();

                return config[key];
            }
            catch
            {
                return null;
            }
        }
    }
}
