using Pars.ViewModels.Identity.Settings;
using DNTCaptcha.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pars.IocConfig;
using DNTCommon.Web.Core;
using Microsoft.AspNetCore.StaticFiles.Infrastructure;
using Pars.Common.WebToolkit;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Pars
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<SiteSettings>(options => Configuration.Bind(options));
            services.Configure<ContentSecurityPolicyConfig>(options => Configuration.GetSection("ContentSecurityPolicyConfig").Bind(options));

            // Adds all of the ASP.NET Core Identity related services and configurations at once.
            services.AddCustomIdentityServices();

            services.AddMvc(options => options.UseYeKeModelBinder());

            services.AddDNTCommonWeb();
            services.AddDNTCaptcha(x =>
            {
                x.EncryptionKey = "/B?E(H+M";
            });
            services.AddCloudscribePagination();

            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsDevelopment())
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseExceptionHandler("/error/index/500");
            app.UseStatusCodePagesWithReExecute("/error/index/{0}");

            app.UseContentSecurityPolicy();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.DocExpansion(DocExpansion.List);
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapControllerRoute(
                    name: "areaRoute",
                    pattern: "{area:exists}/{controller=Account}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });
        }
    }
}