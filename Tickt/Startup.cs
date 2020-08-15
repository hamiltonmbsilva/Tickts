using AutoMapper;
using Domain.Mapping;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Repository.Context;
using Repository.EntyRepository;
using Service;

namespace Tickt
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
            services.AddCors();
            services.AddControllers();

            string stringConexao = "Server=localhost;Port=3306;DataBase=db_tickts;Uid=root;Pwd=root";
            services.AddDbContext<BaseContext>(options =>
            options.UseMySQL(stringConexao));

            //services.AddSingleton<BaseContext>();

            services.AddControllersWithViews();

            #region Repository

            // Scoped - cria uma instancia por requisi��o dentro do escopo

            services.AddScoped<AndamentoRepository>();
            services.AddScoped<SolicitacaoRepository>();

            #endregion

            #region Service

            services.AddScoped<AndamentoService>();
            services.AddScoped<SolicitacaoService>();

            #endregion

            #region Configura��es de retorno Json

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.UseCamelCasing(true);
            });

            #endregion

            #region Automapper

            // Configurando AutoMapper
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AndamentoMapping());
                mc.AddProfile(new SolicitacaoMapping());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            #endregion
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
        }
    }
}
