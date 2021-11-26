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
using ParkingGarage.BusinessLogic;
using ParkingGarage.BusinessLogic.ParkingLot;
using ParkingGarage.Data;
using ParkingGarage.Data.ParkingLot;
using ParkingGarage.Data.Vehicle;

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
            services.AddDbContext<VehicleContext>(opt =>
                opt.UseMySql(Configuration.GetConnectionString("Connection")));
            
            services.AddDbContext<ParkingLotContext>(opt =>
                            opt.UseMySql(Configuration.GetConnectionString("Connection")));

            services.AddControllers();

            services.AddScoped<VehicleLogic, VehicleLogic>();
            services.AddScoped<IVehicleRepo, SqlVehiclesRepo>();
            
            services.AddScoped<ParkingLotLogic, ParkingLotLogic>();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}