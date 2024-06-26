
using EduzcaServer.Data;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Services.Auth;
using Services.Class;
using Services.Course;
using Services.User;
using System.Text.Json.Serialization;

namespace EduzcaServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    // Handle circular references
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region DATABASE CONNECTION
            builder.Services.AddEntityFrameworkNpgsql().AddDbContext<DBContext>(
                options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Controllers"))
            );


            #endregion

            #region INJECTION DEPENDENCY

            #region COURSE
            builder.Services.AddScoped<IAuthService, AuthService>();
            #endregion

            #region USER
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            #endregion

            #region COURSE
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<ICourseFeedbackRepository, CourseFeedbackRepository>();

            builder.Services.AddScoped<ICourseService, CourseService>();
            builder.Services.AddScoped<ICourseFeedbackService, CourseFeedbackService>();
            #endregion

            #region CLASS
            builder.Services.AddScoped<IClassRepository, ClassRepository>();
            builder.Services.AddScoped<IClassService, ClassService>();
            #endregion

            #endregion


        


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
