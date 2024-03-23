using Application.Activities;
using Application.Core;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Extensions
{
    public static class ApplicationSericeExtansions
    {
        public static IServiceCollection AddAplicationService(this IServiceCollection services, IConfiguration config)
        {
           // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<DataContext>(opt => { 
                opt.UseNpgsql(config.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'WebApiContext' not found."));
            });

            services.AddCors(opt => {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
                });
            });

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(List.Handler).Assembly)); // все обработчики подключаться

            services.AddAutoMapper(typeof(MappingProfiles).Assembly); // все маппинги подключаться

            return services;
        }
    }
}