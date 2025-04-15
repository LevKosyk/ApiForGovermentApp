using ApiForGovermentApp.Data;
using ApiForGovermentApp.Services;
using Microsoft.EntityFrameworkCore;

namespace ApiForGovermentApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.WebHost.UseUrls("http://0.0.0.0:5138");

            builder.Services.AddDbContext<ApiDbContext>(options =>
                        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddControllers();

            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<PhotoService>();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            builder.Services.AddHealthChecks();

            var app = builder.Build();
            app.UseCors("AllowAll");

            app.UseHealthChecks("/health");

            app.UseAuthorization();
            app.UseHttpsRedirection();
            app.MapControllers();

            app.Run();
        }
    }
}
