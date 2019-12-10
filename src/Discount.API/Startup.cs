using Discount.API.Infrastructure.Context;
using Discount.API.Infrastructure.Repositories;
using Discount.API.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Discount.API
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc();
            services.AddMemoryCache();

            services.AddTransient<DiscountContext>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                GrpcEndpointRouteBuilderExtensions.MapGrpcService<DiscountGrpcService>(endpoints);
            });
        }
    }
}
