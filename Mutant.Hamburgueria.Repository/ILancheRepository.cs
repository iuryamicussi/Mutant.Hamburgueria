using Mutant.Hamburgueria.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mutant.Hamburgueria.Repository
{
    public interface ILancheRepository
    {
        Task<IEnumerable<Lanche>> SelecionarTodos();
        Task FinalizarVenda(Lanche lanche, string comprador);
    }
}
