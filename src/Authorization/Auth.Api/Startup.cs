using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth.Api.Configuration;
using Auth.Api.Validators;
using Auth.Application.Services;
using Auth.Core.Repositories;
using Auth.Infrastructure.Data;
using Auth.Infrastructure.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Auth.Api
{
    public class Startup
    {
        private readonly IdentityConfiguration identityConfiguration;

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
            this.identityConfiguration = configuration.Get<IdentityConfiguration>();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(this.identityConfiguration.Authentication);

            services.AddDbContext<AuthContext>(options => options.UseSqlServer(this.Configuration.GetConnectionString("Identity")), ServiceLifetime.Singleton);
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddControllers().AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssemblyContaining<AuthValidator>();
            });

            services.AddSwaggerGen(sa =>
            {
                sa.SwaggerDoc("v1", new OpenApiInfo { Title = "Auth API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(sa =>
            {
                sa.SwaggerEndpoint("/swagger/v1/swagger.json", "Auth API V1");
            });
        }
    }
}
