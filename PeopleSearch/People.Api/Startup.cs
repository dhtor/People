using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using People.DataLayer.Context;
using People.DataLayer.Factory;
using People.Services;
using System;

namespace People.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add a CORS Policy to allow "Everything":
            services.AddCors(o =>
            {
                o.AddPolicy("Everything", p =>
                {
                    p.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                });
            });

            // Add framework services.
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // DbContextOptions:
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(Configuration.GetConnectionString("DefaultConnection"))
                .Options;

            services.AddSingleton(dbContextOptions);
            services.AddSingleton<ApplicationDbContextOptions>();
            services.AddSingleton<IApplicationDbContextFactory, ApplicationDbContextFactory>();
            services.AddDbContext<ApplicationDbContext>();

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new ServicesModule());
            containerBuilder.RegisterAssemblyTypes(GetType().Assembly).AsImplementedInterfaces();
            containerBuilder.Populate(services);
            var container = containerBuilder.Build();
            return new AutofacServiceProvider(container);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(policyName: "Everything");

            app.UseMvc();
        }
    }
}
