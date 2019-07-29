using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Mutant.Hamburgueria.Common;

namespace Mutant.Hamburgueria.Model.Promocoes
{
    public class PromocaoFit : PromocaoBase
    {
        private int _ingredienteFitPromocao;
        private int _ingredienteFatPromocao;
        private readonly decimal PERCENTUAL_DESCONTO = 10;

        public PromocaoFit(Lanche lanche) : base(lanche)
        {
            _ingredienteFitPromocao = _.INGREDIENTES_DEFAULT["ALFACE"];
            _ingredienteFatPromocao = _.INGREDIENTES_DEFAULT["BACON"];
        }

        public override decimal ValorDoDesconto()
        {
            if (lanche.Ingredientes.Count(alface => alface.Codigo == _ingredienteFitPromocao) <= 0 ||
                lanche.Ingredientes.Count(bacon => bacon.Codigo == _ingredienteFatPromocao) > 0)
                return 0;

            var valorIngredientes = lanche.Ingredientes.Sum(i => i.Preco);

            return valorIngredientes * (PERCENTUAL_DESCONTO / 100);
        }
    }
}
