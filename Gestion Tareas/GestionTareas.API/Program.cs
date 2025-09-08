
using GestionTareas.API.Middleware;
using GestionTareas.Application.Interfaces;
using GestionTareas.Application.Services;
using GestionTareas.Domain.Interfaces;
using GestionTareas.Infraestructure.Context;
using GestionTareas.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GestionTareas.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.WebHost.ConfigureKestrel(options =>
            {
                options.ListenAnyIP(7215, options =>
                {
                    options.UseHttps();
                });
            });

            // Add services to the container.
            builder.Services.AddScoped<IJobServices,JobService>();
            builder.Services.AddScoped<IJobRepository, JobRepository>();

            builder.Services.AddDbContext<JobContext>(
                opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            app.UseMiddleware<ExceptionMiddleware>();
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
