using CSV.AplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSV.API.Models
{
    public class RelatorioViewModel
    {

        public string Marca { get; set; }
        public decimal MediaPreco { get; set; }

        public List<RelatorioViewModel> RetornaRelatorio(ISeguroService seguroService)
        {
            var retorno = seguroService.ObterTodos().GroupBy(x => x.Veiculo.Marca).Select(x => new RelatorioViewModel()
            {
                Marca = x.Key,
                MediaPreco = Math.Round(x.Average(a => a.Valor), 2)
            }).ToList();

            return retorno;
        }


    }
}