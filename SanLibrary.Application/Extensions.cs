using Microsoft.Extensions.DependencyInjection;
using SanLibrary.Application.Services;

namespace SanLibrary.Application;

public static class Extensions
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        => services
            .AddScoped<IBorrowingBookService, BorrowingBookService>()
            .AddScoped<IBookService, BookService>();
}