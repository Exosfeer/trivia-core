using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using trivia_api.Hubs;

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
            services.AddControllersWithViews();
            services.AddSignalR()
                    .AddAzureSignalR();
      

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
                            .WithOrigins(
                                "http://localhost:3000",
                                "https://localhost:3001",
                                "http://rortzxzsybf4m.service.signalr.net",
                                "https://rortzxzsybf4m.service.signalr.net",
                                "https://rortzxzsybf4m.service.signalr.net:3000",
                                "https://rortzxzsybf4m.service.signalr.net:3001",
                                "http://treevia.netlify.app:3000",
                                "http://treevia.netlify.app:3001",
                                "https://treevia.netlify.app:3000",
                                "https://treevia.netlify.app:3001"
                            )
                        ;
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
            app.UseMvc();
            app.UseFileServer();
            app.UseAzureSignalR(routes =>
            {
                routes.MapHub<HubStandard>("/hubstandard");
                routes.MapHub<GlobalChat>("/globalchat");
                routes.MapHub<ConnectedClient>("/connected-client");
                routes.MapHub<CategorySubject>("/category-subject");
            });
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            //app.UseAzureSignalR();
            app.UseAuthorization();
            app.UseCors("ClientPolicies");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHub<HubStandard>("/hubstandard");
                endpoints.MapHub<GlobalChat>("/globalchat");
                endpoints.MapHub<ConnectedClient>("/connected-client");
                endpoints.MapHub<ActiveChat>("/active-chat");
                endpoints.MapHub<ActiveGame>("/active-games");
                endpoints.MapHub<ActivePlayer>("/active-players");
                endpoints.MapHub<CategorySubject>("/category-subject");
                endpoints.MapHub<SubjectQuestion>("/subject-question");
                endpoints.MapHub<SubjectQuestionAnswer>("/subject-question-answer");
            });

        }
    }
}
