using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using Logging;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.IO;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Persistenza.Models;
using DomainModel.Common;
using Persistenza;

namespace RockApi
{
    public class Startup
    {
        private Container container = new SimpleInjector.Container();

        public Startup(IConfiguration configuration)
        {
            // Set to false. This will be the default in v5.x and going forward.
            container.Options.ResolveUnregisteredConcreteTypes = false;

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //Swagger

            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Gestione Missione BASE",
                    Version = "v1",
                    Description = "Servizi per la gestione delle missioni"
                });
                swagger.SwaggerDoc("v2", new OpenApiInfo
                {
                    Title = "Gestione Missione BASE",
                    Version = "v2",
                    Description = "Servizi per la gestione delle missioni"
                });

                //swagger.CustomSchemaIds(c => c.FullName);

                var filePath = Path.Combine(System.AppContext.BaseDirectory, "Missioni.xml");
                swagger.IncludeXmlComments(filePath, includeControllerXmlComments: true);

            });


            // Versionamento dei servizi

            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
                config.ApiVersionReader = new UrlSegmentApiVersionReader();
            });

            services.AddVersionedApiExplorer(setup =>
            {
                setup.GroupNameFormat = "'v'VVV";
                setup.SubstituteApiVersionInUrl = true;
            });

            // FINE versionamento dei servizi


            // Connessione al DB
            services.AddDbContext<missioniDbContext>(options =>
                    options.UseNpgsql(Configuration.GetConnectionString("MissioniconnectionString")));


            // DI per i servizi al DB

            services.AddScoped<IDbMethods, DbMethods>();

            IntegrateSimpleInjector(services);
        }

        private void IntegrateSimpleInjector(IServiceCollection services)
        {
            // Sets up the basic configuration that for integrating Simple Injector with ASP.NET
            // Core by setting the DefaultScopedLifestyle, and setting up auto cross wiring.
            services.AddSimpleInjector(container, options =>
            {
                // AddAspNetCore() wraps web requests in a Simple Injector scope and allows
                // request-scoped framework services to be resolved.
                options.AddAspNetCore()

                    // Ensure activation of a specific framework type to be created by Simple
                    // Injector instead of the built-in configuration system. All calls are
                    // optional. You can enable what you need. For instance, PageModels and
                    // TagHelpers are not needed when you build a Web API.
                    .AddControllerActivation()
                    .AddViewComponentActivation();

                // Optionally, allow application components to depend on the non-generic ILogger
                // (Microsoft.Extensions.Logging) or IStringLocalizer
                // (Microsoft.Extensions.Localization) abstractions.
                options.AddLogging();
            });

            InitializeContainer();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // see https://simpleinjector.readthedocs.io/en/latest/aspnetintegration.html

            // UseSimpleInjector() finalizes the integration process.
            app.UseSimpleInjector(container);

            app.UseCors(x => x
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true) // allow any origin
                    .AllowCredentials());

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Order API V1");
                options.SwaggerEndpoint("/swagger/v2/swagger.json", "Order API V2");

            });


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Add custom middleware
            //app.UseMiddleware<CustomMiddleware1>(container);
            //app.UseMiddleware<CustomMiddleware2>(container);

            LogConfigurator.Configure();

            container.Verify();
        }

        private void InitializeContainer()
        {
            CompositionRoot.RootBindings.Bind(container);
        }
    }
}