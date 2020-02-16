using CSV.AplicationCore.Entity;
using CSV.AplicationCore.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV.Infrastructure.Repository
{
    public class ClienteRepository: SQLRepository<Cliente>, IClienteRepository
    {

        public override Cliente Adicionar(Cliente entity)
        {
            string sql = String.Format("insert Cliente (Nome, CPF, Idade) values('{0}', '{1}', {2}); select SCOPE_IDENTITY() as Id", entity.Nome, entity.CPF, entity.Idade);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                entity.Id = Convert.ToInt32(dr["Id"]);
            }
            con.Close();

            return entity;
        }

        public override Cliente ObterPorId(int Id)
        {
            Cliente cliente = null;

            string sql = String.Format("select * from Cliente where Id = {0}", Id);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cliente = new Cliente();

                cliente.Id = Convert.ToInt32(dr["Id"]);
                cliente.Nome = dr["Nome"].ToString();
                cliente.CPF = dr["CPF"].ToString();
                cliente.Idade = Convert.ToInt32(dr["Idade"]);
            }
            con.Close();

            return cliente;
        }

        public override IEnumerable<Cliente> ObterTodos()
        {
            List<Cliente> clientes = new List<Cliente>();

            string sql = "select * from Cliente";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Cliente cliente = new Cliente();

                cliente.Id = Convert.ToInt32(dr["Id"]);
                cliente.Nome = dr["Nome"].ToString();
                cliente.CPF = dr["CPF"].ToString();
                cliente.Idade = Convert.ToInt32(dr["Idade"]);

                clientes.Add(cliente);
            }
            con.Close();

            return clientes;
        }

    }
}
