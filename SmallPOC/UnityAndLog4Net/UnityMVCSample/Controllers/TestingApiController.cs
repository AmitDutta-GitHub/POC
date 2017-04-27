using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UnityMVCSample.Controllers
{
    public class TestingApiController : ApiController
    {
        // GET: api/TestingApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TestingApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TestingApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TestingApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TestingApi/5
        public void Delete(int id)
        {
        }
    }
}
