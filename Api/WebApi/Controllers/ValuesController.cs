using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abstract.Entities;
using Abstract.Repositry;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        IUserRepositry _userRepositry;
        public ValuesController(IUserRepositry userRepositry)
        {
            _userRepositry=userRepositry;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
          var User=  _userRepositry.Add(new Users());
            return new string[] { User.Name, User.Email };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public Users Post([FromBody] Users value)
        {
            var User=  _userRepositry.Add(value);
            return User;
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
