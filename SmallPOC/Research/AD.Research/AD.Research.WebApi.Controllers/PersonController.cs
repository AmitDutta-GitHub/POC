using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Routing;

namespace AD.Research.WebApi.Controllers
{
    [RoutePrefix("api")]
    public class PersonController : ApiController
    {
        [HttpGet]
        [Route("V1/PingPersonController")]
        [Description("This function returns current datetime.")]
        public string PingPersonController()
        {
            return DateTime.Now.ToString();
        }
    }
}
