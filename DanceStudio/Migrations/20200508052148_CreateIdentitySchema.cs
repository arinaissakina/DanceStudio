using Microsoft.EntityFrameworkCore.Migrations;

namespace DanceStudio.Migrations
{
    public partial class CreateIdentitySchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupMembers_Groups_CourseId",
                table: "GroupMembers");

            migrationBuilder.DropIndex(
                name: "IX_GroupMembers_CourseId",
                table: "GroupMembers");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Coaches",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMembers_Groups_GroupId",
                table: "GroupMembers",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupMembers_Groups_GroupId",
                table: "GroupMembers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Coaches");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMembers_CourseId",
                table: "GroupMembers",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMembers_Groups_CourseId",
                table: "GroupMembers",
                column: "CourseId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
