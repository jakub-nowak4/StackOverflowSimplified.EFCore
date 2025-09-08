
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using StackOverflowSimplified.Entites;
using StackOverflowSimplified.Entities;
using System.Text.Json.Serialization;

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

            builder.Services.Configure<JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

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

            app.MapGet("questions", async (StackOverflowContext db) =>
            {
                var questions = await db.Questions.Include(q => q.Answers).Include(q => q.Comments).ToListAsync();

                return questions;
            }).WithName("GetAllQuestions").WithOpenApi();

            app.MapGet("users", async (StackOverflowContext db) =>
            {
                var users = await db.Users.ToListAsync();
                return users;
            }).WithName("GetAllUsers").WithOpenApi();

            app.MapPost("add-question", async (StackOverflowContext db) => {
                var question = new Question() 
                {
                    Title = "Testowe pytanie",
                    Body = "Testowa zawartość",
                };

                var author = await db.Users.FirstAsync();
                question.Author = author;

                db.Questions.Add(question);
                await db.SaveChangesAsync();

                return question;
            }).WithName("AddTestQuestion").WithOpenApi();

            app.MapPost("add-answer", async (StackOverflowContext db) => 
            {
                var question = await db.Questions.FirstOrDefaultAsync(q => q.Title == "Testowe pytanie");
                var author = await db.Users.FirstAsync();

                if (question != null)
                {
                    var answer = new Answer()
                    {
                        Body = "Testowa odpowiedź",
                        Votes = 1,
                        Question = question,
                        Author = author
                        
                    };

                    db.Answers.Add(answer);
                    await db.SaveChangesAsync();

                    return answer;
                }

                return null;
            }).WithName("AddTestAnswer").WithOpenApi();


            app.MapDelete("delete", async (StackOverflowContext db) => {
                var questionToDelete = await db.Questions.FirstOrDefaultAsync(q => q.Title == "Testowe pytanie");

                if (questionToDelete != null)
                {
                    db.Remove(questionToDelete);
                    await db.SaveChangesAsync();
                }
            }).WithName("DeleteTestQuestion").WithOpenApi();


            app.Run();
        }
    }
}
