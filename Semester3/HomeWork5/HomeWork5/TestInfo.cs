using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork5
{
    public class TestInfo
    {
        public string Result { get; }

        public string Name { get; }

        public string IgnoreReason { get; }

        public long Time { get; }

        public TestInfo(string name, string result, string ignoreReason, long time)
        {
            this.Result = result;
            this.Name = name;
            this.IgnoreReason = ignoreReason;
            this.Time = time;
        }
    }
}
