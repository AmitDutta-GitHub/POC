using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitySampleBL.Interfaces;

namespace UnitySampleBL.Implements
{
    public class Manager : IEmployee
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Manager));

        public string WhoCalledMe()
        {
            Logger.Info("Manager.WhoCalledMe");
            return "Manager.WhoCalledMe";
        }
    }
}
