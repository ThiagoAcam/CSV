using CSV.API.Models;
using CSV.AplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CSV.API.Controllers
{
    public class RelatorioPorMarcaController : ApiController
    {
        ISeguroService _seguroService;

        public RelatorioPorMarcaController(ISeguroService seguroService)
        {
            _seguroService = seguroService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var relatorio = new RelatorioViewModel();

            return Ok(relatorio.RetornaRelatorio(_seguroService));
        }

    }
}
