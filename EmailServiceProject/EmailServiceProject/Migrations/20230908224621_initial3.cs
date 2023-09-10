using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmailServiceProject.Migrations
{
    /// <inheritdoc />
    public partial class initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SentEmails_toEmail",
                table: "Mails");

            migrationBuilder.AlterColumn<string>(
                name: "toEmail",
                table: "Mails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "fromEmail",
                table: "Mails",
                type: "nvarchar(450)",
                nullable: true,
                defaultValue: "merveu@ssttek.com",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_SentEmails_fromEmail",
                table: "Mails",
                column: "fromEmail",
                unique: true,
                filter: "[fromEmail] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SentEmails_fromEmail",
                table: "Mails");

            migrationBuilder.AlterColumn<string>(
                name: "toEmail",
                table: "Mails",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "fromEmail",
                table: "Mails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true,
                oldDefaultValue: "merveu@ssttek.com");

            migrationBuilder.CreateIndex(
                name: "IX_SentEmails_toEmail",
                table: "Mails",
                column: "toEmail",
                unique: true);
        }
    }
}
