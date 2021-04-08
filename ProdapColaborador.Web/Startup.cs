using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProdapColaborador.Business.Interfaces.Repositorio;
using ProdapColaborador.Business.Interfaces.Servicos;
using ProdapColaborador.Data.Context;
using ProdapColaborador.Data.Repositorio;
using ProdapColaborador.Service.Servicos;

namespace ProdapColaborador.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            WebHostEnvironment = webHostEnvironment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment WebHostEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            IMvcBuilder builder = services.AddRazorPages();

            if (WebHostEnvironment.IsDevelopment())
            {
                builder.AddRazorRuntimeCompilation();
                services.AddDataProtection();
                services.AddControllersWithViews();
            }

            services.AddScoped<IUsuarioServico, UsuarioServico>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

            services.AddDbContext<ProdapColaboradorDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnectionSql")));
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Cadastro}/{action=Index}/{id?}");
            });
        }
    }
}
