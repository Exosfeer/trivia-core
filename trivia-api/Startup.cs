using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using trivia_api.Hubs;
using trivia_api.ORM;

namespace trivia_api
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
            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();


            //ORM-setup with Entity Framework
            var connectionString = @"Server=mssql.fhict.local;Database=dbi458461;User Id=dbi458461;Password=M@?NSr_qHc$eFe9&";
            services
                .AddDbContext<TreeviaDbContext>(
                    options => options.UseSqlServer(connectionString)
                );
            ;

            //Real-time channels with SignalR
            services.AddSignalR();

            //Cross-Origin Resource Sharing
            services.AddCors(options =>
                options.AddPolicy(
                    "ClientPolicies",
                     builder =>
                     {
                         builder
                            .AllowAnyOrigin()
                            .AllowCredentials()
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .WithOrigins("http://treevia.netlify.app:3000", "https://treevia.netlify.app:3001","http://localhost:3000", "https://localhost:3001");
                     })
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseCors("ClientPolicies");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHub<HubStandard>("/hubstandard");
                endpoints.MapHub<GlobalChat>("/globalchat");
                endpoints.MapHub<ConnectedClient>("/global/clients");
                endpoints.MapHub<ActiveChat>("/global/chat");
                endpoints.MapHub<ActiveGame>("/active/games");
                endpoints.MapHub<ActivePlayer>("/active/players");
                endpoints.MapHub<CategorySubject>("/api/categories");
                endpoints.MapHub<SubjectQuestion>("/api/questions");
                endpoints.MapHub<SubjectQuestionAnswer>("/api/answers");
            });

        }
    }
}