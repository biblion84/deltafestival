using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeltaFestivalAPI.Database;
using DeltaFestivalAPI.IRepository;
using DeltaFestivalAPI.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace DeltaFestivalAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //Ajout de la base de données dans les services
            services.AddDbContext<DeltaDbContext>(opt =>
            opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Implémentation du swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Delta Festival Swagger", Version = "v1" });
            });

            // Injection de dépendances des repos
            services.Add(new ServiceDescriptor(typeof(IMoodRepository), typeof(MoodRepository), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IPublicationRepository), typeof(PublicationRepository), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IRoleRepository), typeof(RoleRepository), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IUserRepository), typeof(UserRepository), ServiceLifetime.Transient));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Delta Festival Swagger");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
