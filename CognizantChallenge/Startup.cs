using System;
using CognizantChallenge.Application.Tasks.Services;
using CognizantChallenge.Application.User.Services;
using CognizantChallenge.DistributedService;
using CognizantChallenge.DistributedService.JDoodle;
using CognizantChallenge.DistributedService.JDoodle.DTO;
using CognizantChallenge.Domain.Context;
using CognizantChallenge.Domain.Repositories;
using CognizantChallenge.Domain.Services;
using CognizantChallenge.Infrastructure.Context;
using CognizantChallenge.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CognizantChallenge {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddControllersWithViews();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddHttpClient<ICompilerService<JDoodleCompileOutput, JDoodleCompileInput>, JDoodleCompilerService>(config => {
                config.BaseAddress = new Uri("https://api.jdoodle.com/v1/");
            });
            services.AddDbContext<ITaskContext, TaskContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("CognizantChallengeContext"), sqlOptions => sqlOptions.EnableRetryOnFailure());
            });

            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<ITaskDomainService, TaskDomainService>();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/build"; });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseExceptionHandler("/Error");

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    "default",
                    "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa => {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment()) spa.UseReactDevelopmentServer("start");
            });
        }
    }
}