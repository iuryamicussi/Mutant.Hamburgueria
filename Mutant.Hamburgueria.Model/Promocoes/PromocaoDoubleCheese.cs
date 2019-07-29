using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mutant.Hamburgueria.Common;

namespace Mutant.Hamburgueria.Model.Promocoes
{
    public class PromocaoDoubleCheese : PromocaoBase
    {
        private int _ingredientePromocao;
        private decimal _precoIngredientePromocao;
        private readonly int QTDPROMOCAO = 3;

        public PromocaoDoubleCheese(Lanche lanche) : base(lanche)
        {
            _ingredientePromocao = _.INGREDIENTES_DEFAULT["QUEIJO"];
            _precoIngredientePromocao = lanche.Ingredientes.FirstOrDefault(w => w.Codigo == _ingredientePromocao)?.Preco ?? 0;
        }

        public override decimal ValorDoDesconto()
        {
            return Math.Abs(lanche.Ingredientes.Count(c => c.Codigo == _ingredientePromocao) / QTDPROMOCAO) * _precoIngredientePromocao;
        }
    }
}
