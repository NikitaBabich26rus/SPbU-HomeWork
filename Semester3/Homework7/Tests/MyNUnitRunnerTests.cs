using MyNUnitRunner;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        private MyNUnit myNUnit;

        private bool IsEqual(TestInfo testInfo, string name, string result, string ignoreReason) =>
            testInfo.Name == name && testInfo.Result == result && testInfo.IgnoreReason == ignoreReason;

        [SetUp]
        public void Setup()
        {
            myNUnit = new();
        }

        [Test]
        public void ExceptionTests()
        {
            var tests = myNUnit.MyNUnitRun("../../../ExceptionTests");
            tests.TryDequeue(out var info);
            var infoArray = info.Tests.ToArray();
            var answer1 = IsEqual(infoArray[0], "ExceptionTest1", "Passed", "Attempted to divide by zero.")
                && IsEqual(infoArray[1], "ExceptionTest2", "Passed", "Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'index')");
            var answer2 = IsEqual(infoArray[1], "ExceptionTest1", "Passed", "Attempted to divide by zero.")
                && IsEqual(infoArray[0], "ExceptionTest2", "Passed", "Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'index')");
            Assert.IsTrue(answer1 || answer2);
        }

        [Test]
        public void FailedTests()
        {
            var tests = myNUnit.MyNUnitRun("../../../FailedTests");
            tests.TryDequeue(out var info);
            var infoArray = info.Tests.ToArray();
            var answer1 = IsEqual(infoArray[0], "FailedTest1", "Failed", "Attempted to divide by zero.")
                && IsEqual(infoArray[1], "FailedTest2", "Failed", "Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'index')");
            var answer2 = IsEqual(infoArray[1], "FailedTest1", "Failed", "Attempted to divide by zero.")
                && IsEqual(infoArray[0], "FailedTest2", "Failed", "Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'index')");
            Assert.IsTrue(answer1 || answer2);
        }

        [Test]
        public void PassedTests()
        {
            var tests = myNUnit.MyNUnitRun("../../../PassedTests");
            tests.TryDequeue(out var info);
            var infoArray = info.Tests.ToArray();
            var answer1 = IsEqual(infoArray[0], "SucceededTest1", "Passed", null) && IsEqual(infoArray[1], "SucceededTest2", "Passed", null);
            var answer2 = IsEqual(infoArray[0], "SucceededTest2", "Passed", null) && IsEqual(infoArray[1], "SucceededTest1", "Passed", null);
            Assert.IsTrue(answer1 || answer2);
        }
    }
}