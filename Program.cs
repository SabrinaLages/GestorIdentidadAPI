
using Microsoft.EntityFrameworkCore;
using PrimerParcial.EF;
using PrimerParcial.Interfaces;
using PrimerParcial.Repositories;

namespace PrimerParcial
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration["MYSQL_CONNECTION_STRING"];
            builder.Services.AddDbContext<MiDBContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            // Add services to the container.
            builder.Services.AddScoped<ITramiteRepository, TramiteRepository>();
            builder.Services.AddScoped<ITitularRepository, TitularRepository>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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
