using Microsoft.EntityFrameworkCore;

namespace SchoolSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            builder.WebHost.UseUrls("http://*:8080");

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Database Configuration
            var dbHost = Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost";
            var dbName = Environment.GetEnvironmentVariable("DB_NAME") ?? "SchoolManagementDB";
            var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "P@ssw0rd123!";
            var connectionString = $"Server={dbHost};Database={dbName};User Id=sa;Password={dbPassword};TrustServerCertificate=true;Encrypt=false;";

            builder.Services.AddDbContext<ApplicationDbContext>(opt =>
                opt.UseSqlServer(connectionString));

            var app = builder.Build();

            // Apply migrations BEFORE the app starts
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();
            }

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