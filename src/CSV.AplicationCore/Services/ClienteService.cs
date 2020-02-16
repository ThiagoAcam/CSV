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
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Cliente Adicionar(Cliente entity)
        {
            return _clienteRepository.Adicionar(entity);
        }

        public Cliente ObterPorId(int Id)
        {
            return _clienteRepository.ObterPorId(Id);
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            return _clienteRepository.ObterTodos();
        }
    }
}
