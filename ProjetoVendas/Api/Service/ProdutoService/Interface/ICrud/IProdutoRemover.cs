using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Service.ProdutoService.Interface.ICrud
{
    public interface IProdutoRemover
    {
        Task Remover(Guid id);
    }
}
