using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Asset.Contexts;
using API_Asset.MyConnections;
using API_Asset.Repositories;
using API_Asset.Repositories.Data;
using API_Asset.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace API_Asset
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
            services.AddTransient<ConnectionString>(_ => new ConnectionString(Configuration.GetConnectionString("MyConnection")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddEntityFrameworkMySql();
            services.AddDbContext<MyContext>(options =>
            options.UseMySql(Configuration.GetConnectionString("MyConnection")));

            services.AddScoped<BrandRepository>();
            services.AddScoped<SupplierRepository>();
            services.AddScoped<ItemRepository>();
            services.AddScoped<RequestRepository>();
            services.AddScoped<LendRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
