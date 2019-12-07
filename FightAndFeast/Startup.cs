using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using FightAndFeast.DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FightAndFeast
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
            // to get all settings
            var authSettings = Configuration.GetSection("AuthenticationSettins");
            // to get a specific part of settings
            var connectionString = Configuration.GetValue<string>("ConnectionStrings:FightAndFeast");

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddCors(options => options.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            //    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //        .AddJwtBearer(options =>
            //        {
            //            options.IncludeErrorDetails = true;
            //            options.Authority = authSettings["Authority"];
            //            options.TokenValidationParameters = new TokenValidationParameters
            //            {
            //                ValidateIssuer = true,
            //                ValidIssuer = authSettings["Issuer"],
            //                ValidateAudience = true,
            //                ValidAudience = authSettings["Audience"],
            //                ValidateLifetime = true
            //            };
            //        });

            //    // common services with <servicesToBuild> and (specific instructions)
            //    services.AddTransient<SqlConnection>(provider => new SqlConnection(connectionString));
            //        // transient lifecycle, single use, creates a new instance every time the service is requested
            //    services.AddScoped<ProductRepository>();
            //        // scoped lifecycle, can be reused safely, uses a single instance and multiple instances will use this single instance
            //    services.AddSingleton<IConfiguration>(Configuration);
            //        // singleton lifecycle, only one instance ever (kind of like static)
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors("MyPolicy");

            app.UseHttpsRedirection();
            app.UseMvc();

        }
    }
}
