using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitySampleBL.Interfaces;

namespace UnitySampleBL.Implements
{
    public class Lead : IEmployee
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Lead));

        public string WhoCalledMe()
        {
            Logger.Info("Lead.WhoCalledMe");
            return "Lead.WhoCalledMe";
        }
    }
}
