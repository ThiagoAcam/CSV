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
    public class SeguroRepository: SQLRepository<Seguro>, ISeguroRepository
    {

        public override Seguro Adicionar(Seguro entity)
        {
            string sql = String.Format(@"insert Seguro (Id_Cliente, Id_Veiculo, Tx_Risco, Premio_Risco, Premio_Puro, Premio_Comercial, Valor) 
                                         values(        {0},        {1},        {2},      {3},          {4},         {5},              {6}); 
                                         select SCOPE_IDENTITY() as Id",
                                         entity.Cliente.Id,
                                         entity.Veiculo.Id,
                                         entity.Tx_Risco.ToString().Replace(",","."),
                                         entity.Premio_Risco.ToString().Replace(",", "."),
                                         entity.Premio_Puro.ToString().Replace(",", "."),
                                         entity.Premio_Comercial.ToString().Replace(",", "."),
                                         entity.Valor.ToString().Replace(",", "."));
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

        public override Seguro ObterPorId(int Id)
        {
            Seguro Seguro = null;

            string sql = String.Format("select * from Seguro where Id = {0}", Id);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Seguro = new Seguro();

                Seguro.Id = Convert.ToInt32(dr["Id"]);
                Seguro.Cliente = new ClienteRepository().ObterPorId(Convert.ToInt32(dr["Id_Cliente"]));
                Seguro.Veiculo = new VeiculoRepository().ObterPorId(Convert.ToInt32(dr["Id_Veiculo"]));
                Seguro.Tx_Risco = Convert.ToDecimal(dr["Tx_Risco"]);
                Seguro.Premio_Risco = Convert.ToDecimal(dr["Premio_Risco"]);
                Seguro.Premio_Puro = Convert.ToDecimal(dr["Premio_Puro"]);
                Seguro.Premio_Comercial = Convert.ToDecimal(dr["Premio_Comercial"]);
                Seguro.Valor = Convert.ToDecimal(dr["Valor"]);
            }
            con.Close();

            return Seguro;
        }

        public override IEnumerable<Seguro> ObterTodos()
        {
            List<Seguro> Seguros = new List<Seguro>();

            string sql = "select * from Seguro";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Seguro Seguro = new Seguro();

                Seguro.Id = Convert.ToInt32(dr["Id"]);
                Seguro.Cliente = new ClienteRepository().ObterPorId(Convert.ToInt32(dr["Id_Cliente"]));
                Seguro.Veiculo = new VeiculoRepository().ObterPorId(Convert.ToInt32(dr["Id_Veiculo"]));
                Seguro.Tx_Risco = Convert.ToDecimal(dr["Tx_Risco"]);
                Seguro.Premio_Risco = Convert.ToDecimal(dr["Premio_Risco"]);
                Seguro.Premio_Puro = Convert.ToDecimal(dr["Premio_Puro"]);
                Seguro.Premio_Comercial = Convert.ToDecimal(dr["Premio_Comercial"]);
                Seguro.Valor = Convert.ToDecimal(dr["Valor"]);

                Seguros.Add(Seguro);
            }
            con.Close();

            return Seguros;
        }

    }
}
