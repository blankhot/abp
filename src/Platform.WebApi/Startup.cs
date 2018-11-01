using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Abp.AspNetCore;
using Abp.Castle.Logging.Log4Net;
using Abp.EntityFrameworkCore;
using Castle.Facilities.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Platform.Common;
using Platform.Common.Helper;
using Platform.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;

namespace Platform.WebApi
{
    public class Startup
    {
        private GlobalSettings _settings;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _settings = AppSettingConfigHelper.GetAppSettings<GlobalSettings>();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info()
                {
                    Title = "Api",
                    Description = "Api",
                    Version = "1.0.0"
                });
                if (!_settings.IsRelease)
                    options.SwaggerDoc(PlatformConsts.ManageName, 
                        new Info() { Title = "Mange Api", Description = "方特投资有限公司版权所有", Version = PlatformConsts.ManageName });

                //控制器接口的描述
                options.DocumentFilter<HiddenApiFilter>();
                var xmls = GetXmls();
                foreach (var xml in xmls)
                {
                    options.IncludeXmlComments(xml);
                }
            });

            //Configure DbContext
            services.AddAbpDbContext<PlatformDbContext>(options =>
            {
                DbContextOptionsConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
            });

            //services.AddMvc();

            services.AddMvc(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });

            //设置全局JSON时间格式
            services.PostConfigure<MvcJsonOptions>(options =>
            {
                options.SerializerSettings.ContractResolver = new DateFormatContractResolver();
            });
            services.Configure<GlobalSettings>(Configuration.GetSection("GlobalSettings"));
            
            //跨域
            services.AddCors(options =>
            {
                // BEGIN01
                options.AddPolicy("AllowSpecificOrigins",
                builder =>
                {
                    //builder.WithOrigins("http://example.com", "http://www.contoso.com");
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowCredentials().WithMethods(new[] { HttpMethods.Get, HttpMethods.Post });
                });
            });
            
            //注册IHttpContextAccessor
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Configure Abp and Dependency Injection
            return services.AddAbp<PlatformWebApiModule>(options =>
            {
                //Configure Log4Net logging
                options.IocManager.IocContainer.AddFacility<LoggingFacility>(
                    f => f.UseAbpLog4Net().WithConfig("log4net.config")
                );
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAbp();
            app.UseCors("AllowSpecificOrigins");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }

            app.UseMvc(builder => builder.MapRoute(
            name: "default",
            template: "{controller=Home}/{action=Index}/{id?}"));

            //注册HttpContext内容
            app.UseStaticHttpContext();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                if(!_settings.IsRelease)
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Platform Api");
            });
            app.UseSwaggerUI(options =>
            {
                //根据配置文件显示
                //自定义显示页面，显示其他分组需加url：?urls.primaryName=Manage
                var currentAssembly = GetType().GetTypeInfo().Assembly;
                options.IndexStream = () => currentAssembly.GetManifestResourceStream($"{currentAssembly.GetName().Name}.Swagger.index.html");//FangteHotels.WebApi.Swagger.index.html

                options.SwaggerEndpoint("/swagger/v1/swagger.json", "FangteHotels Api");
                if (!_settings.IsRelease)
                    options.SwaggerEndpoint($"/swagger/{PlatformConsts.ManageName}/swagger.json", PlatformConsts.ManageName);
            });


        }
        private IReadOnlyList<string> GetXmls()
        {
            var baseDir = AppContext.BaseDirectory;

            return Directory.GetFiles(baseDir, "Platform.*.xml").ToImmutableList();
        }
    }
}
