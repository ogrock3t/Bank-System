using Lab5.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<AccountService>();
        collection.AddScoped<SessionService>();
        collection.AddScoped<TransactionService>();

        return collection;
    }
}