using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FAP.Client;
using FAP.Client.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SHPC.KeYanXiangMuGuanLi.Engine.DTOs;
using SHPC.KeYanXiangMuGuanLi.Engine.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace SHPC.KeYanXiangMuGuanLi.Web
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        ///  This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<KeYanGuanLiContext>(options => options.UseSqlServer(Configuration.GetConnectionString("KeYanGuanLiContext")));
            services.AddSwaggerGen(c =>
            {
                //c.SwaggerDoc("v1", new Info
                //{
                //    Version = "v1",
                //    Description = "webapi文档",
                //    TermsOfService = "None",
                //});
                //var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;
                //var xmlPath = Path.Combine(basePath, "webApi.xml");//这个就是刚刚配置的xml文件名
                //c.IncludeXmlComments(xmlPath);//默认的第二个参数是false，这个是controller的注释，记得修改
            });
            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile(provider.GetService<KeYanGuanLiContext>()));
            }).CreateMapper());
            services.AddMemoryCache();
            services.AddSession();
            services.AddOptions();

            services.AddMvc()
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizeFolder("/");
                });
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });

            // by zzq
            services.Configure<FormOptions>(options =>
            {
                options.ValueCountLimit = 10000; // 200 items max
                options.ValueLengthLimit = 1024 * 1024 * 10; // 100MB max len form data
            });


            FAP.Client.IdentityProviderService.ConfigureSamlServices(services, Configuration);

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddFAPContext();
            services.AddFAPOrganizationService();
            services.AddFAPPrivilegeService();
            services.AddFAPMessageService();
            services.AddFAPLoggerService();

        }

        /// <summary>
        ///  This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UsePathBase("/SHPC.KeYanXiangMuGuanLi.Web");
            app.UseForwardedHeaders();

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            //app.UseSwagger(c => {
            //    c.PreSerializeFilters.Add((swaggerDoc, httpReq) => {
            //        IDictionary<string, PathItem> paths = new Dictionary<string, PathItem>();
            //        foreach (var path in swaggerDoc.Paths)
            //        {
            //            if (path.Key.Contains("api/"))
            //                paths.Add(path.Key, path.Value);
            //        }
            //        swaggerDoc.Paths = paths;
            //    });
               
            //});
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "webapi");

            //});
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
