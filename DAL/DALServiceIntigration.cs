using DAL.DALInterfaces;
using DAL.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DAL
{
    public static class DALServiceIntigration
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IAttendence, AttendenceRepo>();
            services.AddTransient<ISecurity, SecurityRepo>();

            return services;
        }
    }
} 
