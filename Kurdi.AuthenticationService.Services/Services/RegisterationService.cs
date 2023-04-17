using Kurdi.AuthenticationService.Services.Handlers;
using Kurdi.AuthenticationService.Core.Entities;
using Kurdi.AuthenticationService.Core.Entities.Authorities;
using Kurdi.AuthenticationService.Core.VM;
using Kurdi.AuthenticationService.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Kurdi.AuthenticationService.Core.Exceptions;

namespace Kurdi.AuthenticationService.Services
{
    public class RegisterationService
    {
        private readonly UserManager<User> _userManager;
        private readonly TokenGenerator _tokenGenerator;
        private readonly AppDbContext _dbContext;

        public RegisterationService(TokenGenerator tokenHandeler, AppDbContext dbContext, UserManager<User> userManager)
        {
            this._tokenGenerator = tokenHandeler;
            this._dbContext = dbContext;
            this._userManager = userManager;

        }
        public async Task Register(RegisterVM registerVM)
        {
            var userExists = await this._userManager.FindByEmailAsync(registerVM.Email);
            if (registerVM.ConfirmPassword != registerVM.Password)
            {
                throw new PasswordsNotMatchedException();
            }
            if (userExists != null)
            {
                throw new UserAlreadyExistedException();
            }

            User user = new User
            {
                Email = registerVM.Email,
                UserName = registerVM.Email,
            };

            var result = await this._userManager.CreateAsync(user, registerVM.Password);



            if (!result.Succeeded)
            {
                throw new System.Exception();

            }

        }
        public async Task<string> Login(LoginVM loginVM)
        {

            var user = await _userManager.FindByEmailAsync(loginVM.Email);
            if (user == null)
            {
                throw new UserNotFoundException();
            }

            if (!await _userManager.CheckPasswordAsync(user, loginVM.Password))
            {
                throw new InvalidPasswordException();
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
            return _tokenGenerator.GenetrateToken(authClaims);
        }
    }
}
