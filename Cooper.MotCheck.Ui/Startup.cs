using Cooper.MotCheck.Services;
using Cooper.MotCheck.Services.Data.Implementation;
using Cooper.MotCheck.Services.Data.Implementation.Contexts;
using Cooper.MotCheck.Services.Implementation;
using Cooper.MotCheck.Services.Implementation.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Cooper.MotCheck.Ui
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment hostEnvironment)
        {
            Configuration = configuration;
            this.hostEnvironment = hostEnvironment;
        }

        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment hostEnvironment;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var mvcBuilder = services.AddControllersWithViews();

#if DEBUG
            if (hostEnvironment.IsDevelopment())
            {
                mvcBuilder.AddRazorRuntimeCompilation();
            }
#endif

            services.AddTransient<IMotCheckService, MockMotCheckService>();
            services.AddSingleton<MotCheckServiceMapper>();
            services.AddTransient<IReminderService, ReminderService>();
            services.AddTransient<RemindersContext>();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
