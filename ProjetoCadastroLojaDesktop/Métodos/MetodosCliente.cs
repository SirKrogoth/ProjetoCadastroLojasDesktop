using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Em uma classe PARTIAL, é necessário que ambas estejam no mesmo namespace
namespace ProjetoCadastroLojaDesktop
{
    public partial class Cliente : IDisposable
    {
        public void Dispose()
        {
            this.Gravar();
        }

        public void Gravar()
        {

        }
    }
}
