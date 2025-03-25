
using WeatherAPI.Interfaces;
using WeatherAPI.Services;
using StackExchange.Redis;

namespace WeatherAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect("localhost:6379"));

            // Add services to the container.

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.WithOrigins("http://localhost:4200") 
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                                  });
            });

            builder.Services.AddControllers();
            builder.Services.AddHttpClient<WeatherApiClientService>();
            builder.Services.AddSingleton<IRedisCacheService, RedisCacheService>();
            builder.Services.AddScoped<ICityService, CityService>();
            builder.Services.AddScoped<IWeatherService, WeatherService>();
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
            app.UseCors(MyAllowSpecificOrigins);

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
