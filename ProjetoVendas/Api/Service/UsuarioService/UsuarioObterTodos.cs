using Application.Service.UsuarioService.Interface.ICrud;
using Domain.Entities;
using Infra.Data.Infra;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Service.UsuarioService
{
    public class UsuarioObterTodos : IUsuarioObterTodos
    {
        public readonly AppDbContext _appDbContext;
        public UsuarioObterTodos(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Usuario>> ObterTodos()
        {
            try
            {
                return await _appDbContext.Usuarios.ToListAsync();
            }
            catch (Exception exception)
            {
                throw new Exception("Ops! Algo deu errado no momento de buscar o usuário: " + exception.Message);
            }
        }
    }
}
