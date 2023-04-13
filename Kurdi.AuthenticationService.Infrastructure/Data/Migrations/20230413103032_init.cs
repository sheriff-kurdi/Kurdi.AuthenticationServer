using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Kurdi.AuthenticationService.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "actions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    actionname = table.Column<string>(name: "action_name", type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_actions", x => x.Id);
                    table.UniqueConstraint("AK_actions_action_name", x => x.actionname);
                });

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    firstname = table.Column<string>(name: "first_name", type: "text", nullable: true),
                    lastname = table.Column<string>(name: "last_name", type: "text", nullable: true),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "text", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "modules",
                columns: table => new
                {
                    projectidentifier = table.Column<string>(name: "project_identifier", type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    projectidentifier1 = table.Column<string>(name: "project_identifier1", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modules", x => new { x.name, x.projectidentifier });
                    table.UniqueConstraint("AK_modules_name", x => x.name);
                    table.ForeignKey(
                        name: "FK_modules_projects_project_identifier1",
                        column: x => x.projectidentifier1,
                        principalTable: "projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "authorities",
                columns: table => new
                {
                    projectidentifier = table.Column<string>(name: "project_identifier", type: "text", nullable: false),
                    modulename = table.Column<string>(name: "module_name", type: "text", nullable: false),
                    actionname = table.Column<string>(name: "action_name", type: "text", nullable: false),
                    ProjectId1 = table.Column<string>(type: "text", nullable: true),
                    ProjectId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authorities", x => new { x.projectidentifier, x.modulename, x.actionname });
                    table.ForeignKey(
                        name: "FK_authorities_actions_action_name",
                        column: x => x.actionname,
                        principalTable: "actions",
                        principalColumn: "action_name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_authorities_modules_module_name",
                        column: x => x.modulename,
                        principalTable: "modules",
                        principalColumn: "name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_authorities_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "projects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_authorities_projects_ProjectId1",
                        column: x => x.ProjectId1,
                        principalTable: "projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AuthorityUser",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    AuthoritiesProjectIdentifier = table.Column<string>(type: "text", nullable: false),
                    AuthoritiesModuleName = table.Column<string>(type: "text", nullable: false),
                    AuthoritiesActionName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorityUser", x => new { x.UserId, x.AuthoritiesProjectIdentifier, x.AuthoritiesModuleName, x.AuthoritiesActionName });
                    table.ForeignKey(
                        name: "FK_AuthorityUser_authorities_AuthoritiesProjectIdentifier_Auth~",
                        columns: x => new { x.AuthoritiesProjectIdentifier, x.AuthoritiesModuleName, x.AuthoritiesActionName },
                        principalTable: "authorities",
                        principalColumns: new[] { "project_identifier", "module_name", "action_name" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorityUser_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_authorities_action_name",
                table: "authorities",
                column: "action_name");

            migrationBuilder.CreateIndex(
                name: "IX_authorities_module_name",
                table: "authorities",
                column: "module_name");

            migrationBuilder.CreateIndex(
                name: "IX_authorities_ProjectId",
                table: "authorities",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_authorities_ProjectId1",
                table: "authorities",
                column: "ProjectId1");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorityUser_AuthoritiesProjectIdentifier_AuthoritiesModul~",
                table: "AuthorityUser",
                columns: new[] { "AuthoritiesProjectIdentifier", "AuthoritiesModuleName", "AuthoritiesActionName" });

            migrationBuilder.CreateIndex(
                name: "IX_modules_project_identifier1",
                table: "modules",
                column: "project_identifier1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorityUser");

            migrationBuilder.DropTable(
                name: "authorities");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "actions");

            migrationBuilder.DropTable(
                name: "modules");

            migrationBuilder.DropTable(
                name: "projects");
        }
    }
}
