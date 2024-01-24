using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApp.Application.Interfaces.Repositories;
using YoutubeApp.Application.Interfaces.Services;
using YoutubeApp.Application.Interfaces.UnitOfWorks;
using YoutubeApp.Persistence.Context;
using YoutubeApp.Persistence.Repositories;
using YoutubeApp.Persistence.Services;
using YoutubeApp.Persistence.UnitOfWorks;

namespace YoutubeApp.Persistence
{
    public static class Registration
    {
        public static void AddPersistence(this IServiceCollection services,IConfiguration configuration) 
        {
            services.AddDbContext<AppDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IWriteRepository<>),typeof(WriteRepository<>));
            services.AddScoped(typeof(IReadRepository<>),typeof(ReadRepository<>));
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
