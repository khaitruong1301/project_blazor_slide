using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using blazor_soan_slide.Data;
using System.Net.Http;
using System.IO;

namespace blazor_soan_slide
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
            // //Thêm http client vào service
            // services.AddHttpClient();


            // Đăng ký CountService dưới dạng Scoped
            services.AddScoped<CountService>();
            services.AddScoped<CartService>();
            services.AddScoped<CryptoService>();
            services.AddScoped<ProductService>(); // Đăng ký ProductService
            services.AddScoped<ProductStoreService>(); // Đăng ký ProductStoreService

            // Thêm HttpClient với cấu hình cơ bản (với các tham số mặc định)
            services.AddHttpClient("apiStore", client =>
            {
                client.BaseAddress = new Uri("https://apistore.cybersoft.edu.vn/");
                client.Timeout = TimeSpan.FromSeconds(30);
                client.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            });
        

            services.AddHttpClient("apiStore", client =>
            {
                client.BaseAddress = new Uri("https://apistore.cybersoft.edu.vn/");
                client.Timeout = TimeSpan.FromSeconds(30);
                client.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            });



            // services.AddHttpClient("apiOther", client => {
            //      client.BaseAddress = new Uri("https://svcy.myclass.vn/");
            //     client.Timeout = TimeSpan.FromSeconds(30);
            //     client.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            // });



            // Thêm HttpClient cho các yêu cầu nội bộ (truy cập wwwroot)
            // services.AddScoped(sp => new HttpClient
            // {
            //     BaseAddress = new Uri("https://localhost:5001/") // Thay đổi cổng tùy vào cấu hình của bạn
            // });

            
            //Cấu hình signal R
            services.AddSignalR();




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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}

