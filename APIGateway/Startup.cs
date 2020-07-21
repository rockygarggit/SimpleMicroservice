using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace APIGateway
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public IConfiguration Configuration { get; }
        private IWebHostEnvironment _env { get; set; }

        public Startup(IWebHostEnvironment environment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true)
                .AddJsonFile("ocelot.json")
                .AddEnvironmentVariables()
                .AddEnvironmentVariables()
                ;

            _env = environment;
            Configuration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOcelot();
            services.Configure<AudienceModel>(Configuration.GetSection("Audience"));
            services.ConfigureJWTAuthentication(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOcelot().Wait();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }


        /*public static void ConfigureJWTAuthentication(this IServiceCollection services,IConfiguration configuration)
        {
            var audienceConfig = configuration.GetSection("Audience");

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = audienceConfig["Iss"] ,//appSettings.ValidIssuerURL
                        ValidAudience = audienceConfig["Aud"] ,//appSettings.ValidAudienceURL
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(audienceConfig["Secret"]))
                    };
                });
        }*/
    }

    public static class ServiceExtensions
    {
        public static void ConfigureCORS(this IServiceCollection services, string DWebAllowSpecificOrigins)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(DWebAllowSpecificOrigins,
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .WithExposedHeaders(new string[] { "RenewedToken" }));
            });
        }
        public static void ConfigureJWTAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var audienceConfig = configuration.GetSection("Audience");

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = audienceConfig["Iss"],//appSettings.ValidIssuerURL
                        ValidAudience = audienceConfig["Aud"],//appSettings.ValidAudienceURL
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(audienceConfig["Secret"]))
                    };
                });
        }
    }


}
