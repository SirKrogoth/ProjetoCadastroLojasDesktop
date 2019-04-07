using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

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
namespace Loja
{
    public partial class Cliente : IDisposable
    {
        public void Dispose()
        {
            this.Gravar();
        }

        public void Gravar()
        {
            using (SqlConnection conexao = new SqlConnection("Data Source=(local);Initial Catalog=Loja;User ID=sa;Password=506829"))
            {
                try
                {
                    conexao.Open();
                }
                catch (Exception)
                {

                    throw;
                }

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "INSERT INTO cliente(codigo, nome, tipo, dataCadastro)" +
                        " VALUES(@codigo, @nome, @tipo, @dataCadastro)";
                    cmd.Connection = conexao;

                    cmd.Parameters.AddWithValue("@codigo", this.codigo);
                    cmd.Parameters.AddWithValue("@nome", this.nome);
                    cmd.Parameters.AddWithValue("@tipo", this.tipo);
                    cmd.Parameters.AddWithValue("@dataCadastro", this.dataCadastro);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        
                    }
                }
            }
        }
    }
}
