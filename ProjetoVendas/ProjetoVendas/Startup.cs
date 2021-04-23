using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ProjetoVendas.Infra;
using ProjetoVendas.Service;
using ProjetoVendas.Service.AtualizacaoDasEntidades;
using ProjetoVendas.Service.CrudEntidades.CrudProduto.ProdutoAdicionar;
using ProjetoVendas.Service.CrudEntidades.CrudProduto.ProdutoAtualizar;
using ProjetoVendas.Service.CrudEntidades.CrudProduto.ProdutoObterPorId;
using ProjetoVendas.Service.CrudEntidades.CrudProduto.ProdutoObterTodos;
using ProjetoVendas.Service.CrudEntidades.CrudProduto.ProdutoRemover;
using ProjetoVendas.Service.CrudEntidades.CrudUsuario.UsuarioAdicionar;
using ProjetoVendas.Service.CrudEntidades.CrudUsuario.UsuarioAtualizar;
using ProjetoVendas.Service.CrudEntidades.CrudUsuario.UsuarioObterPorId;
using ProjetoVendas.Service.CrudEntidades.CrudUsuario.UsuarioObterTodos;
using ProjetoVendas.Service.CrudEntidades.CrudUsuario.UsuarioRemover;
using ProjetoVendas.Service.Interfaces;
using ProjetoVendas.Service.Interfaces.Atualizar;
using ProjetoVendas.Service.Interfaces.Crud.Produtos;
using ProjetoVendas.Service.Interfaces.Crud.Produtos.ProdutoObterTodos;
using ProjetoVendas.Service.Interfaces.Crud.Produtos.ProdutoRemover;
using ProjetoVendas.Service.Interfaces.Crud.Usuarios.UsuarioAdicionar;
using ProjetoVendas.Service.Interfaces.Crud.Usuarios.UsuarioAtualizar;
using ProjetoVendas.Service.Interfaces.Crud.Usuarios.UsuarioObterPorId;
using ProjetoVendas.Service.Interfaces.Crud.Usuarios.UsuarioObterTodos;
using ProjetoVendas.Service.Interfaces.Crud.Usuarios.UsuarioRemover;
using ProjetoVendas.Service.Interfaces.Validar;
using ProjetoVendas.Service.Validacao;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;

namespace ProjetoVendas
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
            services.AddScoped<IValidarProduto,ValidarProduto>();
            services.AddScoped<IProdutoAtualizar,ProdutoAtualizar>();
            services.AddScoped<IAtualizacaoDoProduto,AtualizacaoDoProduto>();
            services.AddScoped<IProdutoObterPorId,ProdutoObterPorId>();
            services.AddScoped<IProdutoObterTodos,ProdutoObterTodos>();
            services.AddScoped<IProdutoRemover,ProdutoRemover>();

            services.AddScoped<IUsuarioAdicionar, UsuarioAdicionar>();
            services.AddScoped<IValidarUsuario, ValidarUsuario>();
            services.AddScoped<IUsuarioAtualizar, UsuarioAtualizar>();
            services.AddScoped<IAtualizacaoDoUsuario, AtualizacaoDoUsuario>();
            services.AddScoped<IUsuarioObterPorId, UsuarioObterPorId>();
            services.AddScoped<IUsuarioObterTodos, UsuarioObterTodos>();
            services.AddScoped<IUsuarioRemover, UsuarioRemover>();

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
