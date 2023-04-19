

using Kurdi.AuthenticationService.Core.VM;
using Microsoft.AspNetCore.Mvc;
using NLog;
using NLog.Web;
using Kurdi.AuthenticationService.Services;
using Kurdi.AuthenticationService.Core.Exceptions;

namespace Kurdi.AuthenticationService.Api.Routes
{

    public static class AuthorizationEndPoints
    {
        private static Logger logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

        public static void UseAuthorizationEndPoints(this WebApplication app)
        {
            RouteGroupBuilder authoritiesEndPointsGroup = app.MapGroup("/api/authorization").WithTags("Authorization");

            authoritiesEndPointsGroup.MapPost("/add-project", AddProject);
            authoritiesEndPointsGroup.MapPost("/add-module", AddModule);
            authoritiesEndPointsGroup.MapPost("/add-user-to-module", AddUserToModule);

        }

        public static async Task<IResult> AddProject(AuthoritiesService authoritiesService, [FromBody] ProjectVM projectVM)
        {
            try
            {
                await authoritiesService.AddProject(projectVM);

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
            return Results.Ok(new { message = "Project Added Successfully" });
        }

        public static async Task<IResult> AddModule(AuthoritiesService authoritiesService, [FromBody] ModuleVM moduleVM)
        {
            try
            {
                await authoritiesService.AddModule(moduleVM);

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
            return Results.Ok(new { message = "Module Added Successfully" });
        }

        public static async Task<IResult> AddUserToModule(AuthoritiesService authoritiesService, [FromBody] AddUserToModuleVM addUserToModuleVM)
        {
            try
            {
                await authoritiesService.AddUserToModule(addUserToModuleVM);

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
            return Results.Ok(new { message = "User Added Successfully" });
        }

    }
}

