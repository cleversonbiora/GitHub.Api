using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using GitHub.Domain.Interfaces.Infra;
using GitHub.Domain.Interfaces.Service;
using GitHub.Infra;
using GitHub.Infra.Repositories;
using GitHub.Service.Services;
using System.Data;

namespace GitHub.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {

            //Repository
            services.AddTransient<IRepositoryService, RepositoryService>();
            services.AddTransient<IRepositoryRepository, RepositoryRepository>();
            //Sample
            services.AddTransient<IOwnerRepository, OwnerRepository>();

                services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
        }
    }
}
