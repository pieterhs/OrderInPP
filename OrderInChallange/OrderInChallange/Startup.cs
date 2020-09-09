using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using NLog;
using OrderInTacoChallenge.Extentions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OrderInChallange
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureCors();
            services.ConfigureIISIntegration();
            services.ConfigureLoggerService();
            services.ConfigureRepositoryWrapper();
            services.ConfigureDbContext();
            services.AddControllersWithViews();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, RepositoryContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            //context.Database.EnsureCreated();
            //if (!context.Restaurants.Any())
            //{
                

               PopulateData(context);

                /*foreach (Restaurant restaurant in restaurants)
                {
                    foreach (MenuCategory category in restaurant.Categories)
                    {
                        category.Id = restaurant.Id;
                    }
                    context.Restaurants.Add(restaurant);                    

                    context.Entry(restaurant.Categories).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    
                    //context.Entry(restaurant).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                }

                foreach (var restaurant in context.Restaurants)
                {
                    foreach (var category in restaurant.Categories)
                    {
                        context.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    }
                }
                context.SaveChanges();*/

            //}

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }

        private static void PopulateData(RepositoryContext context)
        {
            List<Restaurant> restaurants;

            using (StreamReader reader = new StreamReader(@"D:\Documents\Google Drive\P&A\Pieter\CV\OrderIn\SampleData.json.js"))
            {
                string json = reader.ReadToEnd();

                restaurants = JsonConvert.DeserializeObject<List<Restaurant>>(json);
            }

            foreach (Restaurant restaurant in restaurants)
            {
                context.Restaurants.Add(restaurant);
            }
            /*
            Restaurant restaurant = new Restaurant
            {
                Id = restaurants[0].Id,
                Name = restaurants[0].Name,
                Rank = restaurants[0].Rank,
                City = restaurants[0].City,
                LogoPath = restaurants[0].LogoPath,
                Suburb = restaurants[0].Suburb
            };
            context.Restaurants.Add(restaurant);

            MenuCategory menuCategory = new MenuCategory
            {
                Id = 1,
                RestaurantId = restaurants[0].Id,
                Name = restaurants[0].Categories[0].Name
            };

            context.Categories.Add(menuCategory);
            */
            context.SaveChanges();
        }
    }
}
