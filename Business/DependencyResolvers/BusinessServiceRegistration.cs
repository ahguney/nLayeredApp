using Business.Abstract;
using Business.BusinessRules;
using Business.Concrete;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers
{
    public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddScoped<IBrandService,BrandManager>()
            .AddScoped<IBrandDal, EfBrandDal>()
            .AddScoped<BrandBusinessRules>();

            services.AddScoped<IUserService, UserManager>()
            .AddScoped<IUserDal, EfUserDal>();

            services.AddScoped<ITokenHelper, JwtTokenHelper>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly()); //

            services.AddDbContext<NorthwindContext>(p => p.UseSqlServer(configuration.GetConnectionString("rentACar")));

            return services;
        }
    }
}
