using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kurdi.AuthenticationService.Core.Entities;
using Kurdi.AuthenticationService.Core.Entities.Authorities;
using Microsoft.EntityFrameworkCore;

namespace Kurdi.AuthenticationService.Infrastructure.Data.FluentAPI
{
    public static class UsersConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<User>()
                .HasMany(user => user.Authorities)
                .WithMany();
                  modelBuilder.Entity<User>().HasKey(user => user.Id);
            modelBuilder.Entity<User>().Property(user => user.FirstName).HasColumnName("first_name");
            modelBuilder.Entity<User>().Property(user => user.LastName).HasColumnName("last_name");
        }
    }
}