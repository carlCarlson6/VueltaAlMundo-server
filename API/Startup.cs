using Application.UserUseCases;
using Domain.Entities;
using Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MongoRepository.Settings;

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
            this.ConfigureRepositories(services);   
            this.ConfigureUseCases(services);
            this.ConfigureDomain(services);

            services.AddControllers();
        }

        public void ConfigureRepositories(IServiceCollection services)
        {
            services.Configure<UserMongoSettings>(Configuration.GetSection(nameof(UserMongoSettings)));
            services.AddSingleton<IMongoRepositorySettings<User>, UserMongoSettings>(serviceProvider => serviceProvider.GetRequiredService<IOptions<UserMongoSettings>>().Value);
        }
        public void ConfigureUseCases(IServiceCollection services)
        {
            services.AddSingleton<CreateUser>();
        }
        public void ConfigureDomain(IServiceCollection services)
        {
            services.AddSingleton<UserFinder>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
