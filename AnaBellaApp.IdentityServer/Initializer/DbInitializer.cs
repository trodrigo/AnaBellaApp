using AnaBellaApp.IdentityServer.Configuration;
using AnaBellaApp.IdentityServer.Model;
using AnaBellaApp.IdentityServer.Model.Context;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace AnaBellaApp.IdentityServer.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly MySQLContext context;
        private readonly UserManager<ApplicationUser> user;
        private readonly RoleManager<IdentityRole> role;

        public DbInitializer(MySQLContext context,
            UserManager<ApplicationUser> user,
            RoleManager<IdentityRole> role)
        {
            this.context = context;
            this.user = user;
            this.role = role;
        }

        public void Initialize()
        {
            if (role.FindByNameAsync(IdentityConfiguration.Admin).Result != null) 
                return;
            role.CreateAsync(new IdentityRole(
                IdentityConfiguration.Admin)).GetAwaiter().GetResult();
            role.CreateAsync(new IdentityRole(
                IdentityConfiguration.Client)).GetAwaiter().GetResult();

            ApplicationUser admin = new ApplicationUser()
            {
                UserName = "rubi-admin",
                Email = "rubisurrentino254@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "+55 (13) 97819-1479",
                FirstName = "Rubi",
                LastName = "Santos"
            };

            user.CreateAsync(admin, "Rubi@3008").GetAwaiter().GetResult();
            user.AddToRoleAsync(admin,
                IdentityConfiguration.Admin).GetAwaiter().GetResult();
            var adminClaims = user.AddClaimsAsync(admin, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{admin.FirstName} {admin.LastName}"),
                new Claim(JwtClaimTypes.GivenName, admin.FirstName),
                new Claim(JwtClaimTypes.FamilyName, admin.LastName),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Admin)
            }).Result;

            ApplicationUser client = new ApplicationUser()
            {
                UserName = "test-client",
                Email = "test@test.com",
                EmailConfirmed = true,
                PhoneNumber = "+55 (13) 97813-6793",
                FirstName = "Test",
                LastName = "Client"
            };

            user.CreateAsync(client, "Link@123").GetAwaiter().GetResult();
            user.AddToRoleAsync(client,
                IdentityConfiguration.Client).GetAwaiter().GetResult();
            var clientClaims = user.AddClaimsAsync(client, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{client.FirstName} {client.LastName}"),
                new Claim(JwtClaimTypes.GivenName, client.FirstName),
                new Claim(JwtClaimTypes.FamilyName, client.LastName),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Client)
            }).Result;
        }
    }
}
