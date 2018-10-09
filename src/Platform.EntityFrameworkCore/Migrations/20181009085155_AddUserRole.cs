using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Platform.Migrations
{
    public partial class AddUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateName = table.Column<string>(maxLength: 20, nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    ModifyName = table.Column<string>(maxLength: 20, nullable: true),
                    IsDelete = table.Column<int>(nullable: false),
                    RoleName = table.Column<string>(nullable: true),
                    IsStaticRole = table.Column<bool>(nullable: false),
                    IsDefaultRole = table.Column<bool>(nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateName = table.Column<string>(maxLength: 20, nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    ModifyName = table.Column<string>(maxLength: 20, nullable: true),
                    IsDelete = table.Column<int>(nullable: false),
                    NiceName = table.Column<string>(maxLength: 20, nullable: true),
                    Header = table.Column<string>(maxLength: 100, nullable: true),
                    Phone = table.Column<string>(maxLength: 20, nullable: true),
                    WeiXin = table.Column<string>(maxLength: 30, nullable: true),
                    QQ = table.Column<string>(maxLength: 30, nullable: true),
                    WorkNumber = table.Column<string>(maxLength: 20, nullable: false),
                    RealName = table.Column<string>(maxLength: 20, nullable: false),
                    OpenID = table.Column<string>(maxLength: 50, nullable: true),
                    CompanyName = table.Column<string>(maxLength: 30, nullable: true),
                    DepartmentName = table.Column<string>(maxLength: 30, nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
