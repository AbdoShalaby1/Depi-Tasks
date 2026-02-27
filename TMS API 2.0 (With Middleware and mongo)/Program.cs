
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using TMS_2_with_middleware.Context;
using TMS_2_with_middleware.Middleware;
using TMS_2_with_middleware.Models;
using TMS_2_with_middleware.Repositories;

namespace TMS_2_with_middleware
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddSwaggerGen();

            // this is used instead of the normal DbContext
            // it is optimized for use as a singleton not scoped as the normal one\
            // the native driver for mongo is more optimized than ef core with mongo
            // for DI to work you pass IMongoDatabase context in the constructor
            // then work normally by GetCollection, Insert ...
            builder.Services.AddSingleton<IMongoDatabase>(_ =>
            {
                var connString = builder.Configuration.GetConnectionString("DefaultConnection");
                return new MongoClient(connString).GetDatabase("TMS");
            });
            // this is Mongo so singleton is better for it
            builder.Services.AddSingleton<AppDbContext>();
            builder.Services.AddScoped<IRepository<User>,UserRepository>();
            builder.Services.AddScoped<IRepository<TaskItem>, TaskRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.Use(async (context, next) =>
            {
                Console.WriteLine("Inline Middleware test");
                await next();
                Console.WriteLine("After response!");
            });
            app.UseCustomMiddleware();

            app.MapControllers();


            // you must have 2 app.Run, the one with the middleware and the normal one
            // this is a fallback response, shows when no controller is available to serve the current endpoint
            // instead of a generic 404
            app.Run(async (context) =>
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("No Endpoint to Serve this!");
            });

            // this is the actual start point of the app, you cannot just replace it with the above one
            // my app didn't run before I added this back
            app.Run();
        }
    }
}
