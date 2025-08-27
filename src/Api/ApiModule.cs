using Microsoft.OpenApi.Models;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;
using Volo.Abp.Timing;

namespace Washyn.Kfc
{
    [DependsOn(typeof(ApplicationModule))]
    [DependsOn(typeof(InfrastructureModule))]
    [DependsOn(typeof(AbpAspNetCoreMvcModule))]
    [DependsOn(typeof(AbpAspNetCoreSerilogModule))]
    [DependsOn(typeof(AbpSwashbuckleModule))]
    [DependsOn(typeof(AbpAutofacModule))]
    public class ApiModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            var services = context.Services;
            var env = context.Services.GetHostingEnvironment();

            Configure<AbpClockOptions>(options => { options.Kind = DateTimeKind.Utc; });
            ConfigureCors(context, configuration);
            ConfigureSwaggerServices(context, configuration);
        }

        private static void ConfigureSwaggerServices(ServiceConfigurationContext context, IConfiguration configuration)
        {
            context.Services
                .AddAbpSwaggerGen()
                .ConfigureSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "App API", Version = "v1" });
                    options.DocInclusionPredicate((docName, description) => true);
                    options.CustomSchemaIds(type => type.FullName);
                });
        }

        private void ConfigureCors(ServiceConfigurationContext context, IConfiguration configuration)
        {
            // context.Services.AddCors(options =>
            // {
            //     options.AddDefaultPolicy(builder =>
            //     {
            //         builder
            //             .WithOrigins(
            //                 configuration["App:CorsOrigins"]
            //                     .Split(",", StringSplitOptions.RemoveEmptyEntries)
            //                     .Select(o => o.RemovePostFix("/"))
            //                     .ToArray()
            //             )
            //             .WithAbpExposedHeaders()
            //             .SetIsOriginAllowedToAllowWildcardSubdomains()
            //             .AllowAnyHeader()
            //             .AllowAnyMethod()
            //             .AllowCredentials();
            //     });
            // });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseStaticFiles();
            app.UseRouting();
            // app.UseCors();
            app.UseUnitOfWork();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseAbpSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "App API"); });
            app.UseAbpSerilogEnrichers();
            app.UseConfiguredEndpoints();
        }
    }
}