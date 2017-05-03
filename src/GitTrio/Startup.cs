using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using GitTrio.Models;
using Microsoft.Extensions.Configuration;

namespace GitTrio
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddEntityFramework()
               .AddDbContext<GitTrioContext>(options =>
                   options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            var context = app.ApplicationServices.GetService<GitTrioContext>();
            AddTestData(context);

            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.Run(async (context1) =>
            {
                await context1.Response.WriteAsync("Hello World!");
            });
        }

        private static void AddTestData(GitTrioContext context)
        {
            var cupcake1 = new Cupcake("Limoncello Meringue", "Vanilla cake with marshmallow frosting, browned to perfection.", 2, "Vanilla", "Marshmallow", "None", 24, "http://www.cupcakeroyale.com/wp-content/uploads/2016/04/Limoncello.jpg");
            context.Cupcakes.Add(cupcake1);

            var cupcake2 = new Cupcake("Rhubarb Almond Buckle", "Our vanilla cupcake filled with a tangy rhubarb compote, topped with fresh strawberry buttercream and almond streusel. Available May only!", 3, "Almond", "Rhubarb", "Almonds", 36, "http://www.cupcakeroyale.com/wp-content/uploads/2016/03/Rhubarb-Crisp-084.jpg");
            context.Cupcakes.Add(cupcake2);

            context.SaveChanges();
        }
    }
}
