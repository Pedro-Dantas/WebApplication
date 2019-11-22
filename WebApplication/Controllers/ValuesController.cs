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
    public class agenciaController : ControllerBase
    {
        // GET api/agencia
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            List<string> readLoaded = Model.GetNamesClientes();
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

        // GET api/agencia/5
        [HttpGet("{id}")]
        public ActionResult<List<string>> Get(int id)
        {
            List<string> readLoaded = Model.GetNameById(id);
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

        // POST api/agencia
        [HttpPost]
        public void Post([FromBody] string value)
        {
         
        }

        // PUT api/agencia/5
        [HttpPut("{id}")]
        public void PutFromCliente(int id, [FromBody] string value)
        {

        }

        // DELETE api/agencia/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
