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

            //�ڶ��֣�ֱ�ӽ������Ķ���װ�ص���������У������������ַ���
            services.AddDbContext<StudentContext>(options =>
       options.UseSqlServer(Configuration.GetConnectionString("stuDB")));

            //���ÿ�����
            services.AddCors(options =>
            {
                options.AddPolicy("cors", builder =>
                {
                    builder.WithOrigins("http://localhost:6321", "http://localhost:38876")//����ָ����������
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();//ָ������cookie
                });
            });

            // ע��Swagger����
            services.AddSwaggerGen(c =>
            {
                // ����ĵ���Ϣ
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "CRM_API",
                    Version = "v1",
                    Description = "ASP.NET CORE WebApi",

                });
                // ʹ�÷����ȡxml�ļ�����������ļ���·��
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                // ����xmlע��. �÷����ڶ����������ÿ�������ע�ͣ�Ĭ��Ϊfalse.
                c.IncludeXmlComments(xmlPath, true);
            });
            // ���jwt��֤��
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //.AddJwtBearer(options => {
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = true,//�Ƿ���֤Issuer
            //        ValidateAudience = true,//�Ƿ���֤Audience
            //        ValidateLifetime = true,//�Ƿ���֤ʧЧʱ��
            //        ValidateIssuerSigningKey = true,//�Ƿ���֤SecurityKey
            //        ValidAudience = Configuration["JwtSetting:Audience"],//Audience
            //        ValidIssuer = Configuration["JwtSetting:Issuer"],//Issuer���������ǰ��ǩ��jwt������һ��
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSetting:SecurityKey"]))//�õ�SecurityKey
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
            // ����Swagger�м��
            app.UseSwagger();

            // ����SwaggerUI
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CRM_API");

            });
        }
    }
}
