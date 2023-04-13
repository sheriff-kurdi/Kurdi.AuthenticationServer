using Kurdi.AuthenticationService.Core.Entities;
using Kurdi.AuthenticationService.Core.Entities.Authorities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Kurdi.AuthenticationService.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Project Configure
            modelBuilder.Entity<Project>().ToTable("projects");
            modelBuilder.Entity<Project>().Property(project => project.Description).HasColumnName("description");
            modelBuilder.Entity<Project>().HasMany(project => project.Authorities).WithOne();
            #endregion

            #region Module configure
            modelBuilder.Entity<Module>().ToTable("modules");

            modelBuilder.Entity<Module>()
                .HasKey(module => new { module.Name, module.ProjectIdentifier });

            modelBuilder.Entity<Module>()
                .HasOne(module => module.Project)
                .WithMany()
                .HasForeignKey("project_identifier")
                .HasPrincipalKey(project => project.Id);
            modelBuilder.Entity<Module>().Property(module => module.ProjectIdentifier).HasColumnName("project_identifier");
            modelBuilder.Entity<Module>().Property(module => module.Name).HasColumnName("name");
            #endregion

            #region Action Configure
            modelBuilder.Entity<Action>().ToTable("actions");
            modelBuilder.Entity<Action>().Property(action => action.Name).HasColumnName("action_name");
            #endregion

            #region Authority configure
            modelBuilder.Entity<Authority>().ToTable("authorities");

            modelBuilder.Entity<Authority>()
                .HasKey(authority => new { authority.ProjectIdentifier, authority.ModuleName, authority.ActionName });
            modelBuilder.Entity<Authority>()
                .HasOne(authority => authority.Module)
                .WithMany()
                .HasForeignKey("ModuleName")//<<== Use shadow property
                .HasPrincipalKey(module => module.Name);//<<==point t

            modelBuilder.Entity<Authority>()
                .HasOne(authority => authority.Action)
                .WithMany()
                .HasForeignKey("ActionName")
                .HasPrincipalKey(action => action.Name);

            modelBuilder.Entity<Authority>().Property(authority => authority.ActionName).HasColumnName("action_name");
            modelBuilder.Entity<Authority>().Property(authority => authority.ModuleName).HasColumnName("module_name");
            modelBuilder.Entity<Authority>().Property(authority => authority.ProjectIdentifier).HasColumnName("project_identifier");
            #endregion

            #region User configure
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<User>()
                .HasMany(user => user.Authorities)
                .WithMany();
            modelBuilder.Entity<User>().Property(user => user.FirstName).HasColumnName("first_name");
            modelBuilder.Entity<User>().Property(user => user.LastName).HasColumnName("last_name");
            #endregion


        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseNpgsql(_configuration.GetConnectionString("postgresDatabase"));
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //       => options.UseMySQL(configuration["db_conn"]);
        public DbSet<User> Users { get; set; }
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

