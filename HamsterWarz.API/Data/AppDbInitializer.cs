﻿using HamsterWarz.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamsterWarz.API.Data
{
    public class AppDbInitializer
    {
        private readonly AppDbContext _context;

        public AppDbInitializer(AppDbContext context)
        {
            _context = context;
        }

        public static void Initialize(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                if (!context.Hamsters.Any())
                {
                    context.Hamsters.AddRange(new List<Hamster>()
                    {
                        new Hamster
                        {
                            Name = "Scooby",
                            ImageUrl = "/Content/Images/hamster-1.jpg",
                            Age = 1,
                            Loves = "World of Warcraft",
                            FavoriteFood = "Chinese food"
                        },
                        new Hamster
                        {
                            Name = "Shaggy",
                            ImageUrl = "/Content/Images/hamster-2.jpg",
                            Age = 2,
                            Loves = "Rugby",
                            FavoriteFood = "Broccoli"
                        },
                        new Hamster
                        {
                            Name = "Fred",
                            ImageUrl = "/Content/Images/hamster-3.jpg",
                            Age = 3,
                            Loves = "Football",
                            FavoriteFood = "Chicken and Rice"
                        },
                        new Hamster
                        {
                            Name = "George",
                            ImageUrl = "/Content/Images/hamster-4.jpg",
                            Age = 1,
                            Loves = "Skateboarding",
                            FavoriteFood = "Pizza"
                        },
                        new Hamster
                        {
                            Name = "Harry",
                            ImageUrl = "/Content/Images/hamster-5.jpg",
                            Age = 1,
                            Loves = "Running",
                            FavoriteFood = "Chinese food"
                        },
                        new Hamster
                        {
                            Name = "Ron",
                            ImageUrl = "/Content/Images/hamster-6.jpg",
                            Age = 1,
                            Loves = "Golfing",
                            FavoriteFood = "McDonalds"
                        },
                        new Hamster
                        {
                            Name = "Dumbledore",
                            ImageUrl = "/Content/Images/hamster-7.jpg",
                            Age = 1,
                            Loves = "Sleeping",
                            FavoriteFood = "Carrots"
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
