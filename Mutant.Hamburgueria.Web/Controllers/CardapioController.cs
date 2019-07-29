using Microsoft.AspNetCore.Mvc;
using Mutant.Hamburgueria.Model;
using Mutant.Hamburgueria.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mutant.Hamburgueria.Web.Controllers
{
    [Route("api/[controller]")]
    public class CardapioController : Controller
    {
        private ILancheRepository _lancheRepository;
        private IIngredienteRepository _ingredienteRepository;

        public CardapioController(ILancheRepository lancheRepository, IIngredienteRepository ingredienteRepository)
        {
            _lancheRepository = lancheRepository;
            _ingredienteRepository = ingredienteRepository;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Ingrediente>> Ingredientes()
        {
            return await _ingredienteRepository.SelecionarTodos();
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Lanche>> Lanches()
        {
            return await _lancheRepository.SelecionarTodos();
        }

        [Produces("application/json")]
        [HttpPost("[action]")]
        public async Task<ActionResult> FinalizarVenda([FromBody]FinalizarVendaRequest finalizarVendaRequest)
        {
            Lanche lanche = ConverterFinalizarRequestEmLanche(finalizarVendaRequest);

            await _lancheRepository.FinalizarVenda(lanche, "");
            return Accepted();
        }

        private Lanche ConverterFinalizarRequestEmLanche(FinalizarVendaRequest finalizarVendaRequest)
        {
            var ingredientes = _ingredienteRepository.SelecionarTodos().GetAwaiter().GetResult();

            Lanche lanche = new Lanche() { Codigo = finalizarVendaRequest.CodigoLanche };
            List<Ingrediente> ingredientesDoLanche = new List<Ingrediente>();

            foreach (int codigoIngrediente in finalizarVendaRequest.CodigoIngredientes)
            {
                ingredientesDoLanche.Add(ingredientes.FirstOrDefault(f => f.Codigo == codigoIngrediente));
            }

            lanche.Ingredientes = ingredientesDoLanche;

            return lanche;

        }
    }

    public class FinalizarVendaRequest
    {
        public int CodigoLanche { get; set; }
        public int[] CodigoIngredientes { get; set; }
    }
}