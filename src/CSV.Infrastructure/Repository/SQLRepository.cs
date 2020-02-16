using CSV.AplicationCore.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CSV.Infrastructure.Repository
{
    public class SQLRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly SqlConnection con;

        public SQLRepository()
        {
            con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CSV;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public virtual TEntity Adicionar(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity ObterPorId(int Id)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
