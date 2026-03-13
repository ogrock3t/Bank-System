using Lab5.Application.Abstractions.Repositories;
using Lab5.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Infrastructure.Persistence;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection collection)
    {
        collection.AddSingleton<IAccountRepository, InMemoryAccountRepository>();
        collection.AddSingleton<ISessionRepository, InMemorySessionRepository>();
        collection.AddSingleton<ITransactionRepository, InMemoryTransactionRepository>();

        return collection;
    }
}