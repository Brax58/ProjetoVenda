using Application.Service.PedidoService;
using Application.Service.PedidoService.AtualizacaoDoPedido;
using Application.Service.PedidoService.Interface.IAtualizacaoDoPedido;
using Application.Service.PedidoService.Interface.ICrud;
using Application.Service.PedidoService.Interface.IValidarPedidos;
using Application.Service.PedidoService.ValidacaoPedidos;
using Application.Service.ProdutoService;
using Application.Service.ProdutoService.AtualizacaoDoProduto;
using Application.Service.ProdutoService.Interface.IAtualizacaoDoProdutos;
using Application.Service.ProdutoService.Interface.ICrud;
using Application.Service.ProdutoService.ValidacaoProdutos;
using Application.Service.UsuarioService;
using Application.Service.UsuarioService.AtualizacaoDoUsuario;
using Application.Service.UsuarioService.Interface.IAtualizacaoDoUsuarios;
using Application.Service.UsuarioService.Interface.ICrud;
using Application.Service.UsuarioService.ValidacaoUsuarios;
using Infra.Data.Infra;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;

namespace Api
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
            
            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("BancoVenda"));

            services.AddScoped<IProdutoAdicionar,ProdutoAdicionar>();
            services.AddScoped<IProdutoAtualizar,ProdutoAtualizar>();
            services.AddScoped<IAtualizacaoDoProduto,AtualizacaoDoProduto>();
            services.AddScoped<IProdutoObterPorId,ProdutoObterPorId>();
            services.AddScoped<IProdutoObterTodos,ProdutoObterTodos>();
            services.AddScoped<IProdutoRemover,ProdutoRemover>();
            services.AddScoped<ValidarProduto>();

            services.AddScoped<IUsuarioAdicionar, UsuarioAdicionar>();
            services.AddScoped<IUsuarioAtualizar, UsuarioAtualizar>();
            services.AddScoped<IAtualizacaoDoUsuario, AtualizacaoDoUsuario>();
            services.AddScoped<IUsuarioObterPorId, UsuarioObterPorId>();
            services.AddScoped<IUsuarioObterTodos, UsuarioObterTodos>();
            services.AddScoped<IUsuarioRemover, UsuarioRemover>();
            services.AddScoped<ValidarUsuario>();


            services.AddScoped<IPedidoAdicionar, PedidoAdicionar>();
            services.AddScoped<IPedidoAtualizar, PedidoAtualizar>();
            services.AddScoped<IAtualizacaoDoPedido, AtualizacaoDoPedido>();
            services.AddScoped<IPedidoObterPorId, PedidoObterPorId>();
            services.AddScoped<IPedidoObterTodos, PedidoObterTodos>();
            services.AddScoped<IPedidoRemover, PedidoRemover>();
            services.AddScoped<IValidacaoStatus,ValidacaoStatus>();
            services.AddScoped<IValidarPedido,ValidarPedido>();

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(SwaggerConfiguration);

            services.AddControllers();
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

            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Exemplo");
            });
        }

        private void SwaggerConfiguration(SwaggerGenOptions c)
        {
            c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "Projeto Teste",
                Version = "v1",
                Description = "Projeto Teste",
                Contact = new OpenApiContact
                {
                    Name = "Framework System",
                    Url = new Uri("https://frwk.com.br")
                }
            });
        }
    }
}
