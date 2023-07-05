using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SanLibrary.Core.Books.Repositories;
using SanLibrary.Infrastructure.DAL.Repositories;
using SanLibrary.Infrastructure.DAL.Seeders;
using SanLibrary.Core.Publishers.Repositories;
using SanLibrary.Core.Shared.Time;
using SanLibrary.Infrastructure.Time;
using SanLibrary.Core.Users.Repositories;
using Microsoft.AspNetCore.Builder;
using SanLibrary.Infrastructure.Exceptions;

namespace SanLibrary.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services,
        IConfiguration configuration)
        => services
            // Repos must be singleton because data is in memory
            .AddSingleton<IUserRepository, InMemoryUserRepository>()
            .AddSingleton<IAuthorRepository, InMemoryAuthorRepository>()
            .AddSingleton<IBookRepository, InMemoryBookRepository>()
            .AddSingleton<IPublisherRepository, InMemoryPublisherRepository>()
            .AddSingleton<IBorrowingBooksUserRepository, InMemoryBorrowingBooksUserRepository>()
            .AddSingleton<IClock, DateTimeClock>()
            .AddScoped<Seeder>();
    }
}
