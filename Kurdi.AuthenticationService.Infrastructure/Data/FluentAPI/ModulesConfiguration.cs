using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kurdi.AuthenticationService.Core.Entities.Authorities;
using Microsoft.EntityFrameworkCore;

namespace Kurdi.AuthenticationService.Infrastructure.Data.FluentAPI
{
    public static class ModulesConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Module>().ToTable("modules");

            modelBuilder.Entity<Module>()
                .HasKey(module => new { module.Name, module.ProjectIdentifier });

            modelBuilder.Entity<Module>()
                .HasOne(module => module.Project)
                .WithMany()
                .HasForeignKey(module => module.ProjectIdentifier);
            modelBuilder.Entity<Module>().Property(module => module.ProjectIdentifier).HasColumnName("project_identifier");
            modelBuilder.Entity<Module>().Property(module => module.Name).HasColumnName("name");
        }
    }
}