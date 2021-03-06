using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using ParkingGarage.BusinessLogic;
using ParkingGarage.BusinessLogic.ParkingLot;
using ParkingGarage.BusinessLogic.Tickets;
using ParkingGarage.Data;
using ParkingGarage.Data.ParkingLot;
using ParkingGarage.Data.SharedRepo;
using ParkingGarage.Data.Vehicle;
using ParkingGarage.Models.ParkingLot;

namespace ParkingGarage
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
            services.AddDbContext<MainContext>(opt =>
                opt.UseMySql(Configuration.GetConnectionString("Connection")));

            // CORS
            services.AddCors(c => c.AddDefaultPolicy( builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

            services.AddControllers().AddNewtonsoftJson(x => 
                x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            
            
            services.AddScoped<VehiclesLogic, VehiclesLogic>();
            services.AddScoped<IVehicleRepo, SqlVehiclesRepo>();
            
            services.AddScoped<TicketsLogic, TicketsLogic>();

            services.AddScoped<ParkingLotsLogic, ParkingLotsLogic>();
            services.AddScoped<IParkingLotRepo, SqlParkingLotsRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();
            
            // Uses the `wwwroot` folder as static files for production.
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            
        }
    }
}