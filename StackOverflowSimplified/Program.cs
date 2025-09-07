
using Microsoft.EntityFrameworkCore;
using StackOverflowSimplified.Entites;

namespace StackOverflowSimplified
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<StackOverflowContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("StackOverflowConnectionString")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<StackOverflowContext>();
            var pendingMigrations = dbContext.Database.GetPendingMigrations();

            if (pendingMigrations.Any())
            {
                dbContext.Database.Migrate();
            }


            app.Run();
        }
    }
}
