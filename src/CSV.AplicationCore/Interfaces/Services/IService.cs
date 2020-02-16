using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV.AplicationCore.Interfaces.Services
{
    public interface IService<TEntity> where TEntity : class
    {
        TEntity Adicionar(TEntity entity);
        TEntity ObterPorId(int Id);
        IEnumerable<TEntity> ObterTodos();
    }
}
