using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration.Json;

namespace WorkOutAppDatabase
{
    public static class SetDatabase
    {
        public static DbContextOptions<ApplicationDbContext> dbContextOptionsBuilder()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(configuration.GetConnectionString("Default")).Options;
            return options;
        }
    }
}
