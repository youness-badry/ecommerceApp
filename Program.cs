using EcommerceApplication.Data;
using EcommerceApplication.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApplication
{
    public class Program
    {   
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<StoreContext>(x =>
                x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IProductRepo, ProductRepo>();
            builder.Services.AddScoped<IBrandRepo, BrandRepo>();
            builder.Services.AddScoped<IProductTypeRepo, ProductTypeRepo>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //To make sure HttpContextAccessor
            //is available to be injected as a dependency in DbContext.
            builder.Services.AddHttpContextAccessor();



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