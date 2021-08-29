using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace LocalizeCulture
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
            services.AddLocalization(opt =>
            {
                opt.ResourcesPath = "Resources";

            });
            //services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix,
            //    opt =>
            //    {
            //        opt.ResourcesPath = "Resources";

            //    })
            //    .AddDataAnnotationsLocalization();
            //services.Configure<RequestLocalizationOptions>(
            //    otp =>
            //    {
            //        var supportedCultuers = new List<CultureInfo>
            //        {
            //            new CultureInfo("en"),
            //            new CultureInfo("ar"),
            //            new CultureInfo("hi")
            //        };
            //        otp.SupportedCultures = supportedCultuers;
            //        otp.SupportedUICultures = supportedCultuers;
            //        otp.DefaultRequestCulture = new RequestCulture("en");
            //    });
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.IsEssential = true;
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            services.AddControllersWithViews()/*.AddSessionStateTempDataProvider()*/
            .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();
            services.Configure<RequestLocalizationOptions>(
                otp =>
                {
                    var supportedCultuers = new List<CultureInfo>
                    {
                        new CultureInfo("en"),
                        new CultureInfo("hi"),
                         new CultureInfo("ar"){DateTimeFormat={Calendar=new GregorianCalendar() } }
                    };
                    otp.SupportedCultures = supportedCultuers;
                    otp.SupportedUICultures = supportedCultuers;
                    otp.DefaultRequestCulture = new RequestCulture("en");
                });
            //services.AddSession();
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

            app.UseSession();

            app.UseRequestLocalization(app.ApplicationServices.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);
            //var supportedCultures = new[] { "en", "ar", "hi" };
            //var locatizationsOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[2])
            //                                                    .AddSupportedCultures(supportedCultures)
            //                                                    .AddSupportedUICultures(supportedCultures);
            //app.UseRequestLocalization(locatizationsOptions);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Products}/{action=Index}/{id?}");
            });
        } 
    }
}
