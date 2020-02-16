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
    public class VeiculoRepository: SQLRepository<Veiculo>, IVeiculoRepository
    {

        public override Veiculo Adicionar(Veiculo entity)
        {
            string sql = String.Format("insert Veiculo (Marca, Modelo, Valor, Id_Cliente) values('{0}', '{1}', {2}, {3}); select SCOPE_IDENTITY() as Id", entity.Marca, entity.Modelo, entity.Valor, entity.Id_Cliente);
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

        public override Veiculo ObterPorId(int Id)
        {
            Veiculo Veiculo = null;

            string sql = String.Format("select * from Veiculo where Id = {0}", Id);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Veiculo = new Veiculo();

                Veiculo.Id = Convert.ToInt32(dr["Id"]);
                Veiculo.Marca = dr["Marca"].ToString();
                Veiculo.Modelo = dr["Modelo"].ToString();
                Veiculo.Valor = Convert.ToDecimal(dr["Valor"]);
                Veiculo.Id_Cliente = Convert.ToInt32(dr["Id_Cliente"]);
            }
            con.Close();

            return Veiculo;
        }

        public override IEnumerable<Veiculo> ObterTodos()
        {
            List<Veiculo> Veiculos = new List<Veiculo>();

            string sql = "select * from Veiculo";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Veiculo Veiculo = new Veiculo();

                Veiculo.Id = Convert.ToInt32(dr["Id"]);
                Veiculo.Marca = dr["Marca"].ToString();
                Veiculo.Modelo = dr["Modelo"].ToString();
                Veiculo.Valor = Convert.ToDecimal(dr["Valor"]);
                Veiculo.Id_Cliente = Convert.ToInt32(dr["Id_Cliente"]);

                Veiculos.Add(Veiculo);
            }
            con.Close();

            return Veiculos;
        }

    }
}
