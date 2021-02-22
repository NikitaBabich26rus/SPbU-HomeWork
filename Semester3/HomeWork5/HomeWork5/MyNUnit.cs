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
        private MethodLists methods;

        /// <summary>
        /// Queue with class of tests.
        /// </summary>
        public ConcurrentQueue<ConcurrentQueue<TestInfo>> ClassQueue { get; private set; }

        /// <summary>
        /// Constructor for starting tests running.
        /// </summary>
        /// <param name="path">Path to assembly</param>
        public MyNUnit(string path)
        {
            var files = Directory.EnumerateFiles(path, "*.dll", SearchOption.AllDirectories);
            var assemblies = new ConcurrentQueue<Assembly>();
            Parallel.ForEach(files, x => assemblies.Enqueue(Assembly.LoadFrom(x)));
            var classes = files.Select(Assembly.LoadFrom).Distinct().SelectMany(a => a.ExportedTypes).Where(t => t.IsClass);
            var types = classes.Where(c => c.GetMethods().Any(m => m.GetCustomAttributes().Any(a => a is Test)));
            ClassQueue = new ConcurrentQueue<ConcurrentQueue<TestInfo>>();
            Parallel.ForEach(types, Testing);
        }

        /// <summary>
        /// Run tests
        /// </summary>
        /// <param name="type">Set of tests</param>
        private void Testing(Type type)
        {
            DistributeMethodsByAttributes(type);
            var testsInfo = new ConcurrentQueue<TestInfo>();

            if (!AfterClassOrBeforeClassTesting(testsInfo, methods.BeforeClass))
            {
                ClassQueue.Enqueue(testsInfo);
                return;
            }

            var currentQueue = new ConcurrentQueue<TestInfo>();
            Parallel.ForEach(methods.Tests, (test) => RunTest(type, test, currentQueue));

            if (!AfterClassOrBeforeClassTesting(testsInfo, methods.AfterClass))
            {
                ClassQueue.Enqueue(testsInfo);
                return;
            }

            ClassQueue.Enqueue(currentQueue);
        }

        /// <summary>
        /// Run test
        /// </summary>
        /// <param name="type">Set of tests</param>
        /// <param name="method">Method for testsing</param>
        /// <param name="queue">queue for test info</param>
        private void RunTest(Type type, MethodInfo method, ConcurrentQueue<TestInfo> queue)
        {
            var property = (Test)Attribute.GetCustomAttribute(method, typeof(Test));
            if (property.Ignore != null)
            {
                queue.Enqueue(new TestInfo(method.Name, "Ignored", property.Ignore, 0));
                return;
            }
            var instance = Activator.CreateInstance(type);

            var exceptionBefore = AfterOrBeforeTesting(type, methods.Before);
            if (exceptionBefore != null)
            {
                queue.Enqueue(new TestInfo(method.Name, "Failed", exceptionBefore, 0));
                return;
            }

            var stopWatch = new Stopwatch();
            var result = "Passed";
            try
            {
                stopWatch.Start();
                method.Invoke(instance, null);
                stopWatch.Stop();
            }
            catch (Exception e)
            {
                stopWatch.Stop();
                if (e.InnerException.GetType() != property.Expected)
                {
                    result = "Failed";
                }
                queue.Enqueue(new TestInfo(method.Name, result, e.Message, stopWatch.ElapsedMilliseconds));
                return;
            }

            if (property.Expected != null)
            {
                result = "Failed";
                queue.Enqueue(new TestInfo(method.Name, result, $"Test did not throw an exception: {property.Expected.ToString()}", stopWatch.ElapsedMilliseconds));
                return;
            }

            var exceptionAfter = AfterOrBeforeTesting(type, methods.After);
            if (exceptionAfter != null)
            {
                queue.Enqueue(new TestInfo(method.Name, "Failed", exceptionAfter, 0));
                return;
            }

            queue.Enqueue(new TestInfo(method.Name, result, null, stopWatch.ElapsedMilliseconds));
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
        private bool AfterClassOrBeforeClassTesting(ConcurrentQueue<TestInfo> testsInfo, List<MethodInfo> methods)
        {
            foreach (var method in methods)
            {
                try
                {
                    method.Invoke(null, null);
                }
                catch (Exception e)
                {
                    foreach (var test in this.methods.Tests)
                    {
                        testsInfo.Enqueue(new TestInfo(test.Name, "Failed", e.Message, 0));
                    }
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Distribute methods by attributes.
        /// </summary>
        /// <param name="type">Set of tests</param>
        private void DistributeMethodsByAttributes(Type type)
        {
            methods = new MethodLists();

            foreach (var method in type.GetMethods())
            {
                foreach (var attribute in Attribute.GetCustomAttributes(method))
                {
                    ValidationOfTestForCorrectness(method, attribute);

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

        /// <summary>
        /// Validation test for correctness. 
        /// </summary>
        /// <param name="test">Test</param>
        /// <param name="attribute">Attribute of test</param>
        private void ValidationOfTestForCorrectness(MethodInfo test, Attribute attribute)
        {
            var attributeName = attribute.GetType().Name;
            if (attributeName == typeof(Before).Name || attributeName == typeof(After).Name || attributeName == typeof(Test).Name)
            {
                if (test.ReturnType.Name != "Void")
                {
                    throw new InvalidOperationException("Methods with Test, After and Before attributes mustn't have return type.");
                }

                if (test.GetParameters().Length != 0)
                {
                    throw new InvalidOperationException("Methods with Test, After and Before attributes shouldn't have parameters.");
                }

                if (test.IsStatic)
                {
                    throw new InvalidOperationException("Methods with Test, After and Before attributes mustn't be static.");
                }
            }

            if (attributeName == typeof(BeforeClass).Name || attributeName == typeof(AfterClass).Name)
            {
                if (!test.IsStatic)
                {
                    throw new InvalidOperationException("Methods with BeforeClass and AfterClass attributes must be static.");
                }
            }
        }
    }
}