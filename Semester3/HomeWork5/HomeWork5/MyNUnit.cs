using Attributes;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HomeWork5
{
    /// <summary>
    /// NUnit tests class
    /// </summary>
    public class MyNUnit
    {
        MethodLists methods;

        /// <summary>
        /// Tests info
        /// </summary>
        public ConcurrentQueue<TestInfo> TestsInfo { get; private set; }

        /// <summary>
        /// Constructor for starting tests running.
        /// </summary>
        /// <param name="path">Path to assembly</param>
        public MyNUnit(string path)
        {
            var files = Directory.EnumerateFiles(path, "*.dll", SearchOption.AllDirectories);
            var classes = files.Select(Assembly.LoadFrom).Distinct().SelectMany(a => a.ExportedTypes).Where(t => t.IsClass);
            var types = classes.Where(c => c.GetMethods().Any(m => m.GetCustomAttributes().Any(a => a is Test)));
            TestsInfo = new ConcurrentQueue<TestInfo>();
            Parallel.ForEach(types, Testing);
        }

        /// <summary>
        /// Run tests
        /// </summary>
        /// <param name="type">Set of tests</param>
        private void Testing(Type type)
        {
            ParseFileWithTests(type);
            TestsInfo = new ConcurrentQueue<TestInfo>();

            if (!AfterClassOrBeforeClassTesting(type, methods.BeforeClass))
            {
                return;
            }

            var currentQueue = new ConcurrentQueue<TestInfo>();
            foreach (var test in methods.Tests)
            {
                RunTest(type, test, currentQueue);
            }

            if (!AfterClassOrBeforeClassTesting(type, methods.AfterClass))
            {
                return;
            }

            TestsInfo = currentQueue;
        }

        /// <summary>
        /// Run test
        /// </summary>
        /// <param name="type">Set of tests</param>
        /// <param name="method">Method for testsing</param>
        /// <param name="queue">queue for test info</param>
        private void RunTest(Type type, MethodInfo method, ConcurrentQueue<TestInfo> queue)
        {
            var instance = Activator.CreateInstance(type);

            var exceptionBefore = AfterOrBeforeTesting(type, methods.Before);
            if (exceptionBefore != null)
            {
                queue.Enqueue(new TestInfo(method.Name, "Failed", exceptionBefore, 0));
                return;
            }

            TestInfo currentTestInfo;
            var property = (Test)Attribute.GetCustomAttribute(method, typeof(Test));
            if (property.Ignore != null)
            {
                currentTestInfo = new TestInfo(method.Name, "Ignored", property.Ignore, 0);
            }
            var stopWatch = new Stopwatch();
            var result = "Passed";
            try
            {
                stopWatch.Start();
                method.Invoke(instance, null);
                stopWatch.Stop();
                currentTestInfo = new TestInfo(method.Name, result, null, stopWatch.ElapsedMilliseconds);
            }
            catch (Exception e)
            {
                stopWatch.Stop();
                if (e.InnerException.GetType() != property.Expected)
                {
                    result = "Failed";
                }
                currentTestInfo = new TestInfo(method.Name, result, e.Message, stopWatch.ElapsedMilliseconds);
            }

            var exceptionAfter = AfterOrBeforeTesting(type, methods.After);
            if (exceptionAfter != null)
            {
                queue.Enqueue(new TestInfo(method.Name, "Failed", exceptionAfter, 0));
                return;
            }

            queue.Enqueue(currentTestInfo);
        }

        /// <summary>
        /// Run testing methods with attribute After and Before
        /// </summary>
        /// <param name="type">Set of methods</param>
        /// <param name="methods">Methods with attribute After or Before</param>
        /// <returns>Exception or null</returns>
        private string AfterOrBeforeTesting(Type type, List<MethodInfo> methods)
        {
            var instance = Activator.CreateInstance(type);
            foreach (var method in methods)
            {
                if (method.IsStatic)
                {
                    throw new InvalidOperationException("Before and After method mustn't be static.");
                }
                try
                {
                    method.Invoke(instance, null);
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
            return null;
        }

        /// <summary>
        /// Run testing methods with attribute AfterClass and BeforeClass
        /// </summary>
        /// <param name="type">Set of methods</param>
        /// <param name="methods">Methods with attribute AfterClass or BeforeClass</param>
        /// <returns>Exception or null</returns>
        private bool AfterClassOrBeforeClassTesting(Type type, List<MethodInfo> methods)
        {
            var instance = Activator.CreateInstance(type);

            foreach (var method in methods)
            {
                if (!method.IsStatic)
                {
                    throw new InvalidOperationException("BeforeClass and AfterClass method must be static");
                }
                try
                {
                    method.Invoke(instance, null);
                }
                catch (Exception e)
                {
                    foreach (var test in this.methods.Tests)
                    {
                        TestsInfo.Enqueue(new TestInfo(test.Name, "Failed", e.Message, 0));
                    }
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Parse set of tests by attributes
        /// </summary>
        /// <param name="type">set of tests</param>
        private void ParseFileWithTests(Type type)
        {
            methods = new MethodLists();

            foreach (var method in type.GetMethods())
            {
                foreach (var attribute in Attribute.GetCustomAttributes(method))
                {
                    if (attribute.GetType() == typeof(BeforeClass))
                    {
                        methods.BeforeClass.Add(method);
                    }
                    else if (attribute.GetType() == typeof(Before))
                    {
                        methods.Before.Add(method);
                    }
                    else if (attribute.GetType() == typeof(Test))
                    {
                        methods.Tests.Add(method);
                    }
                    else if (attribute.GetType() == typeof(After))
                    {
                        methods.After.Add(method);
                    }
                    else if (attribute.GetType() == typeof(AfterClass))
                    {
                        methods.AfterClass.Add(method);
                    }
                }
            }
        }
    }
}