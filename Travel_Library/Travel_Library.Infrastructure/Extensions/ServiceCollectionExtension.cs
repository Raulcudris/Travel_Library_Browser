using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel_Library.Core.CustomEntities;
using Travel_Library.Core.Interfaces;
using Travel_Library.Core.Services;
using Travel_Library.Infrastructure.Data;
using Travel_Library.Infrastructure.Interfaces;
using Travel_Library.Infrastructure.Options;
using Travel_Library.Infrastructure.Repositories;
using Travel_Library.Infrastructure.Services;
using System.IO;
using Microsoft.OpenApi.Models;

namespace Travel_Library.Infrastructure.Extensions
{

    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TRAVELContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("TravelBd"))
           );

            return services;
        }

        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PaginationOptions>(options => configuration.GetSection("Pagination").Bind(options));
            services.Configure<PasswordOptions>(options => configuration.GetSection("PasswordOptions").Bind(options));

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ISecurityService, SecurityService>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IPasswordService, PasswordService>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IEditorialRepository, EditorialRepository>();    
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IAuthor_has_BookRepository, Author_has_BookRepository>();

            services.AddSingleton<IUriService>(provider =>
            {
                var accesor = provider.GetRequiredService<IHttpContextAccessor>();
                var request = accesor.HttpContext.Request;
                var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(absoluteUri);
            });

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services, string xmlFileName)
        {
            services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc("v1", new OpenApiInfo { Title = "Travel Library API", Version = "v1" });

                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
                doc.IncludeXmlComments(xmlPath);
            });

            return services;
        }

    }
}

