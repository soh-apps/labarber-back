using LaBarber.API.SwaggerExamples;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace LaBarber.API.Setup
{
    public static class AddSwaggerConfig
    {
        public static void AddSwaggerGenConfig(this IServiceCollection services, string xmlFile)
        {
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            services.AddSwaggerGen(delegate (SwaggerGenOptions c)
            {
                c.EnableAnnotations();
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization Header"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },

                    Array.Empty<string>()
                }});

                c.CustomSchemaIds((Type x) => x.FullName);
                c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
                c.SchemaFilter<EnumSchemaFilter>();
                c.ExampleFilters();
            });
        }
    }
}