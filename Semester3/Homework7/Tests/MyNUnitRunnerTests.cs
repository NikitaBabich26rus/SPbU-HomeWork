using MyNUnitRunner;
using NUnit.Framework;
using System.IO;
using System.Threading;

namespace Tests
{
    public class Tests
    {
        private MyNUnit tests;

        private bool IsEqual(TestInfo testInfo, string name, string result, string ignoreReason) =>
            testInfo.Name == name && testInfo.Result == result && testInfo.IgnoreReason == ignoreReason;

        [Test]
        public void ExceptionTests()
        {
            tests = new MyNUnit("../../../../ExceptionTests");
            tests.ClassQueue.TryDequeue(out var info);
            var infoArray = info.ToArray();
            var answer1 = IsEqual(infoArray[0], "ExceptionTest1", "Passed", "Exception has been thrown by the target of an invocation.")
                && IsEqual(infoArray[1], "ExceptionTest2", "Passed", "Exception has been thrown by the target of an invocation.");
            var answer2 = IsEqual(infoArray[1], "ExceptionTest1", "Passed", "Exception has been thrown by the target of an invocation.")
                && IsEqual(infoArray[0], "ExceptionTest2", "Passed", "Exception has been thrown by the target of an invocation.");
            Assert.IsTrue(answer1 || answer2);
        }

        [Test]
        public void FailedTests()
        {
            tests = new MyNUnit("../../../../FailedTests");
            tests.ClassQueue.TryDequeue(out var info);
            var infoArray = info.ToArray();
            var answer1 = IsEqual(infoArray[0], "FailedTest1", "Failed", "Exception has been thrown by the target of an invocation.")
                && IsEqual(infoArray[1], "FailedTest2", "Failed", "Exception has been thrown by the target of an invocation.");
            var answer2 = IsEqual(infoArray[1], "FailedTest1", "Failed", "Exception has been thrown by the target of an invocation.")
                && IsEqual(infoArray[0], "FailedTest2", "Failed", "Exception has been thrown by the target of an invocation.");
            Assert.IsTrue(answer1 || answer2);
        }

        [Test]
        public void PassedTests()
        {
            tests = new MyNUnit("../../../../PassedTests");
            tests.ClassQueue.TryDequeue(out var info);
            var infoArray = info.ToArray();
            var answer1 = IsEqual(infoArray[0], "SucceededTest1", "Passed", null) && IsEqual(infoArray[1], "SucceededTest2", "Passed", null);
            var answer2 = IsEqual(infoArray[0], "SucceededTest2", "Passed", null) && IsEqual(infoArray[1], "SucceededTest1", "Passed", null);
            Assert.IsTrue(answer1 || answer2);
        }
    }
}