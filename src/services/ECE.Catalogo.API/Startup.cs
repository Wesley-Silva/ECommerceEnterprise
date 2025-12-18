using ECE.Catalogo.API.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ECE.WebAPI.Core.Identidade;

namespace ECE.Catalogo.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        //public Startup(IHostEnvironment hostEnvironment)
        //{
        //    var builder = new ConfigurationBuilder()
        //        .SetBasePath(hostEnvironment.ContentRootPath)
        //        .AddJsonFile("appsettings.json", true, true)
        //        .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
        //        .AddEnvironmentVariables();

        //    if (hostEnvironment.IsDevelopment())
        //    {
        //        builder.AddUserSecrets<Startup>();
        //    }

        //    Configuration = builder.Build();
        //}

        public Startup(IHostEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            if (hostEnvironment.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            Configuration = builder.Build();

            // DEBUG: Log para verificar o carregamento
            var connString = Configuration.GetConnectionString("DefaultConnection");
            System.Diagnostics.Debug.WriteLine($"=== STARTUP DEBUG ===");
            System.Diagnostics.Debug.WriteLine($"Environment: {hostEnvironment.EnvironmentName}");
            System.Diagnostics.Debug.WriteLine($"ContentRootPath: {hostEnvironment.ContentRootPath}");
            System.Diagnostics.Debug.WriteLine($"Connection String: {connString ?? "NULL"}");
            System.Diagnostics.Debug.WriteLine($"===================");
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiConfiguration(Configuration);

            services.AddJwtConfiguration(Configuration);

            services.AddSwaggerConfiguration();

            services.RegisterService();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwaggerConfiguration();

            app.UseApiConfiguration(env);
        }
    }
}
