using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YoutubeApp.Application.Exceptions;

namespace YoutubeApp.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services) 
        {
            var assebly = Assembly.GetExecutingAssembly();

            services.AddTransient<ExceptionMiddleware>();

            services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(assebly); });
        }
    }
}
