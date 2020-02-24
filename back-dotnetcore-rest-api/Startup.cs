using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using back_dotnetcore_rest_api.Services;
using back_dotnetcore_rest_api.Repositories;
using back_dotnetcore_rest_api.Persistence;
using back_dotnetcore_rest_api.Mapping;
using back_dotnetcore_rest_api.Resources;

namespace back_dotnetcore_rest_api
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

            services.AddDbContext<CalculatorDBContext>(
                options =>
                {
                    options.UseInMemoryDatabase("CalculatorDB");
                }
            );

            services.AddScoped<IUserActionService, UserActionService>();
            services.AddScoped<IUserActionRepo, UserActionRepo>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper( typeof(Startup) );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseHsts();
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
