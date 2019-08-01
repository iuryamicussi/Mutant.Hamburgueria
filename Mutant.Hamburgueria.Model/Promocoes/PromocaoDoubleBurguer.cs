using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Mutant.Hamburgueria.Common;

namespace Mutant.Hamburgueria.Model.Promocoes
{
    public class PromocaoDoubleBurguer : PromocaoBase
    {
        private int _ingredientePromocao;
        private decimal _precoIngredientePromocao;
        private readonly int QTDPROMOCAO = 3;

        public PromocaoDoubleBurguer(Lanche lanche) : base(lanche)
        {
            _ingredientePromocao = _.INGREDIENTES_DEFAULT["HAMBURGUER DE CARNE"];
            _precoIngredientePromocao = lanche.Ingredientes.FirstOrDefault(w => w.Codigo == _ingredientePromocao)?.Preco ?? 0;
        }

        public override decimal ValorDoDesconto()
        {
            //return Math.Abs(lanche.Ingredientes.Count(c => c.Codigo == _ingredientePromocao) / QTDPROMOCAO) * _precoIngredientePromocao;
            return 0; //forçando teste a falhar, testando integração contínua
        }
    }
}
