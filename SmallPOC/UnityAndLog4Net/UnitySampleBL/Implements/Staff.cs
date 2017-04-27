using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitySampleBL.Interfaces;

namespace UnitySampleBL.Implements
{
    public class Staff : IEmployee
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Staff));

        public string WhoCalledMe()
        {
            Logger.Info("Staff.WhoCalledMe");
            return "Staff.WhoCalledMe";
        }
    }
}
