using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FootballWebApi.Data;
using FootballWebApi.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using VersioningAsp.netCoreApiIsWithSwagger.Helper;

namespace FootballWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddDbContext<FootballAppContext>(options => options.UseSqlite("filename=FootballMatchesDB.db"));
            services.AddApiVersioning(options =>
            {
                options.UseApiBehavior = false;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion =  new ApiVersion(2,1);
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new QueryStringApiVersionReader("version"),
                    new HeaderApiVersionReader("X-Api-Version"),
                    new MediaTypeApiVersionReader("v")
                );
                //options.ApiVersionReader = new HeaderApiVersionReader("v");
                options.ReportApiVersions = true;


                //SwaggerConfig.UseQueryStringApiVersion("version");
                SwaggerConfig.UseCustomHeaderApiVersion("X-Api-Version");  // Заработало! разошлись на CustomHeader для Swagger UI
                //SwaggerConfig.UseAcceptHeaderApiVersion("v");

        });  
            x

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       ValidIssuer = Configuration["Tokens:Issuer"],
                       ValidAudience = Configuration["Tokens:Issuer"],
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"])),
                       ClockSkew = TimeSpan.Zero,
                   };
           });


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FootballWebApiV1", Version = "v1", Description = "V1 Deprecated. Use V2" });
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "FootballWebApiV2", Version = "v2", Description = "Test Description" });

                #region SwaggerLoginJwtConfig
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n" +
                                  "Enter 'Bearer' [space] and then your token in the text input below." +
                                  "\r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(JWTSecurityRequirement);
                #endregion


                #region SwaggerVersioningConfigs
                c.OperationFilter<SwaggerParameterFilters>();
                c.DocumentFilter<SwaggerVersionMapping>();

                c.DocInclusionPredicate((version, desc) =>
                {
                    if (!desc.TryGetMethodInfo(out MethodInfo methodInfo)) 
                        return false;

                    var versions = methodInfo.DeclaringType.GetCustomAttributes(true).OfType<ApiVersionAttribute>().SelectMany(attr => attr.Versions);
                    var maps = methodInfo.GetCustomAttributes(true).OfType<MapToApiVersionAttribute>().SelectMany(attr => attr.Versions).ToArray();
                    version = version.Replace("v", "");
                    return versions.Any(v => v.ToString() == version && maps.Any(v => v.ToString() == version));
                });
                #endregion
            });

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger(options => options.RouteTemplate = "swagger/{documentName}/swagger.json");
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "FootballWebApi v1");
                    c.SwaggerEndpoint("/swagger/v2/swagger.json", "FootballWebApi v2");
                });
            }

            app.UseHttpsRedirection();
            app.UseRouting();


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private readonly OpenApiSecurityRequirement JWTSecurityRequirement = new OpenApiSecurityRequirement()
        {
            {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header,
            },
            new List<string>()
            }
        };
    }
}
