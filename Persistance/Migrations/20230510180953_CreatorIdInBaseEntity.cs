using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wallet_App_Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreatorIdInBaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "WalletTransactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "WalletTransactions");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Users");
        }
    }
}
