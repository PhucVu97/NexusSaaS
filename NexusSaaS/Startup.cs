using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NexusSaaS.Data;
using NexusSaaS.MiddleWare;
using NexusSaaS.Models;
using NexusSaaS.Repository;
using NexusSaaS.Repository.Interface;
using NexusSaaS.Ultil;
using System;

namespace NexusSaaS
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });


            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddDbContext<NexusSaaSDbContext>(options =>
                options
                .UseSqlServer(Configuration.GetConnectionString("NexusSaaSSqlDb")));
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromDays(30);
            });
            services.AddDbContext<NexusSaaSDbContext>();
            services.AddTransient<IFeatureRepository, FeatureRepository>();
            services.AddTransient<IMessageRepository, MessageRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<ILoginRepository, LoginRepository>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<StringUltil, StringUltil>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
            app.UseWhen(
                context => context.Request.Path.StartsWithSegments("/admin"), appBuilder =>
            {
                appBuilder.UseMiddleware<CheckAuthenticationMiddleWare>();
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "admin",
                    template: "admin/{controller}/{action}/{id?}",
                    defaults: new { controller = "Users", action = "Index" }
                );
            });
        }
    }
}
