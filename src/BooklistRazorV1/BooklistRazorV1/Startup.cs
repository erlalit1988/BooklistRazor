using BooklistRazorV1.CustomMiddlewares;
using BooklistRazorV1.LocalizationResources;
using LazZiya.ExpressLocalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BooklistRazorV1
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
            var cultures = new[]
            {
                new CultureInfo("ar"),
                new CultureInfo("en"),
                new CultureInfo("cs"),
                new CultureInfo("de"),
                new CultureInfo("es"),
                new CultureInfo("fa"),
                new CultureInfo("fr"),
                new CultureInfo("hi"),
                new CultureInfo("hu"),
                new CultureInfo("it"),
                new CultureInfo("ja"),
                new CultureInfo("ko"),
                new CultureInfo("nl"),
                new CultureInfo("pl"),
                new CultureInfo("pt"),
                new CultureInfo("pt-br"),
                new CultureInfo("ru"),
                new CultureInfo("sv"),
                new CultureInfo("tr"),
                new CultureInfo("uk"),
                new CultureInfo("vi"),
                new CultureInfo("zh")

            };

            services.AddControllersWithViews().AddExpressLocalization<ExpressLocalizationResource, ViewLocalizationResource>(ops =>
            {
                // When using all the culture providers, the localization process will
                // check all available culture providers in order to detect the request culture.
                // If the request culture is found it will stop checking and do localization accordingly.
                // If the request culture is not found it will check the next provider by order.
                // If no culture is detected the default culture will be used.

                // Checking order for request culture:
                // 1) RouteSegmentCultureProvider
                //      e.g. http://localhost:1234/tr
                // 2) QueryStringCultureProvider
                //      e.g. http://localhost:1234/?culture=tr
                // 3) CookieCultureProvider
                //      Determines the culture information for a request via the value of a cookie.
                // 4) AcceptedLanguageHeaderRequestCultureProvider
                //      Determines the culture information for a request via the value of the Accept-Language header.
                //      See the browsers language settings

                // Uncomment and set to true to use only route culture provider
                ops.UseAllCultureProviders = false;
                ops.ResourcesPath = "LocalizationResources";
                ops.RequestLocalizationOptions = o =>
                {
                    o.SupportedCultures = cultures;
                    o.SupportedUICultures = cultures;
                    o.DefaultRequestCulture = new RequestCulture("en");
                };
            }); ;

           /* services.Configure<EmployeeLocationOptions>(options =>
            {
                options.CityName = "Atlanta";
                options.CountryName = "USA";
            });*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env   /*, IOptions<EmployeeLocationOptions> msgOptions*/)
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

          /* // 1
            app.Use(async (context, next) =>
            {
                if (context.Request.Method == HttpMethods.Get
                && context.Request.Query["isCertified"] == "true")
                {
                    await context.Response.WriteAsync("Message from custom Middleware \n");
                }
                await next();
            });

            //2
            app.UseMiddleware<RequestQueryStringMiddleware>();

            //4
            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/short")
                {
                    await context.Response.WriteAsync("$Request Short Circuited");
                }
                else
                {
                    await next();
                }

            });
            //3
            app.Use(async (context, next) =>
            {
                await next();
                await context.Response.WriteAsync($"\nStatus Code: {context.Response.StatusCode}");
            });
           

            //5 using Map to create middleware branhes
            app.Map("/branch", branch =>
             {
                 branch.UseMiddleware<RequestQueryStringMiddleware>();

                 branch.Run(async (context) =>
                 {
                     await context.Response.WriteAsync($"BranchRun Middleware");
                 });

                 branch.Use(async (context, next) =>
                 {
                     await context.Response.WriteAsync($"Branch Middleware");
                 });


             });
            //6
            app.Map("/branch2", branch2 =>
             {
                branch2.Run(new RequestQueryStringMiddleware().Invoke);
             });

            //7
            app.Use(async (context, next) =>
            {
                await next();
                await context.Response.WriteAsync($"\nStatus Code: {context.Response.StatusCode}");
            });
            //location with class middleware
            app.UseMiddleware<EmployeeLocationMiddleware>();

            //new middlerware for employee location based
            app.Use(async (context, next) =>
            {
                if(context.Request.Path=="/Employeelocation")
                {
                    EmployeeLocationOptions opts = msgOptions.Value;
                    await context.Response.WriteAsync($"{opts.CityName}, {opts.CountryName}");

                }
                else
                {
                    await next();
                }
            });*/

            app.UseHttpsRedirection();
            app.UseStaticFiles();

          
            app.UseRouting();

            app.UseAuthorization();

            app.UseRequestLocalization();

            app.UseEndpoints(endpoints =>
            {
                 //endpoints.MapGet("/", async context =>
                 //{
                 //    await context.Response.WriteAsync("Hello world!");
                 //});

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{culture=en}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
