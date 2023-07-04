using SanLibrary.Infrastructure;
using SanLibrary.Infrastructure.DAL.Seeders;

namespace SanLibrary.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string x = null;

            Console.WriteLine($"some: {x}");

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //configuration can be used to get connection strings, etc
            builder.Services.AddInfrastructureLayer(builder.Configuration); 

            var app = builder.Build();

            app.UseSeeder();

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