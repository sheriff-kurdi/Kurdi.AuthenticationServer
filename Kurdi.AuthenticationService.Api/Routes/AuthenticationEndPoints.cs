

using Kurdi.AuthenticationService.Core.VM;
using Microsoft.AspNetCore.Mvc;
using NLog;
using NLog.Web;
using Kurdi.AuthenticationService.Services;
using Kurdi.AuthenticationService.Core.Exceptions;

namespace Kurdi.AuthenticationService.Api.Routes
{

    public static class AuthenticationEndPoints
    {
        private static Logger logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

        public static void UseAuthenticationEndPoints(this WebApplication app)
        {
            RouteGroupBuilder registerationGroup = app.MapGroup("/api/authentication").WithTags("Authentication");

            registerationGroup.MapPost("/login", Login);
            registerationGroup.MapPost("/register", Register);



        }
        public static async Task<IResult> Login(RegisterationService registerationService, [FromBody] LoginVM loginVM)
        {
            string token = string.Empty;
            try
            {
                token = await registerationService.Login(loginVM);

            }
            catch (UserNotFoundException exception)
            {
                logger.Info(exception.Message);
                return Results.BadRequest(new { message = exception.Message });

            }
            catch (InvalidPasswordException exception)
            {
                logger.Info(exception.Message);
                return Results.BadRequest(new { message = exception.Message });

            }
            return Results.Ok(new { message = "Logined Successfully", token = token });
        }

        public static async Task<IResult> Register(RegisterationService registerationService, [FromBody] RegisterVM registerVM)
        {
            try
            {
                await registerationService.Register(registerVM);

            }
            catch (UserAlreadyExistedException exception)
            {
                logger.Info(exception.Message);
                return Results.BadRequest(new { message = exception.Message });

            }
            catch (PasswordsNotMatchedException exception)
            {
                logger.Info(exception.Message);
                return Results.BadRequest(new { message = exception.Message });

            }
            return Results.Ok(new { message = "Registerd Successfully" });
        }


    }
}

