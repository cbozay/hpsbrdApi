using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YoutubeApp.Application.Bases;
using YoutubeApp.Application.Behaviors;
using YoutubeApp.Application.Exceptions;
using YoutubeApp.Application.Features.Products.Command.CreateProduct;

namespace YoutubeApp.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddTransient<ExceptionMiddleware>();

            services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(assembly); });

            services.AddValidatorsFromAssembly(assembly);
            ValidatorOptions.Global.LanguageManager.Culture = new System.Globalization.CultureInfo("tr");

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehavior<,>));

            services.AddRulesFromAssembyContaining(assembly, typeof(BaseRules));
        }

        //assembly deki tüm rules class larını bulur ve kaydeder. Üst kısımda da bu custom sınıfın kaydını yaptık.
        private static IServiceCollection AddRulesFromAssembyContaining(this IServiceCollection services, Assembly assembly, Type type)
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && t != type).ToList();
            foreach (var item in types)
                services.AddTransient(item);

            return services;
        }
    }
}
