using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ncode.Grocerly.Application.Common;
using Ncode.Grocerly.Application.Queries;
using Ncode.Grocerly.Common;
using Ncode.Grocerly.Infrastructure.Persistence;
using Ncode.Grocerly.RestApi.Authentication;
using Ncode.Grocerly.RestApi.ExceptionHandling;
using Ncode.Grocerly.RestApi.Serializers;
using Newtonsoft.Json.Converters;

namespace Ncode.Grocerly.RestApi
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
            services.AddDbContext<GrocerlyDbContext>(
                //opt =>  opt.UseInMemoryDatabase("grocerly"));
                opt => opt.UseSqlServer(Configuration.GetConnectionString("grocerly")));

            services.AddTransient<IGrocerlyDbContext, GrocerlyDbContext>();

            services.AddTransient<IIdGenerator, IdGenerator>();

            services.AddTransient<IClock, Clock>();

            services.AddMediatR(typeof(GetShopperProfile));

            services.AddControllers(options => options.Filters.Add(new ExceptionFilter()))
                .AddNewtonsoftJson(config => {
                    config.SerializerSettings.Converters.Add(new IdToStringConverter());
                    config.SerializerSettings.Converters.Add(new StringEnumConverter());
                });

            services.AddSwaggerGen();

            services.AddAuthentication(options => options.DefaultAuthenticateScheme = "DummyUser")
                .AddScheme<DummyAuthenticationOptions, DummyAuthenticationHandler>("DummyUser", options => { }) ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger(); 
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Grocerly API V1");
            });

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
