using GestaoMotel.Domain.Entities.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GestaoMotel.API.Configuration;

public static class JwtConfig
{
    public static void AddJwtConfiguration(this IServiceCollection services,
        IConfiguration configuration)
    {
        var tokenConfigurations = new AppSettings();
        new ConfigureFromConfigurationOptions<AppSettings>(
                configuration.GetSection("AppSettings")
                ).Configure(tokenConfigurations);

        services.AddSingleton(tokenConfigurations);

        var appSettingsSection = configuration.GetSection("AppSettings");

        services.Configure<AppSettings>(appSettingsSection);

        var appSettings = appSettingsSection.Get<AppSettings>();
        var key = Encoding.ASCII.GetBytes(appSettings.Secret);

        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer("Bearer", x =>
        {
            x.RequireHttpsMetadata = true;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = appSettings.Audience,
                ValidIssuer = appSettings.Issuer
            };
        });

        services.AddAuthorization(opts =>
        {
            opts.AddPolicy("Papel", policy =>
                policy.RequireRole("Gestor","Supervisor","Backoffice"));

            opts.AddPolicy("Supervisor", policy =>
                policy.RequireClaim("Gerente", "true"));
            opts.AddPolicy("Supervisor", policy =>
                    policy.RequireClaim("Administrador", "true"));

            opts.AddPolicy("Gestor", policy =>
                    policy.RequireClaim("Administrador","true"));

            opts.AddPolicy("Backoffice", policy =>
                policy.RequireClaim("Gerente", "true"));

        });
    }
}