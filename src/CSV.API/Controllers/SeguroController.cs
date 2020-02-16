using CSV.API.Models;
using CSV.AplicationCore.Entity;
using CSV.AplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CSV.API.Controllers
{
    public class SeguroController : ApiController
    {
        ISeguroService _seguroService;
        IClienteService _clienteService;
        IVeiculoService _veiculoService;

        public SeguroController(ISeguroService seguroService, IClienteService clienteService, IVeiculoService veiculoService)
        {
            _seguroService = seguroService;
            _clienteService = clienteService;
            _veiculoService = veiculoService;
        }

        [HttpPost]
        public IHttpActionResult Calcular([FromBody] Seguro Dados)
        {
            Dados.Cliente = _clienteService.Adicionar(Dados.Cliente);
            
            Dados.Veiculo.Id_Cliente = Dados.Cliente.Id;
            Dados.Veiculo = _veiculoService.Adicionar(Dados.Veiculo);

            return Ok(_seguroService.Adicionar(Dados));
        }

        [HttpGet]
        public IHttpActionResult Buscar(int Id)
        {
            return Ok(_seguroService.ObterPorId(Id));
        }

    }
}
