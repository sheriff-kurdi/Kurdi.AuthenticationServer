using Kurdi.AuthenticationService.Core.Entities;
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
            modelBuilder.Entity<Authority>()
                .HasKey(authority => new {authority.ProjectsIdentifier, authority.ModuleName, authority.Action});

                modelBuilder.Entity<Module>()
                .HasKey(authority => new {authority.ProjectsIdentifier, authority.Name});
 
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
     dotnet ef migrations add SalesOrders-naming --context AppDbContext -p ../Kurdi.ECommerce.Inventory.Infrastructure/Kurdi.ECommerce.Inventory.Infrastructure.csproj -o Data/Migrations
     dotnet ef database update  --context AppDbContext -p ../Kurdi.ECommerce.Inventory.Infrastructure/Kurdi.ECommerce.Inventory.Infrastructure.csproj 
**/

