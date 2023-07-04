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

        //public static IApplicationBuilder UseExceptionHandlerr(this IApplicationBuilder app)
        //{
        //    app.UseExceptionHandler(errorApp =>
        //    {
        //        errorApp.Run(async context =>
        //        {
        //            context.Response.StatusCode = 400;
        //            context.Response.ContentType = "text/html";

        //            await context.Response.WriteAsync("<html lang=\"en\"><body>\r\n");
        //            await context.Response.WriteAsync("ERROR!<br><br>\r\n");

        //            var exceptionHandlerPathFeature =
        //                context.Features.Get<IExceptionHandlerPathFeature>();

        //            if (exceptionHandlerPathFeature?.Error is FileNotFoundException)
        //            {
        //                await context.Response.WriteAsync(
        //                                          "File error thrown!<br><br>\r\n");
        //            }

        //            await context.Response.WriteAsync(
        //                                                          "<a href=\"/\">Home</a><br>\r\n");
        //            await context.Response.WriteAsync("</body></html>\r\n");
        //            await context.Response.WriteAsync(new string(' ', 512));
        //        });
        //    });
        //}
    }
}
