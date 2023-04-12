using Kurdi.AuthenticationServer.Services.Handlers;
using Kurdi.AuthenticationService.Core.Entities;
using Kurdi.AuthenticationService.Core.VM;
using Kurdi.AuthenticationService.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Kurdi.AuthenticationServer.Services
{
    public class AuthenticationService
    {
        private readonly UserManager<User> _userManager;

        private readonly TokenGenerator _tokenGenerator;
        private readonly AppDbContext _dbContext;

        public AuthenticationService(TokenGenerator tokenHandeler, AppDbContext dbContext, UserManager<User> userManager)
        {
            this._tokenGenerator = tokenHandeler;
            this._dbContext = dbContext;
            this._userManager = userManager;

        }
        public async Task<object> Register(RegisterVM registerVM)
        {
            bool isUserExisted = this._dbContext.Users.Any(user => user.Email == registerVM.Email);
            if (registerVM.ConfirmPassword != registerVM.Password)
            {
                return new { Status = "Error", Message = "Password do not match!" };
            }
            if (isUserExisted)
            {
                return new { Status = "Error", Message = "User already exists!" };
            }

            User user = new User
            {
                //TODO: configure saveDatabseContext to set created at and updated at
                Email = registerVM.Email,
                FirstName = registerVM.FirstName,
                LastName = registerVM.LastName,

            };

            await this._dbContext.AddAsync(user);
            await this._dbContext.SaveChangesAsync();

            return new { Status = "Success", Message = "User created successfully!", email = registerVM.Email };
        }
        public async Task<object> Login(LoginVM loginVM)
        {

            var user = await _userManager.FindByEmailAsync(loginVM.Email);
            if (user == null)
            {
                return new { Status = "Error", Message = "You are not registerd yet!" };

            }

            if (!await _userManager.CheckPasswordAsync(user, loginVM.Password))
            {
                return new { Status = "Error", Message = "Login failed! Please check user details , password and try again." };
            }


            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
             {
                new Claim(ClaimTypes.Name, user.UserName),
             };

            foreach (Authority authority in user.Authorities)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, authority.GetAuthority()));
            }
            return new { Status = "Success", id = user.Id, email = loginVM.Email, token = _tokenGenerator.GenetrateToken(authClaims) };
        }
    }
}
