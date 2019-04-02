using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCadastroLojaDesktop.Classes
{
    public class Contato
    {
        private int _codigo;

        public int Codigo
        {
            get { return _codigo; }
            set
            {
                if(value < 0)
                    _codigo = 0;
                else
                    _codigo = value;              
            }
        }

        public string dadosContato { get; set; }
        public string tipo { get; set; }
    }
}
