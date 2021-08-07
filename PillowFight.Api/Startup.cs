using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PillowFight.Api.Hubs;
using PillowFight.BusinessServices;
using PillowFight.Repositories;
using PillowFight.Repositories.DataServices;

namespace PillowFight.Api
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
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();
            services.AddSignalR();
            services.AddDbContext<PillowContext>(p_dbContextOptionsBuilder => p_dbContextOptionsBuilder.UseNpgsql(Configuration.GetConnectionString("AppDB"), b => b.MigrationsAssembly("PillowFight.Api")));
            services.AddScoped<IDatastore>(sp => new PostgresDatastore(sp.GetRequiredService<PillowContext>()))
                .AddScoped<IPlayerBL>(sp => new PlayerBL(sp.GetRequiredService<IDatastore>()));
            services.AddCors(p_corsOptions =>
            {
                p_corsOptions.AddDefaultPolicy(p_corsPolicyBuilder =>
                {
                    p_corsPolicyBuilder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            } 
            );
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PillowFight.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PillowFight.Api v1"));
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<GameHub>("/gameHub");
            });
        }
    }
}
