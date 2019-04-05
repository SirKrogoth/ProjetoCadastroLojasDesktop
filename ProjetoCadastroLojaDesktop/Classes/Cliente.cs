using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCadastroLojaDesktop
{
    public partial class Cliente
    {
        //public int? codigo { get; set; }
        private int _codigo;
        public int codigo
        {
            get
            {
                return _codigo;
            }
            set
            {
                if(value < 0)
                {
                    throw new ProjetoCadastroLojaDesktop.Excecoes.ValidacaoException("O código informado para este cliente está inválido. Favor, revise as informações lançadas.");
                    _codigo = 0;
                }
            }
        }
        private string _nome;
        public string nome
        {
            get
            {
                return _nome;
            }
            set
            {
                if(value.Length <= 3)
                    throw new ProjetoCadastroLojaDesktop.Excecoes.ValidacaoException("Não é possível inserir um nome com menos de 4 caracteres.");
            }
        }
        public int? tipo { get; set; }
        public DateTime? dataCadastro { get; set; }

        public List<Classes.Contato> contatos { get; set; }
    }
}
