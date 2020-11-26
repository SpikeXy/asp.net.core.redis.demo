using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace asp.net.core.webapi.redis.demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CacheController : ControllerBase
    {
        private readonly IDatabase _database;
        public CacheController(IDatabase database)
        {
            _database = database;
        }
        // GET: api/<CacheController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //与上面的GET重复了，只能存在一个
        // GET api/<CacheController>/5
        //[HttpGet]
        //public string Get([FromQuery]string key)
        //{
        //    return _database.StringGet(key);
        //}

        // POST: api/Cache
        [HttpPost]
        public void Post([FromBody] KeyValuePair<string, string> keyValue)
        {
            var result = _database.StringSet(keyValue.Key, keyValue.Value);
            var r = 1;

        }

        //与上面的POST重复了，只能存在一个
        // POST api/<CacheController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<CacheController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CacheController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
