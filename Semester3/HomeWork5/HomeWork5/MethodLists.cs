using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace HomeWork5
{
    public class MethodLists
    {
        public List<MethodInfo> BeforeClass { get; set; }

        public  List<MethodInfo> AfterClass { get; set; }

        public List<MethodInfo> Before { get; set; }

        public List<MethodInfo> After { get; set; }

        public List<MethodInfo> Tests { get; set; }
    }
}
