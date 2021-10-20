using Locadora.Domain.Handlers;
using Locadora.Domain.Interfaces.Repositories;
using Locadora.Infra.Data.DataContexts;
using Locadora.Infra.Data.Repositories;
using Locadora.Infra.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Locadora.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region AppSettings

            AppSettings appSettings = new AppSettings();
            Configuration.GetSection("AppSettings").Bind(appSettings);
            services.AddSingleton(appSettings);

            #endregion

            #region DataContexts

            services.AddScoped<DataContext>();

            #endregion

            #region Repositories

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IFilmeRepository, FilmeRepository>();
            services.AddScoped<IVotoRepository, VotoRepository>();

            #endregion

            #region Handlers

            services.AddScoped<UsuarioHandler, UsuarioHandler>();
            services.AddScoped<FilmeHandler, FilmeHandler>();
            services.AddScoped<VotoHandler, VotoHandler>();
            services.AddScoped<AutenticacaoHandler, AutenticacaoHandler>();

            #endregion


            services.AddControllers();

            #region Swagger

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Locadora.Api", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"Autorização utilizando bearer token. Digite 'Bearer' [espaço] e o token.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference()
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
            });

            #endregion

            #region Authentication

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidAudience = appSettings.Audience,
                    ValidIssuer = appSettings.Issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.Secret)),
                    ClockSkew = TimeSpan.Zero
                };
            });

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Locadora.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
