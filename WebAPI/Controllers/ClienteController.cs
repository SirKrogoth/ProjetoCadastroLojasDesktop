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
        [HttpGet]
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
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            PreencherLista();
            
            return Ok(clientes[id]);
            //return "value";
            //return NotFound();
        }

        // POST: api/Cliente
        [HttpPost]
        public IHttpActionResult Post([FromBody]Cliente value)
        {
            try
            {
                value.Gravar();
            }
            catch (Exception)
            {
                throw;
            }

            return Ok();
        }

        // PUT: api/Cliente/5
        //Método equiparado ao UPDATE, serve para atualizar a base de dados
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]Cliente value)
        {
            Cliente cliente = new Cliente(id);

            cliente.codigo = value.codigo;
            cliente.nome = value.nome;
            cliente.dataCadastro = value.dataCadastro;
            cliente.tipo = value.tipo;

            try
            {
                cliente.Update();
            }
            catch (Exception)
            {
                throw;
            }

            return Ok();
        }

        // DELETE: api/Cliente/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            Cliente cliente = new Cliente(id);

            try
            {
                //cliente.Apagar();
            }
            catch (Exception)
            {

                throw;
            }

            return Ok();
        }
    }
}
