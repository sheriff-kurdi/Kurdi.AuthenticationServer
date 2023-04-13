using Kurdi.AuthenticationService.Core.Entities.Authorities;
using Microsoft.EntityFrameworkCore;

namespace Kurdi.AuthenticationService.Infrastructure.Data.FluentAPI
{
    public static class ActionsConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Action>().ToTable("actions");
            modelBuilder.Entity<Action>().HasKey(action => action.Name);
            modelBuilder.Entity<Action>().Property(action => action.Name).HasColumnName("action_name");
        }
    }
}