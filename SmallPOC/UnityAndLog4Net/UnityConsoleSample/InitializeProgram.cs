using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitySampleBL.Interfaces;

namespace UnityConsoleSample
{
    public class InitializeProgram
    {
        public IEmployee Employee { get; set; }

        public string WhoCalledMe()
        {
            return Employee.WhoCalledMe();
        }
    }
}
