using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumindoWebAPI
{
    public class Cliente
    {
        public int codigo { get; set; }
        public string nome { get; set; }
        public int tipo { get; set; }
        public DateTime dataCadastro { get; set; }
    }

}
