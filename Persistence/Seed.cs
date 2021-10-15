using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        DisplayName = "Hassan",
                        UserName = "sharafi",
                        Email = "sharafi@test.com"
                    }
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }

            if (!await context.Products.AnyAsync())
            {
                for (int i = 1; i < 101; i++)
                {
                    var product = new Product()
                    {
                        Id = Guid.NewGuid(),
                        Title = $"Product{i}",
                        Type = (ProductType) int.Parse(GetRandomNumber(3, true).ToString() ?? "0"),
                        Color = (ProductColor) int.Parse(GetRandomNumber(3, true).ToString() ?? "0"),
                        Price = double.Parse(GetRandomNumber(100000, false).ToString() ?? "10000")
                    };
                    context.Products.Add(product);
                }

                await context.SaveChangesAsync();

            }
        }

        private static object GetRandomNumber(int range, bool isInt)
        {
            Random r = new Random();
            return isInt
                ? r.Next(0, range)
                : r.NextDouble() * range;
        }
    }
}