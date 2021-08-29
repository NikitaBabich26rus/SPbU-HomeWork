using Atributes;
using System;
using System.Collections.Generic;

namespace FailedTests
{
    public class FailedTests
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
            var list = new List<int>();
            list[5] = 3;
        }
    }
}
