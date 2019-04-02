using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// métodos de extensão
/// são usados fora do namespace, pois podem ser acessados de qualquer lugar,
/// e está vinculado a variável e não a chamada
/// </summary>


public static class MetodoExtensao
{
    public static int Metade(this int valor)
    {
        return valor / 2;
    }

    public static string PrimeiraMaiuscula(this string valor)
    {
        return valor.Substring(0, 1).ToUpper() + valor.Substring(1, valor.Length - 1).ToLower();
    }
}

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
