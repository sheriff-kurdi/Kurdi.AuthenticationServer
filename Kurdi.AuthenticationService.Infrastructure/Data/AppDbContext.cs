using Kurdi.AuthenticationService.Core.Entities;
using Kurdi.AuthenticationService.Core.Entities.Authorities;
using Kurdi.AuthenticationService.Infrastructure.Data.FluentAPI;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Kurdi.AuthenticationService.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        private readonly IConfiguration _configuration;

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ProjectsConfiguration.Configure(modelBuilder);
            ModulesConfiguration.Configure(modelBuilder);
            ActionsConfiguration.Configure(modelBuilder);
            AuthoritiesConfiguration.Configure(modelBuilder);
            UsersConfiguration.Configure(modelBuilder);
            base.OnModelCreating(modelBuilder);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseNpgsql(_configuration.GetConnectionString("postgresDatabase"));
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //       => options.UseMySQL(configuration["db_conn"]);
        public DbSet<Authority> Authorities { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Action> Actions { get; set; }



    }
}
/***
     dotnet ef migrations add init --context AppDbContext -p ../Kurdi.AuthenticationService.Infrastructure/Kurdi.AuthenticationService.Infrastructure.csproj -o Data/Migrations
     dotnet ef database update  --context AppDbContext -p ../Kurdi.AuthenticationService.Infrastructure/Kurdi.AuthenticationService.Infrastructure.csproj 
**/

