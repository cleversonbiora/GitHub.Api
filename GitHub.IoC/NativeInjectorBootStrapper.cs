using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using GitHub.Domain.Interfaces.Infra;
using GitHub.Domain.Interfaces.Service;
using GitHub.Infra;
using GitHub.Infra.Repositories;
using GitHub.Service.Services;
using System.Data;
using GitHub.Infra.Stores;
using GitHub.Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace GitHub.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {

            //Sample
            services.AddTransient<ISampleService, SampleService>();
            services.AddTransient<ISampleRepository, SampleRepository>();

            //Account
            services.AddTransient<IAccountService, AccountService>();

            //Identity
            services.AddTransient<IUserStore<ApiUser>, UserStore>();
            services.AddTransient<IRoleStore<ApiRole>, RoleStore>();

            services.AddIdentity<ApiUser, ApiRole>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

                services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
        }
    }
}
