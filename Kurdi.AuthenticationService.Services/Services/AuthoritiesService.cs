using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kurdi.AuthenticationService.Core.Entities.Authorities;
using Kurdi.AuthenticationService.Core.VM;
using Kurdi.AuthenticationService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Action = Kurdi.AuthenticationService.Core.Entities.Authorities.Action;

namespace Kurdi.AuthenticationService.Services.Services
{
    public class AuthoritiesService
    {
        private readonly AppDbContext _dbContext;
        public AuthoritiesService(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task AddModule(ModuleVM moduleVM)
        {
            this._dbContext.Modules.Add(new Module
            {
                Name = moduleVM.Name,
                ProjectIdentifier = moduleVM.ProjectIdentifier
            });

            List<Action> actions = await this._dbContext.Actions.ToListAsync();
            List<Authority> authorities = new List<Authority>();
            foreach (Action action in actions)
            {
                authorities.Add(new Authority
                {
                    ProjectIdentifier = moduleVM.ProjectIdentifier,
                    ModuleName = moduleVM.Name,
                    ActionName = action.Name
                });
            }
            await this._dbContext.Authorities.AddRangeAsync(authorities);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task AddProject(ProjectVM project)
        {
            this._dbContext.Projects.Add(new Project
            {
                Id = project.Id,
                Description = project.Description
            });
            await this._dbContext.SaveChangesAsync();
        }

        public async Task AddUserToModule(AddUserToModuleVM addUserToModuleVM)
        {
            
        }

        public async Task AddAuthorityToUser(AddAuthorityToUserVM addAuthorityToUserVM)
        {

        }

        public async Task RemoveAuthorityFromUser(RemoveAuthorityFromUserVM removeAuthorityFromUserVM)
        {

        }
    }
}