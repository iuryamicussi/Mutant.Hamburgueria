using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mutant.Hamburgueria.Model.Promocoes;

namespace Mutant.Hamburgueria.Model
{
    public class Calculadora
    {
        public Lanche Lanche { get; private set; }
        public IEnumerable<PromocaoBase> Promocoes { get; private set; }

        public Calculadora(Lanche lanche)
        {
            Lanche = lanche;
            Promocoes = new List<PromocaoBase>()
            {
                new PromocaoDoubleBurguer(lanche),
                new PromocaoDoubleCheese(lanche),
                new PromocaoFit(lanche)
            };
        }

        public decimal ValorLancheLiquido()
        {
            return ValorIngredientes() - ValorDescontos();
        }

        public decimal ValorLancheBruto()
        {
            return ValorIngredientes();
        }

        private decimal ValorIngredientes() => Lanche.Ingredientes.Sum(s => s.Preco);
        private decimal ValorDescontos() => Promocoes.Sum(s => s.ValorDoDesconto());
    }

}
