using System;
using System.Linq;
using API.Errors;
using API.Extensions;
using API.Middleware;
using AutoMapper;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace API
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
            services.AddControllers();


            services.AddDbContext<TranscriptContext>(x =>
            {

                var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                string connStr;

                if (env == "Development")
                {
                    connStr = Configuration.GetConnectionString("TranscriptConnection");
                }
                else
                {
                    // Use connection string provided at runtime by Heroku.
                    var connUrl = Environment.GetEnvironmentVariable("CLEARDB_DATABASE_URL");

                    Console.WriteLine("Connection string::" + connUrl);

                    connUrl = connUrl.Replace("mysql://", string.Empty);
                    var userPassSide = connUrl.Split("@")[0];
                    var hostSide = connUrl.Split("@")[1];

                    var connUser = userPassSide.Split(":")[0];
                    var connPass = userPassSide.Split(":")[1];
                    var connHost = hostSide.Split("/")[0];
                    var connDb = hostSide.Split("/")[1].Split("?")[0];

                    //server=localhost;Uid=gbubemi;Pwd=limited29;Database=IdentityDb
                    connStr = $"server={connHost};Uid={connUser};Pwd={connPass};Database={connDb};SslMode=none";

                }

                x.UseMySql(connStr, ServerVersion.AutoDetect(connStr));
            });

            services.AddApplicationServices();

            //i dont know why this has to be here
            services.TryAddSingleton<ISystemClock, SystemClock>();
            services.AddIdentityServices(Configuration);

            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerDocumentation();

            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // if (env.IsDevelopment())
            // {
            //     app.UseDeveloperExceptionPage();
            // }

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseStatusCodePagesWithRedirects("/errors/{0}");

            app.UseHttpsRedirection();

            app.UseCors("CorsPolicy");

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwaggerDocumentation();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });



        }
    }
}
