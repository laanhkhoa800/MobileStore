
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using Microsoft.AspNetCore.Authentication.Cookies;
using BlogCoreAPI.Dependence.Reponsitorys;
using BlogCoreAPI.Dependence.Services;
using BlogCoreAPI.Dependence.Reponsitorys.ProductRepository;
using BlogCoreAPI.Dependence.Services.Interface;
using BlogCoreAPI.Model.MailKit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using BlogCoreAPI.Dependence.Reponsitorys.OrderRepository;
using BlogCoreAPI.Dependence.Reponsitorys.SubProductRepository;
using BlogCoreAPI.Dependence.Reponsitorys.UserRepository;
using BlogCoreAPI.Dependence.Reponsitorys.DetailOrderRepository;

namespace BlogCoreAPI
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
         
            /*services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(connection));*/
          
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Knowledge space API", Version = "v1" });
            });
           
            services.AddDbContext<ApContext>(options =>
                                                  options.UseSqlServer(
                                                      Configuration.GetConnectionString("DefaultConnection"),
                                                      b => b.MigrationsAssembly(typeof(ApContext).Assembly.FullName)));

            var key = "test";
            //identity
          /*  services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie("Cookies");*/
            services.AddAuthentication(a =>
            {
                a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
               {
                   x.RequireHttpsMetadata = false;
                   x.SaveToken = true;
                   x.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                       ValidateIssuer = false,
                       ValidateAudience = false
                   };
               }
            );
             
            services.AddControllersWithViews();
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ISubProductRepository, SubProductRepository>();
            services.AddTransient<ISubProductService, SubProductService>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ISendMailService, SendMailService>();
            services.AddTransient<IDetailOrderRepository, DetailOrderRepository>();
            services.AddTransient<IDetailOrderService, DetailOrderService>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderService, OrderService>();
           
            services.AddControllers();
            services.AddControllers().AddNewtonsoftJson();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
            });
            services.AddHttpClient();

          /*  services.AddCors(o => o.AddPolicy("MyPolicy",builder =>
            {
                builder.WithOrigins("*")
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));*/
            services.AddCors(o=> {
                o.AddDefaultPolicy(
                 builder => builder.WithOrigins("http://localhost:4200"));
                o.AddPolicy("mypolicy", builder =>
                   {
                       builder.WithOrigins("*");
                       builder.AllowAnyMethod();
                       builder.AllowAnyHeader();
                   }
                   );

            });
            services.AddOptions();                                         // Kích hoạt Options
            var mailsettings = Configuration.GetSection("MailSettings");  // đọc config
            services.Configure<MailSettings>(mailsettings);                // đăng ký để Inject


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
 
            //Middble để bắt lỗi 
            app.Use(async (context, next) =>
            {
                try
                {
                    await next();
                }
                catch(Exception)
                {
                    throw;
                }
            });
            app.UseCookiePolicy();
            app.UseHttpsRedirection();
            app.UseSession();
            app.UseAuthentication();
            app.UseRouting();
            app.UseHttpsRedirection();
            //app.UseCors();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.Use(async (context, next) =>
            {
                await next.Invoke();
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //Set swagger test API
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Knowledge space API v1");
            });



        }
    }
}
