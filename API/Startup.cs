using Application.UserUseCases;
using Domain.Entities;
using Domain.Repositories;
using Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MongoRepository.Settings;
using MongoRepository.UserRepo;

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
            this.ConfigureDB(services);   
            this.ConfigureUseCases(services);
            this.ConfigureDomain(services);

            services.AddControllers();
        }

        public void ConfigureDB(IServiceCollection services)
        {
            services.Configure<UserMongoSettings>(Configuration.GetSection(nameof(UserMongoSettings)));
            services.AddSingleton<IMongoRepositorySettings<UserModel>, UserMongoSettings>(serviceProvider => serviceProvider.GetRequiredService<IOptions<UserMongoSettings>>().Value);
        }
        public void ConfigureUseCases(IServiceCollection services)
        {
            services.AddSingleton<CreateUser>();
            services.AddSingleton<ListAllUsers>();
        }
        public void ConfigureDomain(IServiceCollection services)
        {
            services.AddSingleton<IUserRepository, UserMongoRepository>();
            services.AddSingleton<UserFinder>();
            services.AddSingleton<CheckNewUser>();
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
