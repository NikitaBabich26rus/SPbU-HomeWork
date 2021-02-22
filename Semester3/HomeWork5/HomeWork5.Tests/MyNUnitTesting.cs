using NUnit.Framework;

namespace HomeWork5.Tests
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
            var info = tests.TestsInfo.ToArray();
            Assert.IsTrue(IsEqual(info[0], "ExceptionTest1", "Passed", "Exception has been thrown by the target of an invocation."));
            Assert.IsTrue(IsEqual(info[1], "ExceptionTest2", "Passed", "Exception has been thrown by the target of an invocation."));
        }

        [Test]
        public void FailedTests()
        {
            tests = new MyNUnit("../../../../FailedTests");
            var info = tests.TestsInfo.ToArray();
            Assert.IsTrue(IsEqual(info[0], "FailedTest1", "Failed", "Exception has been thrown by the target of an invocation."));
            Assert.IsTrue(IsEqual(info[1], "FailedTest2", "Failed", "Exception has been thrown by the target of an invocation."));
        }

        [Test]
        public void PassedTests()
        {
            tests = new MyNUnit("../../../../PassedTests");
            var info = tests.TestsInfo.ToArray();
            Assert.IsTrue(IsEqual(info[0], "SucceededTest1", "Passed", null));
            Assert.IsTrue(IsEqual(info[1], "SucceededTest2", "Passed", null));
        }
    }
}