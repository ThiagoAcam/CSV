using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV.AplicationCore.Entity
{
    public class Seguro
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public Veiculo Veiculo { get; set; }

        public decimal Tx_Risco { get; set; }
        public decimal Premio_Risco { get; set; }
        public decimal Premio_Puro { get; set; }
        public decimal Premio_Comercial { get; set; }
        public decimal Valor { get; set; }

    }
}
