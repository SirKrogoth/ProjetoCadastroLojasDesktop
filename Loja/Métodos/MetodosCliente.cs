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
        public Cliente()
        {
            this.novo = true;
            this.modificado = false;
        }

        public Cliente(int codigo)
        {
            using (SqlConnection cn = new SqlConnection("Data Source=(local);Initial Catalog=Loja;User ID=sa;Password=506829"))
            {
                try
                {
                    cn.Open();
                }
                catch (Exception)
                {
                    throw;
                }

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cn;

                    cmd.CommandText = "SELECT * FROM cliente WHERE codigo = @codigo";
                    cmd.Parameters.AddWithValue("@codigo", codigo);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if(dr.HasRows)
                        {
                            dr.Read();
                            this._codigo = dr.GetInt32(dr.GetOrdinal("codigo"));
                            this._nome = dr.GetString(dr.GetOrdinal("nome"));
                            this._tipo = dr.GetInt32(dr.GetOrdinal("tipo"));
                            this._dataCadastro = dr.GetDateTime(dr.GetOrdinal("dataCadastro"));
                        }
                    }

                    this.novo = false;
                    this.modificado = false;
                }
            }
        }

        public void Insert()
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
                    cmd.Parameters.AddWithValue("@tipo", this._tipo);
                    cmd.Parameters.AddWithValue("@dataCadastro", this._dataCadastro);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {

                    }
                }
            }
        }

        public void Update()
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
                    cmd.CommandText = "UPDATE cliente SET nome = @nome, tipo = @tipo, dataCadastro = @dataCadastro" + 
                        " WHERE codigo = @codigo";

                    cmd.Connection = conexao;

                    cmd.Parameters.AddWithValue("@codigo", this._codigo);
                    cmd.Parameters.AddWithValue("@nome", this._nome);
                    cmd.Parameters.AddWithValue("@tipo", this._tipo);
                    cmd.Parameters.AddWithValue("@dataCadastro", this._dataCadastro);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        this.modificado = false;
                    }
                    catch (SqlException)
                    {

                    }
                }
            }
        }

        public void Dispose()
        {
            if (this.novo)
                Insert();
            else if(this.modificado)
                Update();
        }

        public void Gravar()
        {
            
        }
    }
}
