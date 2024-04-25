using System.Collections.Generic;
using Application;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API;

public static class ApplicationServiceExtensions
{

    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config){

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddEndpointsApiExplorer();

        services.AddDbContext<DataContext>(opt => {
            opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
        });

        services.AddCors(opt => {
            opt.AddPolicy("CorsPolicy", policy =>{
                policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:5173");
            });
        });

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(List.Handler).Assembly));
        services.AddAutoMapper(typeof(MappingProfiles).Assembly);
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<Create>();
        return services;

    }

}
