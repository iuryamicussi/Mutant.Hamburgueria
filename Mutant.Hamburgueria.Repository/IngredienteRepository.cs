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

namespace Mutant.Hamburgueria.Repository
{
    public class IngredienteRepository : RepositoryBase, IIngredienteRepository
    {
        public IngredienteRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<IEnumerable<Ingrediente>> SelecionarTodos()
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM Ingredientes";
                conn.Open();
                var result = await conn.QueryAsync<Ingrediente>(sQuery);
                return result.ToList();
            }
        }
    }
}
