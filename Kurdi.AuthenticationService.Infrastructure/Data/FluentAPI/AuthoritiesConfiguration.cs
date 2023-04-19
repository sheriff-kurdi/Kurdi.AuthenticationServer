using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kurdi.AuthenticationService.Core.Entities.Authorities;
using Microsoft.EntityFrameworkCore;

namespace Kurdi.AuthenticationService.Infrastructure.Data.FluentAPI
{
    public static class AuthoritiesConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authority>().ToTable("authorities");

            modelBuilder.Entity<Authority>()
                .HasKey(authority => new { authority.ProjectIdentifier, authority.ModuleName, authority.ActionName });

            modelBuilder.Entity<Authority>()
                .HasOne(authority => authority.Project)
                .WithMany()
                .HasForeignKey(authority => authority.ProjectIdentifier);

            modelBuilder.Entity<Authority>()
                .HasOne(authority => authority.Module)
                .WithMany()
                .HasForeignKey(authority => new { authority.ModuleName, authority.ProjectIdentifier });

            modelBuilder.Entity<Authority>()
                .HasOne(authority => authority.Action)
                .WithMany()
                .HasForeignKey(authority => authority.ActionName);

            modelBuilder.Entity<Authority>().Property(authority => authority.ActionName).HasColumnName("action_name");
            modelBuilder.Entity<Authority>().Property(authority => authority.ModuleName).HasColumnName("module_name");
            modelBuilder.Entity<Authority>().Property(authority => authority.ProjectIdentifier).HasColumnName("project_identifier");
        }
    }
}