﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using BuildingContractor.Application;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Application.Interfaces;
using BuildingContractor.Persistence;
using BuildingContractor.WebAPI.Middleware;
using BuildingContractor.WebAPI.Endpoints;

namespace BuildingContractor.WebAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(INotesDbContext).Assembly));
            });

            services.AddApplication();
            services.AddPersistence(Configuration);
            services.AddControllers();
            services.AddDistributedMemoryCache();
            services.AddMemoryCache();
            services.AddSession();
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseSwaggerUI();
            app.UseSwagger();
            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseSession();
            app.Map("/Info", Endpoints.Endpoint.Info);
            app.Map("/contractorMaterials", Endpoints.Endpoint.ContractorMaterials);
            app.Map("/searchFirst", Endpoints.Endpoint.FirstSearch);
            app.Map("/searchSecond", Endpoints.Endpoint.SecondSearch);

            app.UseMiddleware<DefaultMidlleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
