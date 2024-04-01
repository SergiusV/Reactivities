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
            //string connectionString = $"User ID={config["POSTGRES_USER"]};Password={config["POSTGRES_PASSWORD"]};Host={config["POSTGRES_HOST"]};Port={config["POSTGRES_PORT"]};Database={config["POSTGRES_DB"]};Pooling=true;";

            services.AddDbContext<DataContext>(opt => { 
                Console.Write(config.GetConnectionString("DefaultConnection"));
                //opt.UseNpgsql(connectionString  ?? throw new InvalidOperationException("Connection string 'WebApiContext' not found."));
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