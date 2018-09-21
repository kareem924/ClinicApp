using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abstract.Entities;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using System.Data.SqlClient;
namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            string sql = "SELECT TOP 10 * FROM Users";

            using (var connection = new SqlConnection(
               @"Server=localhost;Database=ClinicApp;User Id=sa;Password=P@ssw0rd;"))
            {
               var users = connection.Query<User>(sql).ToList();

               return users;
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
