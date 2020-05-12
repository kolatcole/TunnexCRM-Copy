using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRMSystem.Domains;
using CRMSystem.Infrastructure;
using CRMSystem.Presentation.Core.Setup_Files;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Serilog;


namespace CRMSystem
{
    public class Startup
    {
        
        public Startup(IConfiguration configuration)
        {
            
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddCors(c=> {
            //    c.AddPolicy("AllowOrigin", opt => opt.AllowAnyOrigin());
            //});
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version="v1",
                    Title="CRM System API"
                });
            });
            services.AddDbContext<TContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("DefaultTLocal"), b => b.MigrationsAssembly("CRMSystem.Presentation.Core"));
            });

            services.AddScoped<IRepo<User>, UserRepo>();
            services.AddScoped<IRepo<Product>, ProductRepo>();
            services.AddScoped<IRepo<Price>, PriceRepo>();
            services.AddScoped<IRepo<Customer>, CustomerRepo>();
            services.AddScoped<IRepo<Sale>, SaleRepo>();
            services.AddScoped<IRepo<Item>, ItemRepo>();
            services.AddScoped<IRepo<Role>, RoleRepo>();
            services.AddScoped<IRepo<Privilege>, PrivilegeRepo>();
            services.AddScoped<IRepo<Cart>, CartRepo>();
            services.AddScoped<IRepo<Invoice>, InvoiceRepo>();
            services.AddScoped<IRepo<Payment>, PaymentRepo>();
            services.AddScoped<IInvoiceRepo, InvoiceRepo>();





            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ISaleService, SaleService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<ICartService, CartService>();
            services.AddTransient<IInvoiceService, InvoiceService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}

            //app.UseCors(opt =>
            //{
            //    opt.AllowAnyOrigin();
            //});

            app.UseCors(opt =>

                opt.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
            );
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //    app.UseCors(builder =>
            //                builder
            //                .WithOrigins("http://localhost")
            //                .AllowAnyHeader()
            //                .AllowAnyMethod()
            //                .AllowCredentials()
            //                );
            //}
            //else
            //{
            //    app.UseHsts();
            //}

            loggerFactory.AddSerilog(); // <-- enable Serilog Middleware
            var swaggerOpt = new SwaggerOpt();
            Configuration.GetSection(nameof(SwaggerOpt)).Bind(swaggerOpt);
            app.UseSwagger(opt => {
                opt.RouteTemplate = swaggerOpt.JsonRoute;
            });
            app.UseSwaggerUI(opt=> {
                opt.SwaggerEndpoint(swaggerOpt.UIEndPoint, swaggerOpt.Description);
            });


            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
