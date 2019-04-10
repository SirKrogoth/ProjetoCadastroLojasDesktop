using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja
{
    public partial class Cliente
    {        
        private bool novo;
        public bool Novo
        {
            get { return novo; }
        }

        private bool modificado;
        public bool Modificado
        {
            get { return modificado; }
        }


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
                if (value < 0)
                {
                    _codigo = 0;
                    throw new Loja.Excecoes.ValidacaoException("O código informado para este cliente está inválido. Favor, revise as informações lançadas.");                    
                }
                else
                {
                    _codigo = value;
                    this.modificado = true;
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
                if (value.Length <= 3)
                    throw new Loja.Excecoes.ValidacaoException("Não é possível inserir um nome com menos de 4 caracteres.");
                else
                {
                    _nome = value;
                    this.modificado = true;
                }
                    
            }
        }

        private int? _tipo;        
        public int? tipo
        {
            get { return _tipo; }
            set { _tipo = value; this.modificado = true; }
        }

        private DateTime? _dataCadastro;
        public DateTime? dataCadastro
        {
            get { return _dataCadastro; }
            set { _dataCadastro = value; this.modificado = true; }
        }
        
        public List<Classes.Contato> contatos { get; set; }
    }
}
