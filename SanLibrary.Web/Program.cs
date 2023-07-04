using SanLibrary.Application;
using SanLibrary.Core;
using SanLibrary.Infrastructure;
using SanLibrary.Infrastructure.Exceptions;
using SanLibrary.Infrastructure.DAL.Seeders;

namespace SanLibrary.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services
                .AddCoreLayer()
                .AddApplicationLayer();

            //configuration can be used to get connection strings, etc
            builder.Services
                .AddInfrastructureLayer(builder.Configuration)
                .AddErrorHandlerMiddleware();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseErrorHandlerMiddleware()
                .UseSeeder();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}