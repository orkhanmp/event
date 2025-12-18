
using BLL.Abstract;
using BLL.Concrete;
using BLL.Mapper;
using DAL.Abstract;
using DAL.Concrete;

namespace EventAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IEventDAL, EventDAL>();
            builder.Services.AddScoped<IAttendeeDAL, AttendeeDAL>();
            builder.Services.AddScoped<IEventService, EventManager>();
            builder.Services.AddScoped<IAttendeeService, AttendeeManager>();

            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<Map>();
            });

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
