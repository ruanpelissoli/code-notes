using Carter;
using CodeNotes.API.Middlewares;
using CodeNotes.Domain.DependencyInjection;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace CodeNotes.API;

public class DependencyInstaller : IDependencyInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(o =>
        {
            o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(o =>
        {
            o.IncludeErrorDetails = true;
            o.SaveToken = true;
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("SupabaseApiSecret").Value!)),
                ValidateIssuer = false,
                ValidateAudience = true,
                ValidAudience = "authenticated",
            };
            o.Events = new JwtBearerEvents()
            {
                //
            };
        });
        services.AddAuthorization();

        services.AddTransient<GlobalExceptionHandlerMiddleware>();

        services.AddCors(options =>
        {
            options.AddPolicy("AllowWebApp", builder =>
            {
                builder
                    .WithOrigins("http://localhost:3000")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "CodeNotes.API",
                Version = "v1.0.0"
            });

            var securitySchema = new OpenApiSecurityScheme
            {
                Description = "Using the Authorization header with the Bearer scheme.",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            };

            options.AddSecurityDefinition("Bearer", securitySchema);

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                { securitySchema, new[] { "Bearer" } }
            });
        });

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviorMiddleware<,>));

        services.AddCarter(
            new DependencyContextAssemblyCatalog(typeof(DependencyInstaller).Assembly));
    }
}
