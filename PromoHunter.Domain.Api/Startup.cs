using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PromoHunter.Domain.Handlers;
using PromoHunter.Domain.Infra.Contexts;
using PromoHunter.Domain.Infra.Repositories;
using PromoHunter.Domain.Repositories;

namespace PromoHunter.Domain.Api
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
            services.AddSwaggerGen();

            var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));
            services.AddDbContext<DataContext>(
                dbContextOptions => dbContextOptions
                    .UseMySql(Configuration.GetConnectionString("connectionString"), serverVersion, b => b.MigrationsAssembly("PromoHunter.Domain.Api"))
            );
            services.AddTransient<IPromotionRepository, PromotionRepository>();
            services.AddTransient<PromotionHandler, PromotionHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
