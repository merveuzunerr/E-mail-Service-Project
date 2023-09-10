using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmailServiceProject.Migrations
{
    /// <inheritdoc />
    public partial class initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailAdress",
                table: "Users",
                newName: "emailAdress");

            migrationBuilder.RenameIndex(
                name: "IX_Emails_EmailAdress",
                table: "Users",
                newName: "IX_Emails_emailAdress");

            migrationBuilder.AddColumn<string>(
                name: "firstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "lastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "firstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "lastName",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "emailAdress",
                table: "Users",
                newName: "EmailAdress");

            migrationBuilder.RenameIndex(
                name: "IX_Emails_emailAdress",
                table: "Users",
                newName: "IX_Emails_EmailAdress");
        }
    }
}
