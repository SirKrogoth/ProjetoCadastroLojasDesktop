using Loja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class ClienteController : ApiController
    {
        List<Cliente> clientes = new List<Cliente>();
        // GET: api/Cliente
        public IEnumerable<Cliente> Get()
        {
            PreencherLista();            

            return clientes;
            //return new string[] { "value1", "value2" };
        }

        public List<Cliente> PreencherLista()
        {
            Cliente cliente;

            cliente = new Cliente();
            cliente.codigo = 1;
            cliente.nome = "JOAO";
            cliente.dataCadastro = DateTime.Now;
            cliente.tipo = 1;

            clientes.Add(cliente);

            cliente = new Cliente();

            cliente.codigo = 2;
            cliente.nome = "MARIA";
            cliente.dataCadastro = DateTime.Now;
            cliente.tipo = 2;

            clientes.Add(cliente);

            cliente = new Cliente();

            cliente.codigo = 3;
            cliente.nome = "CAROLINE";
            cliente.dataCadastro = DateTime.Now;
            cliente.tipo = 3;

            clientes.Add(cliente);

            return clientes;
        }

        // GET: api/Cliente/5
        public Cliente Get(int id)
        {
            PreencherLista();

            return clientes[id];
            //return "value";
        }

        // POST: api/Cliente
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Cliente/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Cliente/5
        public void Delete(int id)
        {
        }
    }
}
