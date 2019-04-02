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
            Cliente cliente = new Cliente();

            cliente.codigo = 1;

            cliente.nome = "joAO RAFAEL".PrimeiraMaiuscula();
            cliente.tipo = 1;
            cliente.dataCadastro = new DateTime(1989, 03, 14);

            using (Cliente cliente2 = new Cliente())
            {
                cliente2.nome = "CEBOLA".PrimeiraMaiuscula();
                //Ao finalizar, irá chamar automaticamente o método DISPOSE
            }            

            Classes.Contato contato1 = new Classes.Contato();

            contato1.codigo = 1;
            contato1.dadosContato = "589-999999";
            contato1.tipo = "telefone";

            Classes.Contato contato2 = new Classes.Contato();

            contato2.codigo = 2;

            //Recebe o contato2.codigo e irá enviar o valor para o método Metade
            int codigoMetadeCliente = contato2.codigo.Metade();

            contato2.dadosContato = "joao@teleconsistemas.com.br";
            contato2.tipo = "email";

            cliente.contatos = new List<Classes.Contato>();
            cliente.contatos.Add(contato1);
            cliente.contatos.Add(contato2);

            Classes.Contato contatoEncontrado = cliente.contatos.FirstOrDefault(x => x.tipo == "telefone");
            Console.WriteLine(contatoEncontrado.dadosContato);
            Console.WriteLine("Cliente com primeira Maiuscula: " + cliente.nome);
            

            Console.ReadKey();
        }
    }
}
