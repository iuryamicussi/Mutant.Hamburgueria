using Mutant.Hamburgueria.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mutant.Hamburgueria.Repository
{
    public interface IIngredienteRepository
    {
        Task<IEnumerable<Ingrediente>> SelecionarTodos();
    }
}
