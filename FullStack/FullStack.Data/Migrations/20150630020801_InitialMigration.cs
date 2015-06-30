using System.Collections.Generic;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Operations;

namespace FullStack.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateSequence(
                name: "DefaultSequence",
                type: "bigint",
                startWith: 1L,
                incrementBy: 10);
            migration.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column(type: "int", nullable: false),
                    RoleName = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });
            migration.CreateTable(
                name: "User",
                columns: table => new
                {
                    DateOfBirth = table.Column(type: "datetime2", nullable: false),
                    Email = table.Column(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column(type: "decimal(18, 2)", nullable: false),
                    UserId = table.Column(type: "int", nullable: false),
                    UserName = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });
            migration.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    RoleId = table.Column(type: "int", nullable: false),
                    UserId = table.Column(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        columns: x => x.RoleId,
                        referencedTable: "Role",
                        referencedColumn: "RoleId");
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        columns: x => x.UserId,
                        referencedTable: "User",
                        referencedColumn: "UserId");
                });
        }
        
        public override void Down(MigrationBuilder migration)
        {
            migration.DropSequence("DefaultSequence");
            migration.DropTable("Role");
            migration.DropTable("User");
            migration.DropTable("UserRole");
        }
    }
}
