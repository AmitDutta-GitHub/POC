using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UnitySampleBL.Interfaces;

namespace UnityWebApiSample.Controllers
{
    [RoutePrefix("api")]
    public class TestApiController : ApiController
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(HomeController));

        public TestApiController(IEmployee employee)
        {
            this.Lead = employee;
        }

        public IEmployee Employee { get; set; }
        public IEmployee Lead { get; set; }

        [HttpGet]
        [Route("V1/OutreachCampaignEventTypes")]
        [Description("This function returns list of EventType")]
        public List<string> GetAllCampaignEventTypes()
        {
            Logger.Debug("GetAllEventTypes called...");
            List<string> retval = null;

            try
            {
                 this.Employee.WhoCalledMe();
            }
            catch (Exception ex)
            {
                Logger.Error("Error in method GetAllEventTypes", ex);
            }

            return retval;
        }
    }
}
