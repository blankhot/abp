using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore;
using Abp.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Platform.Common;
using Platform.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;

namespace Platform.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info()
                {
                    Title = "Api接口",
                    Description = "Api接口",
                    Version = "1.0.0",
                    TermsOfService = "CharmCheena"
                }); 
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

            //跨域配置
            //services.AddCors(options => options.AddPolicy("AllowHeaders", builder => builder.AllowAnyOrigin().AllowAnyHeader()
            //    .WithMethods(new[] { HttpMethods.Get, HttpMethods.Post }))
            //);

            services.AddCors(options =>
            {
                // BEGIN01
                options.AddPolicy("AllowSpecificOrigins",
                builder =>
                {
                    //builder.WithOrigins("http://example.com", "http://www.contoso.com");
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowCredentials().WithMethods(new[] { HttpMethods.Get, HttpMethods.Post });
                });
                // END01

                // BEGIN02
                //options.AddPolicy("AllowAllOrigins",
                //    builder =>
                //    {
                //        builder.WithOrigins("http://ftwx.fangte.com", "https://market.fangte.com").AllowAnyOrigin().AllowAnyHeader().AllowAnyOrigin().AllowCredentials().WithMethods(new[] { HttpMethods.Get, HttpMethods.Post });
                //    });
                // END02

                //// BEGIN03
                //options.AddPolicy("AllowSpecificMethods",
                //    builder =>
                //    {
                //        builder.WithOrigins("http://example.com")
                //               .WithMethods("GET", "POST", "HEAD");
                //    });
                //// END03

                //// BEGIN04
                //options.AddPolicy("AllowAllMethods",
                //    builder =>
                //    {
                //        builder.WithOrigins("http://example.com")
                //               .AllowAnyMethod();
                //    });
                //// END04

                // BEGIN05
                //options.AddPolicy("AllowHeaders",
                //    builder =>
                //    {
                //        builder.WithOrigins("http://example.com")
                //               .WithHeaders("accept", "content-type", "origin", "x-custom-header");
                //    });
                // END05

                //// BEGIN06
                //options.AddPolicy("AllowAllHeaders",
                //    builder =>
                //    {
                //        builder.WithOrigins("http://example.com")
                //               .AllowAnyHeader();
                //    });
                //// END06

                //// BEGIN07
                //options.AddPolicy("ExposeResponseHeaders",
                //    builder =>
                //    {
                //        builder.WithOrigins("http://example.com")
                //               .WithExposedHeaders("x-custom-header");
                //    });
                //// END07

                //// BEGIN08
                //options.AddPolicy("AllowCredentials",
                //    builder =>
                //    {
                //        builder.WithOrigins("http://example.com")
                //               .AllowCredentials();
                //    });
                //// END08

                //// BEGIN09
                //options.AddPolicy("SetPreflightExpiration",
                //    builder =>
                //    {
                //        builder.WithOrigins("http://example.com")
                //               .SetPreflightMaxAge(TimeSpan.FromSeconds(2520));
                //    });
                //// END09
            });



            //注册IHttpContextAccessor
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Configure Abp and Dependency Injection
            return services.AddAbp<PlatformWebModule>(options =>
            {
                ////Configure Log4Net logging
                //options.IocManager.IocContainer.AddFacility<LoggingFacility>(
                //    f => f.UseAbpLog4Net().WithConfig("log4net.config")
                //);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAbp();
            //app.UseCors("AllowHeaders");
            app.UseCors("AllowSpecificOrigins");
            //app.UseCors("AllowAllOrigins");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }

            app.UseMvc(builder => builder.MapRoute(
            name: "default",
            template: "{controller=Home}/{action=Index}/{id?}"));
            //else
            //{
            //    app.UseExceptionHandler("/Error");
            //}

            //app.UseMvc();

            //注册HttpContext内容
            app.UseStaticHttpContext();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "FangTeMarket Api");
            });
        }
        private IReadOnlyList<string> GetXmls()
        {
            var baseDir = AppContext.BaseDirectory;

            return Directory.GetFiles(baseDir, "Platform.*.xml").ToImmutableList();
        }
    }
}
