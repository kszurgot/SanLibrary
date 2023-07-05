using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SanLibrary.Application;
using SanLibrary.Application.Services;
using SanLibrary.Core;
using SanLibrary.Infrastructure;
using SanLibrary.Infrastructure.DAL.Seeders;

namespace SanLibrary.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);

            builder.Services
                .AddCoreLayer()
                .AddApplicationLayer()
                .AddInfrastructureLayer(builder.Configuration);

            var app = builder.Build();
            app.Services.UseSeeder();

            Run(app.Services);

            app.Run();
        }

        static async void Run(IServiceProvider hostProvider)
        {
            using IServiceScope serviceScope = hostProvider.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;

            IBookService? bookService = provider.GetService<IBookService>();

            if (bookService is not null)
            {
                var result = await bookService.GetAllAsync(new Application.DTO.QueryBookDto());

                foreach (var book in result)
                {
                    System.Console.WriteLine($"Id: {book.Id}, Title: {book.Title}");
                }
            }

           
        }
    }
}