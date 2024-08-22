using Modal.Common.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Modal.Domain.AutoMapper;
using Modal.Domain.Models;
using Modal.Repository.Interfaces;
using Modal.Repository.Repositories;
using Modal.Repository.UnitOfWork;
using Modal.Service.Interfaces;
using Modal.Service.Service;
using Modal.Service.UnitOfWork;
using Modal.Domain.ReturnJsonModel;

namespace Modal.APIs.Extentions
{
    public static class ApplicationServicesExtentions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IServiceUnitOfWork, ServiceUnitOfWork>();
            services.AddScoped<ICommonUnitOfWork, CommonUnitOfWork>();
            services.AddScoped<IRepositoryUnitOfWork, RepositoryUnitOfWork>();
            services.AddScoped(typeof(IGenaricRepository<>), typeof(GenaricRepository<>));

            services.AddAutoMapper(typeof(AutoMapperProfiler));
            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.Configure<ApiBehaviorOptions>(option =>
            {
                option.InvalidModelStateResponseFactory = (actionContext) =>
                {
                    var errors = actionContext.ModelState.Where(p => p.Value.Errors.Count() > 0)
                                                         .SelectMany(p => p.Value.Errors)
                                                         .Select(p => p.ErrorMessage).ToArray();

                    var validationErrorResponse = new ErrorJsonModel(400, errors);
                    return new BadRequestObjectResult(validationErrorResponse);
                };
            });

            //services.AddScoped<IAuthService, AuthService>();


            return services;
        }
    }
}
