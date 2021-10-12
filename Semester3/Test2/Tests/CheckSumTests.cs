using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Test2;

namespace Tests
{
    public class Tests
    {
        private CheckSum checkSum;

        /// <summary>
        /// Testing run time.
        /// </summary>
        /// <param name="path">Path</param>
        private bool RunningTimeTesting(string path)
        {
            var checkSum = new CheckSum();

            var stopWathSingleThreaded = new Stopwatch();
            stopWathSingleThreaded.Start();
            checkSum.SingleThreaded(path);
            stopWathSingleThreaded.Stop();

            var stopWathMultipleThreaded = new Stopwatch();
            stopWathMultipleThreaded.Start();
            checkSum.SingleThreaded(path);
            stopWathMultipleThreaded.Stop();

            return stopWathMultipleThreaded.Elapsed > stopWathSingleThreaded.Elapsed ? true : false;
        }

        [SetUp]
        public void Setup()
        {
            checkSum = new CheckSum();
        }

        [Test]
        public void MultipleAndSingleThreadedTest()
        {
            Assert.IsFalse(RunningTimeTesting("../../../Directory"));
        }
    }
}