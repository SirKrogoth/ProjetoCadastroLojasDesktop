using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCadastroLojaDesktop
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Cliente cliente = new Cliente();

                cliente.codigo = 1;

                cliente.nome = "joao rafael menezes".PrimeiraMaiuscula();
                cliente.tipo = 1;
                cliente.dataCadastro = new DateTime(1989, 03, 14);
                cliente.Dispose();



                using (Cliente cliente2 = new Cliente())
                {
                    cliente2.nome = "CEBOLA".PrimeiraMaiuscula();
                    //Ao finalizar, irá chamar automaticamente o método DISPOSE
                }

                Classes.Contato contato1 = new Classes.Contato();

                contato1.Codigo = 1;
                contato1.dadosContato = "589-999999";
                contato1.tipo = "telefone";

                Classes.Contato contato2 = new Classes.Contato();

                contato2.Codigo = 2;

                //Recebe o contato2.codigo e irá enviar o valor para o método Metade
                int codigoMetadeCliente = contato2.Codigo.Metade();

                contato2.dadosContato = "joao@teleconsistemas.com.br";
                contato2.tipo = "email";

                cliente.contatos = new List<Classes.Contato>();
                cliente.contatos.Add(contato1);
                cliente.contatos.Add(contato2);

                Classes.Contato contatoEncontrado = cliente.contatos.FirstOrDefault(x => x.tipo == "telefone");
                Console.WriteLine(contatoEncontrado.dadosContato);
                Console.WriteLine("Cliente com primeira Maiuscula: " + cliente.nome);
            }
            catch (ProjetoCadastroLojaDesktop.Excecoes.ValidacaoException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }                        
           
            Console.ReadKey();
        }
    }
}
