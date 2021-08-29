﻿using Atributes;
using System;
using System.Collections.Generic;

namespace ExceptionTests
{
    public class ExceptionTests
    {
        [BeforeClass]
        public static void BeforeClass()
        {

        }

        [Before]
        public void Before()
        {

        }

        [Test(Expected = typeof(DivideByZeroException))]
        public void ExceptionTest1()
        {
            var number = 5;
            number /= 0;
        }

        [Test(Expected = typeof(ArgumentOutOfRangeException))]
        public void ExceptionTest2()
        {
            var list = new List<int>();
            list[5] = 3;
        }

        [After]
        public void After()
        {

        }

        [AfterClass]
        public static void AfterClass()
        {

        }
    }
}
