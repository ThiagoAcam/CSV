using System;
using CSV.AplicationCore.Entity;
using CSV.AplicationCore.Interfaces.Services;
using CSV.AplicationCore.Services;
using CSV.Infrastructure.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSV.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void testInserts()
        {
            Seguro Dados = new Seguro()
            {
                Cliente = new Cliente { Nome = "Thiago", CPF = "11111111111", Idade = 27 },
                Veiculo = new Veiculo { Marca = "Honda", Modelo = "Fit", Valor = 70000 }
            };

            IClienteService _clienteService = new ClienteService(new ClienteRepository());
            IVeiculoService _veiculoService = new VeiculoService(new VeiculoRepository());
            ISeguroService _seguroService = new SeguroService(new SeguroRepository());

            Dados.Cliente = _clienteService.Adicionar(Dados.Cliente);

            Dados.Veiculo.Id_Cliente = Dados.Cliente.Id;
            Dados.Veiculo = _veiculoService.Adicionar(Dados.Veiculo);

            var seguro = _seguroService.Adicionar(Dados);

            Assert.AreEqual(true, seguro != null);
        }
    }
}
