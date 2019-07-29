using System;
using System.Collections.Generic;
using System.Text;

namespace Mutant.Hamburgueria.Model
{
    public class Lanche
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public IEnumerable<Ingrediente> Ingredientes { get; set; }

        public virtual decimal Preco { get; set; }
    }
}
