using Application.Activities;
using Application.Core;
using Microsoft.EntityFrameworkCore;
using Persistence;
using dotenv.net;


namespace API.Extensions
{
    public static class ApplicationSericeExtansions
    {
        public static IServiceCollection AddAplicationService(this IServiceCollection services, IConfiguration config)
        {
           // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            
            // Получаем строку подключения из переменной среды
            DotEnv.Load();
            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");


            services.AddDbContext<DataContext>(opt => { 
                Console.Write(connectionString);
                //Console.Write(config.GetConnectionString("DefaultConnection"));
                opt.UseNpgsql(connectionString ?? throw new InvalidOperationException("Connection string 'WebApiContext' not found."));
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