using CSV.AplicationCore.Entity;
using CSV.AplicationCore.Interfaces.Repositories;
using CSV.AplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSV.AplicationCore.VariaveisEstaticas;

namespace CSV.AplicationCore.Services
{
    public class SeguroService: ISeguroService
    {
        private readonly ISeguroRepository _seguroRepository;

        public SeguroService(ISeguroRepository seguroRepository)
        {
            _seguroRepository = seguroRepository;
        }

        public Seguro Adicionar(Seguro entity)
        {
            entity.Tx_Risco = (entity.Veiculo.Valor * 5) / (entity.Veiculo.Valor * 2) / 100;
            entity.Premio_Risco = entity.Tx_Risco * entity.Veiculo.Valor;
            entity.Premio_Puro = entity.Premio_Risco * VariaveisEstaticas.VariaveisEstaticas.MARGEM_SEGURANCA;
            entity.Premio_Comercial = entity.Premio_Puro * VariaveisEstaticas.VariaveisEstaticas.LUCRO;
            entity.Valor = entity.Premio_Comercial;

            return _seguroRepository.Adicionar(entity);
        }

        public Seguro ObterPorId(int Id)
        {
            return _seguroRepository.ObterPorId(Id);
        }

        public IEnumerable<Seguro> ObterTodos()
        {
            return _seguroRepository.ObterTodos();
        }
    }
}
