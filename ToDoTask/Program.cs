using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ToDoTask.DataAccess.Contexts;
using ToDoTask.DataAccess.IRepositories;
using ToDoTask.DataAccess.Repositories;
using ToDoTask.Logic.IServices;
using ToDoTask.Logic.Mappings;
using ToDoTask.Logic.Services;

namespace ToDoTaskWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<DBContext>(options =>
                       options.UseSqlServer("Server=(local);Database=ToDoTask;Trusted_Connection=false;user id=borovikov;password=Mongo6nfynfy;"));
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ToDoProfile());
            });
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
                                  });
            });

            IMapper mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);

            builder.Services.AddScoped<IToDoService, ToDoService>();
            builder.Services.AddScoped<IToDoRepository, ToDoRepository>();

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

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.MapControllers();

            app.Run();


        }
    }
}