﻿using CartellinoRosso.Core;
using CartellinoRosso.Core.Interface;
using CartellinoRosso.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CartellinoRosso
{
    public class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            // Configura la lettura del file appsettings.json
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Configura il DbContext
            services.AddDbContext<DbContext>(options =>
                options.UseSqlite(config.GetConnectionString("DefaultConnection")));

            // Configura il DI container
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IConfiguration>(config)
                .AddScoped<IFileService, FileService>()
                .AddScoped<INameService, NameService>()
                .AddScoped<IPlayerService, PlayerService>()
                .AddScoped<IStaffService, StaffService>()
                .AddScoped<IClubService, ClubService>()
                .BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                var service = scope.ServiceProvider.GetRequiredService<IClubService>();

                Console.WriteLine("Generating clubs...");
                for (int i = 0; i < 10; i++)
                {
                    var x = service.GenerateClub();
                }
            }
        }
    }
}