using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class IdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Kendrick",
                    Email = "kendrickchuks@gmail.com",
                    UserName = "kendrickchuks@gmail.com",
                    Address = new Address
                    {
                        FirstName = "Kendrick",
                        LastName = "Chukwuka",
                        Street = "10 The Street",
                        City = "Missouri",
                        State = "MS",
                        Zipcode = "90210"

                    }
                };
                await userManager.CreateAsync(user, "Pa$$w0rd2245");    
            }
        }
    }
}
