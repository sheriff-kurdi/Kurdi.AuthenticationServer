using Kurdi.AuthenticationServer.Services.Handlers;
using Kurdi.AuthenticationServer.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Kurdi.AuthenticationServer.Services
{
    public class AuthenticationService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly TokenGenerator tokenHandeler;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IHttpContextAccessor httpContextAccessor;

        public AuthenticationService(UserManager<IdentityUser> userManager, TokenGenerator tokenHandeler, RoleManager<IdentityRole> roleManager, IHttpContextAccessor httpContextAccessor)
        {
            this.userManager = userManager;
            this.tokenHandeler = tokenHandeler;
            this.roleManager = roleManager;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<object> Register(RegisterVM registerVM)
        {
            var userExists = await userManager.FindByNameAsync(registerVM.Email);
            if (registerVM.ConfirmPassword != registerVM.Password)
            {
                return new { Status = "Error", Message = "Password do not match!" };
            }
            if (userExists != null)
            {
                return new { Status = "Error", Message = "User already exists!" };
            }

            IdentityUser user = new IdentityUser
            {
                Email = registerVM.Email,
                UserName = registerVM.Email,
            };

            var result = await userManager.CreateAsync(user, registerVM.Password);



            if (!result.Succeeded)
            {
                return new { Status = "Error", Message = result.Errors };
            }


            var authClaims = new List<Claim>
             {
                new Claim(ClaimTypes.Name, user.UserName),
             };

            return new { Status = "Success", Message = "User created successfully!", email = registerVM.Email, token = tokenHandeler.GenetrateToken(authClaims) };
        }
        public async Task<object> Login(LoginVM loginVM)
        {

            var user = await userManager.FindByNameAsync(loginVM.Email);
            if (user == null)
            {
                return new { Status = "Error", Message = "You are not registerd yet!" };

            }



            if (!await userManager.CheckPasswordAsync(user, loginVM.Password))
            {
                return new { Status = "Error", Message = "Login failed! Please check user details , password and try again." };
            }


            var userRoles = await userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
             {
                new Claim(ClaimTypes.Name, user.UserName),
             };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            return new { Status = "Success", id = user.Id, email = loginVM.Email, token = tokenHandeler.GenetrateToken(authClaims) };


        }
    }
}
