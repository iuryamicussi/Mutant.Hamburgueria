using System;
using System.Collections.Generic;
using System.Text;

namespace Mutant.Hamburgueria.Model.Promocoes
{
    public abstract class PromocaoBase
    {
        protected Lanche lanche;

        public PromocaoBase(Lanche lanche)
        {
            this.lanche = lanche;
        }

        public abstract decimal ValorDoDesconto();
    }
}
