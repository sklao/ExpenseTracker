using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ExpenseTracker.Models;
using ExpenseTracker.Services;
using ExpenseTracker.Repository;
using Swashbuckle.AspNetCore.Swagger;

namespace ExpenseTracker
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
            //var sqlConnection = Configuration.GetConnectionString("DbConnectionString");
            //services.AddDbContext<ExpenseTrackerContext>(opt =>
            //    opt.UseSqlServer(sqlConnection));

            //services.AddEntityFrameworkInMemoryDatabase().
            //    AddDbContext<ExpenseTrackerContext>();

            services.AddDbContext<ExpenseTrackerContext>(opt =>
                opt.UseInMemoryDatabase("ExpenseTracker"),ServiceLifetime.Scoped);

            services.AddTransient<IExpenseItemRepository, ExpenseItemRepository>();
            services.AddTransient<IExpenseItemService, ExpenseItemService>();



            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Expense Tracker API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for 
                // production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.ApplicationServices.GetService<System.IDisposable>();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Expense Tracker V1");
            });

            app.UseMvc();
        }
    }
}
