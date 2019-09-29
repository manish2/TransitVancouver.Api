using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TransitVancouver.Services.ApiClients;
using TransitVancouver.Services.Interfaces;
using TransitVancouver.Services.Mappers;
using TransitVancouver.Services.Providers;

namespace TransitVancouver.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            var translinkSection = Configuration.GetSection("Translink");
            var translinkBaseApiAddress = translinkSection.GetValue<string>("ApiUrl");
            var translinkApiKey = translinkSection.GetValue<string>("ApiKey");
            services.AddSingleton<ITranslinkApiClient, TranslinkApiClient>(service => {
                return new TranslinkApiClient(translinkBaseApiAddress, translinkApiKey);
            });
            services.AddTransient<IFeedEntityToDomainObjectMapper, FeedEntityToDomainObjectMapper>();
            services.AddTransient<IScheduleProvider, ScheduleProvider>();
            services.AddTransient<IVehiclePositionProvider, VehiclePositionProvider>();
            services.AddTransient<IServiceAlertsProvider, ServiceAlertsProvider>();
            services.AddMvcCore().AddJsonFormatters(); 
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
