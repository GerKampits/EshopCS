using EShopApp.Configuration;
using EShopApp.DAO;
using EShopApp.Data;
using EShopApp.Service;
using Microsoft.EntityFrameworkCore;

namespace EShopApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connString = builder.Configuration.GetConnectionString("EshopDbConnection");
            builder.Services.AddDbContext<EshopDbContext>(options => options.UseSqlServer(connString));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options => options.AddPolicy("AllowRestricted", policy =>
                                                      policy.AllowAnyMethod()
                                                            .AllowAnyHeader()
                                                            .AllowAnyOrigin()));
                                                            

            builder.Services.AddScoped<ICustomerDAO, CustomerDAOImpl>();
            builder.Services.AddScoped<ICustomerService, CustomerServiceImpl>();
            builder.Services.AddAutoMapper(typeof(MapperConfig));

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
