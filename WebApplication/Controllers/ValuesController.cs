using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

/*Controller é um objeto que manipula as solicitações HTTP (Via POSTMAN). Ele pode retornar uma lista de contas ou uma única conta através do ID.
Além das operações da CRUD*/

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class meudeusdoceufuncionaController : ControllerBase
    {
        // GET api/agencia
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Isso", "Funciona" };
        }

        // GET api/agencia/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/agencia
        [HttpPost]
        public void Post([FromBody] string value)
        {
         
        }

        // PUT api/agencia/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/agencia/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
