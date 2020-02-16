using CSV.AplicationCore.Entity;
using CSV.AplicationCore.Interfaces.Repositories;
using CSV.AplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV.AplicationCore.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoService(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public Veiculo Adicionar(Veiculo entity)
        {
            return _veiculoRepository.Adicionar(entity);
        }

        public Veiculo ObterPorId(int Id)
        {
            return _veiculoRepository.ObterPorId(Id);
        }

        public IEnumerable<Veiculo> ObterTodos()
        {
            return _veiculoRepository.ObterTodos();
        }
    }
}
