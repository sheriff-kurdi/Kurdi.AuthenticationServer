using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kurdi.AuthenticationService.Core.Entities;
using Kurdi.AuthenticationService.Core.Entities.Authorities;
using Kurdi.AuthenticationService.Core.Exceptions;
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
            User user = await this._dbContext.Users
            .FirstOrDefaultAsync(user => user.Id == addUserToModuleVM.UserId);

            List<Authority> authorities = await this._dbContext.Authorities
            .Where(authority
                 => authority.ModuleName == addUserToModuleVM.ModuleName
                && authority.ProjectIdentifier == addUserToModuleVM.ProjectIdentifier).ToListAsync();

            user.Authorities.AddRange(authorities);
            await this._dbContext.SaveChangesAsync();

        }

        public async Task AddAuthorityToUser(AddAuthorityToUserVM addAuthorityToUserVM)
        {
            User user = await this._dbContext.Users.Include(user => user.Authorities)
            .FirstOrDefaultAsync(user => user.Id == addAuthorityToUserVM.UserId);
            Authority authorityToAdd =
                this._dbContext.Authorities.FirstOrDefault(authority
                    => authority.ProjectIdentifier == addAuthorityToUserVM.ProjectIdentifier
                    && authority.ModuleName == addAuthorityToUserVM.ModuleName
                    && authority.ActionName == addAuthorityToUserVM.ActionName);

            if (authorityToAdd is null) throw new AuthorityNotFoundException();

            user.Authorities.Add(authorityToAdd);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task RemoveAuthorityFromUser(RemoveAuthorityFromUserVM removeAuthorityFromUserVM)
        {
            User user = await this._dbContext.Users.Include(user => user.Authorities)
            .FirstOrDefaultAsync(user => user.Id == removeAuthorityFromUserVM.UserId);
            Authority authorityToRemove =
                user.Authorities.FirstOrDefault(authority
                    => authority.ProjectIdentifier == removeAuthorityFromUserVM.ProjectIdentifier
                    && authority.ModuleName == removeAuthorityFromUserVM.ModuleName
                    && authority.ActionName == removeAuthorityFromUserVM.ActionName);

            if (authorityToRemove is null) return;

            user.Authorities.Remove(authorityToRemove);
            await this._dbContext.SaveChangesAsync();
        }
    }
}