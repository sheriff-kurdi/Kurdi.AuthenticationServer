using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kurdi.AuthenticationService.Core.Entities.Authorities;
using Microsoft.EntityFrameworkCore;

namespace Kurdi.AuthenticationService.Infrastructure.Data.FluentAPI
{
    public static class ProjectsConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().ToTable("projects");
            modelBuilder.Entity<Project>().Property(project => project.Description).HasColumnName("description");
            modelBuilder.Entity<Project>().HasMany(project => project.Authorities).WithOne();
        }
    }
}