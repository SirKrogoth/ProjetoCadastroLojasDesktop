using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;


namespace ConsumindoWebAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                //Aqui será informado de qual fonte os dados serão baixados
                client.BaseAddress = new Uri("http://localhost:50082/api/Cliente");

                var resposta = await client.GetAsync("");
                //Aqui será transformado nossa resposta em STRING
                string dados = await resposta.Content.ReadAsStringAsync();

                List<Cliente> clientes = new JavaScriptSerializer().Deserialize<List<Cliente>>(dados);

                dataGridView1.DataSource = clientes;
            }
        }

        private async void btnGravar_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50082/api/Cliente");

                Cliente cliente = new Cliente();

                cliente.codigo = Convert.ToInt32(txtCodigo.Text);
                cliente.nome = txtNome.Text;
                cliente.dataCadastro = dtpCadastro.Value;
                cliente.tipo = Convert.ToInt32(txtTipo.Text);
                //POSTASJSONASYNC
                var resposta = await client.PostAsJsonAsync("", cliente);
                //PUTAsJsonAsync
                //DELETEAsync
            }
        }
    }
}
