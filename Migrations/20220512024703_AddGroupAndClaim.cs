using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreMigrationDemo.Migrations
{
    public partial class AddGroupAndClaim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "People",
                newName: "NickName"
            );

            migrationBuilder.Sql(@"DECLARE @v sql_variant 
SET @v = N'暱稱'
EXECUTE sp_updateextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'People', N'COLUMN', N'NickName'
GO");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "信箱");

            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "ID"),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "類型"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "值")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Claims_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "ID"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "名稱")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonGroup",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "人員ID"),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "群組ID")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonGroup", x => new { x.GroupId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_PersonGroup_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonGroup_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Claims_PersonId",
                table: "Claims",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonGroup_PersonId",
                table: "PersonGroup",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Claims");

            migrationBuilder.DropTable(
                name: "PersonGroup");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "People");

            migrationBuilder.Sql(@"DECLARE @v sql_variant 
SET @v = N'姓名'
EXECUTE sp_updateextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'People', N'COLUMN', N'NickName'
GO");

            migrationBuilder.RenameColumn(
                name: "NickName",
                table: "People",
                newName: "Name"
            );
        }
    }
}
