using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using Mutant.Hamburgueria.Model;
using Mutant.Hamburgueria.Model.Promocoes;

namespace Mutant.Hamburgueria.Repository
{
    public class LancheRepository : RepositoryBase, ILancheRepository
    {
        public LancheRepository(IConfiguration configuration) : base(configuration) { }

        public Task FinalizarVenda(Lanche lanche, string comprador)
        {
            return Task.Factory.StartNew(() =>
            {
                using (IDbConnection conn = Connection)
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@CodigoLanche", lanche.Codigo);
                    parametros.Add("@NomeCliente", comprador);
                    parametros.Add("@ValorCompraBruto", new Calculadora(lanche).ValorLancheBruto());
                    parametros.Add("@ValorCompraLiquido", new Calculadora(lanche).ValorLancheLiquido());
                    parametros.Add("@Ingredientes", string.Join(",", lanche.Ingredientes.Select(s => s.Codigo)));

                    conn.Execute("dbo.PRC_FinalizarVenda", parametros,
                        commandType: CommandType.StoredProcedure);
                }
            });
        }

        public async Task<IEnumerable<Lanche>> SelecionarTodos()
        {
            using (IDbConnection conn = Connection)
            {
                conn.Open();
                var result = await conn.QueryAsync("dbo.PRC_ListaDeLanches", commandType: CommandType.StoredProcedure);

                return await ProcessarRetornoProcedure(result);
            }
        }

        private Task<HashSet<Lanche>> ProcessarRetornoProcedure(IEnumerable<dynamic> retornoProc)
        {
            var lanches = new HashSet<Lanche>();

            return Task.Factory.StartNew(() =>
            {
                foreach (var lancheIngrediente in retornoProc.GroupBy(g => g.CodigoLanche).ToList())
                {
                    var novoLanche = new Lanche()
                    {
                        Codigo = lancheIngrediente.First().CodigoLanche,
                        Nome = lancheIngrediente.First().NomeLanche
                    };

                    var ingredientesDoLanche = new List<Ingrediente>();
                    foreach (var ingrediente in lancheIngrediente)
                    {
                        if (ingrediente.CodigoIngrediente is null)
                            break;
                        ingredientesDoLanche.Add(new Ingrediente()
                        {
                            Codigo = ingrediente.CodigoIngrediente,
                            Nome = ingrediente.NomeIngrediente,
                            Preco = ingrediente.PrecoIngrediente
                        });
                    }
                    novoLanche.Ingredientes = ingredientesDoLanche;

                    novoLanche.Preco = new Calculadora(novoLanche).ValorLancheLiquido();

                    lanches.Add(novoLanche);
                }

                return lanches;
            });
        }
    }
}
