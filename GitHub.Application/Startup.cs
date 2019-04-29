using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GitHub.Domain.AutoMapper;
using GitHub.IoC;
using Newtonsoft.Json;
using AutoMapper;
using GitHub.Application.Middleware;
using GitHub.CrossCutting;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace GitHub.Application
{
    public class Startup
    {
        private IHostingEnvironment enviroment;
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
               .AddEnvironmentVariables();

            enviroment = env;

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConnectionStrings.GitHubConnection = Configuration.GetConnectionString("GitHubConnection");
            string GitHubUrl = Configuration.GetSection("ApiUrls")["GitHub"];
            Environment.SetEnvironmentVariable("GitHubUrl", GitHubUrl);
      
            services.AddMvc()
            .AddJsonOptions(options =>
            {
                options.SerializerSettings.Formatting = Formatting.Indented;
            });
            
            Mapper.Initialize(cfg =>
            {
                cfg.ValidateInlineMaps = false;
            });

            services.AddAutoMapper(typeof(Startup).Assembly);
            AutoMapperConfiguration.RegisterMappings();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = $"GitHub API {enviroment.EnvironmentName}", Version = "v1", Description = "Projeto GitHub" });
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme { In = "header", Description = "Please enter JWT with Bearer into field", Name = "Authorization", Type = "apiKey" }); //Enable Bearer token o Swagger
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> {
                { "Bearer", Enumerable.Empty<string>() },
            });
            }); //Emable Swagger on Application on /Swagger

            services.AddOptions();

            services.AddCors(o => o.AddPolicy("Cors", builder =>
            {
                builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowAnyOrigin();
            }));
            // Registrar todos os IoC
            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseAuthentication();

            app.UseResponseExceptionHandler();
            
            app.UseStaticFiles();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}");
            });
            app.UseCors(builder => {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });

        }

        private static void RegisterServices(IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
