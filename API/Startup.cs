using System;
using System.Linq;
using API.Errors;
using API.Extensions;
using API.Middleware;
using AutoMapper;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Identity;
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
                    var connUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

                    connUrl = connUrl.Replace("mysql://", string.Empty);
                    var userPassSide = connUrl.Split("@")[0];
                    var hostSide = connUrl.Split("@")[1];

                    var connUser = userPassSide.Split(":")[0];
                    var connPass = userPassSide.Split(":")[1];
                    var connHost = hostSide.Split("/")[0];
                    var connDb = hostSide.Split("/")[1].Split("?")[0];

                    //server=localhost;Uid=gbubemi;Pwd=limited29;Database=IdentityDb
                    connStr = $"server={connHost};Uid={connUser};Pwd={connPass};Database={connDb}";



                }

                x.UseMySql(connStr);

            });

            services.AddDbContext<AppIdentityDbContext>(x =>
            {
                var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                string connStr;


                env = "Production";

                if (env == "Development")
                {
                    connStr = Configuration.GetConnectionString("IdentityConnection");


                }
                else
                {
                    // Use connection string provided at runtime by Heroku.
                    var connUrl = Environment.GetEnvironmentVariable("CLEARDB_DATABASE_URL");

                    Console.WriteLine("Conn Url " + connUrl);

                    connUrl = connUrl.Replace("mysql://", string.Empty);
                    var userPassSide = connUrl.Split("@")[0];
                    var hostSide = connUrl.Split("@")[1];

                    var connUser = userPassSide.Split(":")[0];
                    var connPass = userPassSide.Split(":")[1];
                    var connHost = hostSide.Split("/")[0];
                    var connDb = hostSide.Split("/")[1].Split("?")[0];


                    connStr = $"server={connHost};Uid={connUser};Pwd={connPass};Database={connDb}";



                }

                // x.UseMySql(connStr);
            });

            //i dont know why this has to be here
            services.TryAddSingleton<ISystemClock, SystemClock>();
            services.AddIdentityServices(Configuration);

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRespository<>));
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<ITokenService, TokenService>();

            services.AddAutoMapper(typeof(Startup));

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                                    .Where(e => e.Value.Errors.Count > 0)
                                    .SelectMany(x => x.Value.Errors)
                                    .Select(x => x.ErrorMessage).ToArray();

                    var errorResponse = new ApiValidationErrorResponse
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });

            services.AddSwaggerDocumentation();


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
