using BLL.BLLInterfaces;
using BLL.BLLService;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BLL
{
    public static class BLLServiceIntigration
    {
        public static IServiceCollection AddBLL(this IServiceCollection services)
        {
            services.AddTransient<IBLLAttendence, BLLAttendence>();
            services.AddTransient<IBLLSecurity, BLLSecurity>();
            services.AddTransient<ISessionSplit, BLLSessionSplit>();


            return services;
        }
    } 
}
