using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Presentation;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentation(this IServiceCollection collection)
    {
        collection.AddControllers();
        return collection;
    }
}