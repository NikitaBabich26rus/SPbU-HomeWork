using Atributes;

namespace PassedTests
{
    public class PassedTests
    {
        [BeforeClass]
        public static void BeforeClass()
        {
            var number = 5;
            number += 5;
        }

        [Before]
        public void Before()
        {
            var number = 10;
            number += 1;
        }

        [Test]
        public void SucceededTest1()
        {
            var number = 7;
            number += 3;
        }

        [Test]
        public void SucceededTest2()
        {
            var number = 512;
            number += 532;
        }

        [After]
        public void After()
        {
            var number = 123;
            number += 132;
        }

        [AfterClass]
        public static void AfterClass()
        {
            var number = 5312;
            number -= 213;
        }
    }
}
