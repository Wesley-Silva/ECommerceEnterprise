using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace ECE.Catalogo.API.Configuration
{
    public class IdentityConfig
    {
        //public static class IdentityConfig
        //{
        //    public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services,
        //        IConfiguration configuration)
        //    {
        //        services.AddDbContext<ApplicationDbContext>(options =>
        //        {
        //            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        //        });

        //        services.AddDefaultIdentity<IdentityUser>()
        //            .AddRoles<IdentityRole>()
        //            .AddErrorDescriber<IdentityMensagensPortugues>()
        //            .AddEntityFrameworkStores<ApplicationDbContext>()
        //            .AddDefaultTokenProviders();

        //        // JWT

        //        var appSettingsSction = configuration.GetSection("AppSettings");
        //        services.Configure<AppSettings>(appSettingsSction);

        //        var appSettings = appSettingsSction.Get<AppSettings>();
        //        var key = Encoding.ASCII.GetBytes(appSettings.Secret);

        //        services.AddAuthentication(options =>
        //        {
        //            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //        }).AddJwtBearer(bearerOptions =>
        //        {
        //            bearerOptions.RequireHttpsMetadata = true;
        //            bearerOptions.SaveToken = true;
        //            bearerOptions.TokenValidationParameters = new TokenValidationParameters
        //            {
        //                ValidateIssuerSigningKey = true,
        //                IssuerSigningKey = new SymmetricSecurityKey(key),
        //                ValidateIssuer = true,
        //                ValidateAudience = true,
        //                ValidAudience = appSettings.ValidoEm,
        //                ValidIssuer = appSettings.Emissor
        //            };
        //        });

        //        //services.AddJwtConfiguration(configuration);

        //        return services;
        //    }

        //    public static IApplicationBuilder UseIdentityConfiguration(this IApplicationBuilder app)
        //    {
        //        app.UseAuthentication();
        //        app.UseAuthorization();

        //        return app;
        //    }
        //}
    }
}
