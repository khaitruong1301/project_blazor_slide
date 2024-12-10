using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using blazor_soan_slide.Data;
// using blazor_soan_slide.Store.Hub;

namespace blazor_soan_slide
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Đăng ký các dịch vụ cần thiết
        public void ConfigureServices(IServiceCollection services)
        {
            // Dịch vụ Razor Pages và Blazor
            services.AddRazorPages();
            services.AddServerSideBlazor();

            // Dịch vụ khác
            services.AddSingleton<WeatherForecastService>();
            services.AddScoped<CountService>();
            services.AddScoped<CartService>();
            services.AddScoped<CryptoService>();
            services.AddScoped<ProductService>();
            services.AddScoped<ProductStoreService>();

            // HttpClient cấu hình cơ bản
            services.AddHttpClient("apiStore", client =>
            {
                client.BaseAddress = new Uri("https://apistore.cybersoft.edu.vn/");
                client.Timeout = TimeSpan.FromSeconds(30);
                client.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            });

            // Cấu hình SignalR
            // services.AddSignalR(options =>
            // {
            //     options.MaximumReceiveMessageSize = 102400000; // Cho phép kích thước tin nhắn lớn
            //     options.KeepAliveInterval = TimeSpan.FromSeconds(15); // Server gửi tín hiệu "keep-alive" mỗi 15 giây
            //     options.ClientTimeoutInterval = TimeSpan.FromSeconds(30); // Thời gian chờ của client trước khi báo timeout
            // });

        }

        // Cấu hình HTTP request pipeline
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
                endpoints.MapBlazorHub(options =>
                {
                    options.ApplicationMaxBufferSize = 10 * 1024 * 1024;
                    options.TransportMaxBufferSize = 10 * 1024 * 1024;
                });
                endpoints.MapFallbackToPage("/_Host");
            });

        }
    }
}
