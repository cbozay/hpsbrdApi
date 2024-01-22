using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YoutubeApp.Application.Behaviors;
using YoutubeApp.Application.Exceptions;
using YoutubeApp.Application.Features.Products.Command.CreateProduct;

namespace YoutubeApp.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services) 
        {
            var assebly = Assembly.GetExecutingAssembly();

            services.AddTransient<ExceptionMiddleware>();

            services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(assebly); });

            services.AddValidatorsFromAssembly(assebly);
            ValidatorOptions.Global.LanguageManager.Culture = new System.Globalization.CultureInfo("tr");

            services.AddTransient(typeof(IPipelineBehavior<,>),typeof(FluentValidationBehavior<,>));
        }
    }
}
