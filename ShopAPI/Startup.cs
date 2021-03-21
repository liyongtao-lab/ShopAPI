using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
using Microsoft.OpenApi.Models;
using ShopAPI.Models;

namespace ShopAPI
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
        

            services.AddControllers();

            //第二种：直接将上下文对象装载到程序服务中，并配置连接字符串
            services.AddDbContext<StudentContext>(options =>
       options.UseSqlServer(Configuration.GetConnectionString("stuDB")));

            //配置跨域处理
            services.AddCors(options =>
            {
                options.AddPolicy("cors", builder =>
                {
                    builder.WithOrigins("http://localhost:6321", "http://localhost:38876")//允许指定域名访问
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();//指定处理cookie
                });
            });

            // 注册Swagger服务
            services.AddSwaggerGen(c =>
            {
                // 添加文档信息
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "CRM_API",
                    Version = "v1",
                    Description = "ASP.NET CORE WebApi",

                });
                // 使用反射获取xml文件。并构造出文件的路径
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                // 启用xml注释. 该方法第二个参数启用控制器的注释，默认为false.
                c.IncludeXmlComments(xmlPath, true);
            });
            // 添加jwt验证：
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //.AddJwtBearer(options => {
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = true,//是否验证Issuer
            //        ValidateAudience = true,//是否验证Audience
            //        ValidateLifetime = true,//是否验证失效时间
            //        ValidateIssuerSigningKey = true,//是否验证SecurityKey
            //        ValidAudience = Configuration["JwtSetting:Audience"],//Audience
            //        ValidIssuer = Configuration["JwtSetting:Issuer"],//Issuer，这两项和前面签发jwt的设置一致
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSetting:SecurityKey"]))//拿到SecurityKey
            //    };
            //});
            //services.AddScoped<JWTService>();
            //services.AddControllers();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            // 启用Swagger中间件
            app.UseSwagger();

            // 配置SwaggerUI
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CRM_API");

            });
        }
    }
}
