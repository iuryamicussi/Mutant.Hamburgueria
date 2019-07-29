using NUnit.Framework;
using FluentAssertions;
using Mutant.Hamburgueria.Model;
using System.Collections.Generic;
using Mutant.Hamburgueria.Common;

namespace Tests
{
    public class PromocoesTest
    {
        [Test]
        public void QuandoPassadoLancheSemPromocaoValorLiquidoDeveSerIgualValorBruto()
        {
            //arrange
            var lanche = new Lanche()
            {
                Codigo = 1,
                Nome = "Teste",
                Ingredientes = new List<Ingrediente>()
                {
                    new Ingrediente(){ Codigo = -999, Preco = 10}
                }
            };
            var calculadora = new Calculadora(lanche);
            //act
            var valorBruto = calculadora.ValorLancheBruto();
            var valorLiquido = calculadora.ValorLancheLiquido();
            var valorEsperado = 10;
            //assert
            valorBruto.Should().Be(valorEsperado);
            valorLiquido.Should().Be(valorEsperado);
        }

        [Test]
        public void QuandoPassadoLancheCom3OuMaisHamburguersDeveAtivarPromocaoHamburguer()
        {
            //arrange
            var lanche = new Lanche()
            {
                Codigo = 1,
                Nome = "Teste",
                Ingredientes = new List<Ingrediente>()
                {
                    new Ingrediente(){ Codigo = _.INGREDIENTES_DEFAULT["HAMBURGUER DE CARNE"], Preco = 10},
                    new Ingrediente(){ Codigo = _.INGREDIENTES_DEFAULT["HAMBURGUER DE CARNE"], Preco = 10},
                    new Ingrediente(){ Codigo = _.INGREDIENTES_DEFAULT["HAMBURGUER DE CARNE"], Preco = 10},
                    new Ingrediente(){ Codigo = _.INGREDIENTES_DEFAULT["HAMBURGUER DE CARNE"], Preco = 10},
                    new Ingrediente(){ Codigo = _.INGREDIENTES_DEFAULT["HAMBURGUER DE CARNE"], Preco = 10},
                    new Ingrediente(){ Codigo = _.INGREDIENTES_DEFAULT["HAMBURGUER DE CARNE"], Preco = 10},
                }
            };
            var calculadora = new Calculadora(lanche);
            //act
            var valorBruto = calculadora.ValorLancheBruto();
            var valorLiquido = calculadora.ValorLancheLiquido();

            var valorLiquidoEsperado = 40;
            var valorBrutoEsperado = 60;
            //assert
            valorBruto.Should().Be(valorBrutoEsperado);
            valorLiquido.Should().Be(valorLiquidoEsperado);
        }

        [Test]
        public void QuandoPassadoLancheCom3OuMaisQueijosDeveAtivarPromocaoHamburguer()
        {
            //arrange
            var lanche = new Lanche()
            {
                Codigo = 1,
                Nome = "Teste",
                Ingredientes = new List<Ingrediente>()
                {
                    new Ingrediente(){ Codigo = _.INGREDIENTES_DEFAULT["QUEIJO"], Preco = 10},
                    new Ingrediente(){ Codigo = _.INGREDIENTES_DEFAULT["QUEIJO"], Preco = 10},
                    new Ingrediente(){ Codigo = _.INGREDIENTES_DEFAULT["QUEIJO"], Preco = 10},
                    new Ingrediente(){ Codigo = _.INGREDIENTES_DEFAULT["QUEIJO"], Preco = 10},
                    new Ingrediente(){ Codigo = _.INGREDIENTES_DEFAULT["QUEIJO"], Preco = 10},
                }
            };
            var calculadora = new Calculadora(lanche);
            //act
            var valorBruto = calculadora.ValorLancheBruto();
            var valorLiquido = calculadora.ValorLancheLiquido();

            var valorLiquidoEsperado = 40;
            var valorBrutoEsperado = 50;
            //assert
            valorBruto.Should().Be(valorBrutoEsperado);
            valorLiquido.Should().Be(valorLiquidoEsperado);
        }

        [Test]
        public void QuandoPassadoLancheComAlfaceSemBaconDeveAtivarPromocaoFit()
        {
            //arrange
            var lanche = new Lanche()
            {
                Codigo = 1,
                Nome = "Teste",
                Ingredientes = new List<Ingrediente>()
                {
                    new Ingrediente(){ Codigo = _.INGREDIENTES_DEFAULT["ALFACE"], Preco = 5},
                    new Ingrediente(){ Codigo = _.INGREDIENTES_DEFAULT["QUEIJO"], Preco = 10}
                }
            };
            var calculadora = new Calculadora(lanche);
            //act
            var valorBruto = calculadora.ValorLancheBruto();
            var valorLiquido = calculadora.ValorLancheLiquido();

            var valorBrutoEsperado = 15;
            var valorLiquidoEsperado = valorBrutoEsperado * 0.9M;
            
            //assert
            valorBruto.Should().Be(valorBrutoEsperado);
            valorLiquido.Should().Be(valorLiquidoEsperado);
        }

        [Test]
        public void QuandoPassadoLancheComTodasPromocoesDeveAtivarTodasPromocoes()
        {
            //arrange
            var lanche = new Lanche()
            {
                Codigo = 1,
                Nome = "Teste",
                Ingredientes = new List<Ingrediente>()
                {
                    new Ingrediente(){ Codigo = _.INGREDIENTES_DEFAULT["ALFACE"], Preco = 5},
                    new Ingrediente(){ Codigo = _.INGREDIENTES_DEFAULT["QUEIJO"], Preco = 11},
                    new Ingrediente(){ Codigo = _.INGREDIENTES_DEFAULT["QUEIJO"], Preco = 11},
                    new Ingrediente(){ Codigo = _.INGREDIENTES_DEFAULT["QUEIJO"], Preco = 11},
                    new Ingrediente(){ Codigo = _.INGREDIENTES_DEFAULT["HAMBURGUER DE CARNE"], Preco = 22},
                    new Ingrediente(){ Codigo = _.INGREDIENTES_DEFAULT["HAMBURGUER DE CARNE"], Preco = 22},
                    new Ingrediente(){ Codigo = _.INGREDIENTES_DEFAULT["HAMBURGUER DE CARNE"], Preco = 22},
                    new Ingrediente(){ Codigo = _.INGREDIENTES_DEFAULT["HAMBURGUER DE CARNE"], Preco = 22},
                    new Ingrediente(){ Codigo = _.INGREDIENTES_DEFAULT["HAMBURGUER DE CARNE"], Preco = 22},
                    new Ingrediente(){ Codigo = _.INGREDIENTES_DEFAULT["HAMBURGUER DE CARNE"], Preco = 22},
                    new Ingrediente(){ Codigo = _.INGREDIENTES_DEFAULT["HAMBURGUER DE CARNE"], Preco = 22},
                    new Ingrediente(){ Codigo = _.INGREDIENTES_DEFAULT["OVO"], Preco = 3.77M}
                }
            };
            var calculadora = new Calculadora(lanche);
            //act
            var valorBruto = calculadora.ValorLancheBruto();
            var valorLiquido = calculadora.ValorLancheLiquido();

            var valorBrutoEsperado = 5+(11*3)+(22*7)+3.77M;
            var valorLiquidoEsperado = valorBrutoEsperado - 11 - (22*2) - valorBrutoEsperado*0.1M;

            //assert
            valorBruto.Should().Be(valorBrutoEsperado);
            valorLiquido.Should().Be(valorLiquidoEsperado);
        }
    }
}