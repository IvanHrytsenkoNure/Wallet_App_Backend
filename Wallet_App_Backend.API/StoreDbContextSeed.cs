using Microsoft.EntityFrameworkCore;
using Wallet_App_Backend.Data.Entities;
using Wallet_App_Backend.Data.Enums;

namespace Wallet_App_Backend.Infrastructure.Persistence
{
    public static class StoreDbContextSeed
    {
        public static async Task SeedSampleDataAsync(this WebApplication app)
        {

            using (var scope = app.Services.CreateScope())
            {
                await using var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                try
                {
                    await context.Database.EnsureCreatedAsync();

                    var usersSeeded = await context.Users.AnyAsync();

                    if (!usersSeeded)
                    {
                        var user = new User()
                        {
                            WalletTransaction = new List<WalletTransaction>()
                            {
                                new()
                                {
                                    TransactionAmount = 123,
                                    TransactionDescription = "SomeSeededTransaction1",
                                    TransactionDate = DateTime.UtcNow.AddDays(-2),
                                    TransactionName = "Transaction1",
                                    TransactionStatus = WalletTransactionStatus.Approved,
                                    TransactionIconPath = "imagePath",
                                    TransactionType = WalletTransactionType.Credit
                                },
                                new()
                                {
                                    TransactionAmount = 345,
                                    TransactionDescription = "SomeSeededTransaction2",
                                    TransactionDate = DateTime.UtcNow.AddMonths(-2),
                                    TransactionName = "Transaction3",
                                    TransactionStatus = WalletTransactionStatus.Pending,
                                    TransactionIconPath = "imagePath1",
                                    TransactionType = WalletTransactionType.Payment
                                }
                            }
                        };

                        await context.Users.AddAsync(user);
                    }

                    await context.SaveChangesAsync();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }






        }
    }
}