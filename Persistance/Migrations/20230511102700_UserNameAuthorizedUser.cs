using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wallet_App_Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserNameAuthorizedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AuthorizedUserId",
                table: "WalletTransactions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_WalletTransactions_AuthorizedUserId",
                table: "WalletTransactions",
                column: "AuthorizedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WalletTransactions_Users_AuthorizedUserId",
                table: "WalletTransactions",
                column: "AuthorizedUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WalletTransactions_Users_AuthorizedUserId",
                table: "WalletTransactions");

            migrationBuilder.DropIndex(
                name: "IX_WalletTransactions_AuthorizedUserId",
                table: "WalletTransactions");

            migrationBuilder.DropColumn(
                name: "AuthorizedUserId",
                table: "WalletTransactions");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");
        }
    }
}
