using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Repositores;

/*Controller é um objeto que manipula as solicitações HTTP (Via POSTMAN). Ele pode retornar uma lista de contas ou uma única conta através do ID.
Além das operações da CRUD*/

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class agenciasController : ControllerBase
    {
        [HttpGet("{clients}")]
        public ActionResult<List<string>> Get()
        {
            List<string> readLoaded = ClientRepository.GetClientes();
            List<string> NamesLoaded = new List<string>();

            if (readLoaded == null)
            {
                return null;
            }
            else
            {
                foreach (var item in readLoaded)
                {
                    NamesLoaded.Add(item);
                }
            }
            return NamesLoaded;
        }

        // GET api/agencias/clients/id
        [HttpGet("clients/{id}")]
        public ActionResult<List<string>> Get(int id)
        {
            List<string> readLoaded = ClientRepository.GetNameById(id);
            List<string> NamesByIdLoaded = new List<string>();

            if (readLoaded == null)
            {
                return null;
            }
            else
            {
                foreach (var item in readLoaded)
                {
                    NamesByIdLoaded.Add(item);
                }
            }
            return NamesByIdLoaded;

        }

        // GET api/agencias/clients/accounts/id
        [HttpGet("clients/accounts/{ClienteID}")]
        public ActionResult<List<string>> Get(string ClienteID)
        {
            List<string> readLoaded = ClientRepository.GetAccount(ClienteID);
            List<string> accountByIdLoadead = new List<string>();

            if (readLoaded == null)
            {
                return null;
            }
            else
            {
                foreach (var item in readLoaded)
                {
                    accountByIdLoadead.Add(item);
                }
            }
            return accountByIdLoadead;
        }

        //POST api/agencia
        [HttpPost]
        public string Post([FromBody] ClientRepository.Client client)
        {
            try 
            {
                ClientRepository.PostClient(client);
                return "Cliente adicionado com sucesso!";
            }
            catch (Exception ex)
            {
                return "Cliente não adicionado! Ocorreu o seguinte erro: " + ex.Message;
            }
        }

        [HttpPost("clients")]
        public ActionResult<bool> Post([FromBody] string name, string cpf)
        {

            return false;
        }
    

        // PUT api/agencia/5
        [HttpPut("{id}")]
        public ActionResult<bool> PutCliente(int id, [FromBody] string value)
        {
            return null;
        }

        // DELETE api/agencia/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
