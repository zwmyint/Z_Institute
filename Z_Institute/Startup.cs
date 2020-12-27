using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Z_Institute.DAL;
using Microsoft.AspNetCore.Internal;
using Microsoft.AspNetCore.Mvc;
using Z_Institute.Services.IRepository;
using Z_Institute.Services.Repository;
using ReflectionIT.Mvc.Paging;

namespace Z_Institute
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Register the Z_Context // using Microsoft.EntityFrameworkCore;
            services.AddDbContext<ZDb_Context>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IEnrollmentRepository, EnrollmentRepository>();




            // added
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // aded for Paging >> Install-Package ReflectionIT.Mvc.Paging
            services.AddPaging(options => {
                options.ViewName = "Bootstrap4";
                options.PageParameterName = "pageindex";
            });

            //
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //added
            app.UseDefaultFiles();
            app.UseStaticFiles();


            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            //for Seed Data
            DbInitializer.Seed(app);
        }
    }
}
