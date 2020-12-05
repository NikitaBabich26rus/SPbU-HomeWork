using Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasedTests
{
    public class PasedTests
    {
        [Test]
        public void FailedTest1()
        {
            var number = 5;
            number /= 0;
        }

        [Test]
        public void FailedTest2()
        {
            List<int> list = new List<int>();
            list[5] = 3;
        }
    }
}
