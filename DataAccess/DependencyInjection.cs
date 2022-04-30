//using DataAccess.Data.Interfaces;
using DataAccess.Data.Services;
using HamsterWarz.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IHamsterService, HamsterService>();
            services.AddScoped<IMatchDataService, MatchDataService>();
            services.AddScoped<ApplicationDbContext>();
        }
    }
}
