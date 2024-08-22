using Microsoft.EntityFrameworkCore;
using Modal.APIs.Extentions;
using Modal.APIs.Middleware;
using Modal.Repository.Data;

namespace ModalAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Configure Service to allow DI
            
            // Add services to the container.
            builder.Services.AddControllers();

            // add this extention method to cleaning program
            builder.Services.AddSwaggerServices();

            builder.Services.AddDbContext<ModalContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
            });

            // add this extention method to cleaning program
            builder.Services.AddApplicationServices();

            //builder.Services.AddIdentityServices(builder.Configuration);

            //builder.Services.AddCors(options =>
            //{
            //    options.AddPolicy("MyPolicy", options =>
            //    {
            //        options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
            //    });
            //});
            #endregion

            var app = builder.Build();

            #region Configure to allowed MiddleWare

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                // add this extention method to cleaning program
                app.UseSwaggerMiddleware();
            }

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseStatusCodePagesWithRedirects("/api/Errors/Error/404"); // this middleware to execute if user enter wrong endpoint


            //app.UseCors("MyPolicy");
            //app.UseMiddleware<PermissionCheckMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            #endregion


            app.Run();
        }
    }
}
