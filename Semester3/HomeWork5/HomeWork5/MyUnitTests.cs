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
    public class MyUnitTests
    {

        MethodLists methods;

        public ConcurrentQueue<TestInfo> TestsInfo { get; private set; }

        public MyUnitTests(string path)
        {
            var types = Directory.GetFiles(path, "*.dll", SearchOption.AllDirectories).Select(Assembly.LoadFrom).ToHashSet().SelectMany(a => a.ExportedTypes);
            TestsInfo = new ConcurrentQueue<TestInfo>();
            Parallel.ForEach(types, Testing);
        }

        private void Testing(Type type)
        {
            ParseFileWithTests(type);

            if (!AfterClassOrBeforeClassTesting(type, methods.BeforeClass))
            {
                return;
            }

            var currentQueue = new ConcurrentQueue<TestInfo>();
            foreach (var test in methods.Tests)
            {
                RunTests(type, test, queue);
            }

            if (!AfterClassOrBeforeClassTesting(type, methods.AfterClass))
            {
                return;
            }

            TestsInfo = currentQueue;

        }

        private void RunTests(Type type, MethodInfo method, ConcurrentQueue<TestInfo> queue)
        {
            var instance = Activator.CreateInstance(type);

            if (!AfterClassOrBeforeClassTesting(type, methods.After))
            {
                queue.Enqueue()
            }

            foreach (var test in methods.Tests)
            {
                RunTest(type, test, queue);
            }

            if (!AfterClassOrBeforeClassTesting(type, methods.Before))
            {
            }      
        }

        private void RunTest(Type type, MethodInfo method, ConcurrentQueue<TestInfo> queue)
        {
            var instance = Activator.CreateInstance(type);
            var stopWatch = new Stopwatch();
            string ignoreReason = null;
            var result = "Passed";
            try
            {
                stopWatch.Start();
                method.Invoke(instance, null);
                stopWatch.Stop();
            }
            catch (Exception e)
            {
                queue.Enqueue(new TestInfo(method.Name, "Failed", e.Message, stopWatch.ElapsedMilliseconds));
                return;
            }
            queue.Enqueue(new TestInfo(method.Name, result, null, stopWatch.ElapsedMilliseconds));
        }

        private bool AfterClassOrBeforeClassTesting(Type type, List<MethodInfo> methods)
        {
            var instance = Activator.CreateInstance(type);

            foreach (var method in methods)
            {
                try
                {
                    method.Invoke(instance, null);
                }
                catch (Exception e)
                {
                    foreach (var test in this.methods.Tests)
                    {
                        TestsInfo.Enqueue(new TestInfo(test.Name, "Failed", e.Message, 0));
                        return false;
                    }
                }
            }
            return true;
        }

        private void ParseFileWithTests(Type type)
        {
            methods = new MethodLists();

            foreach (var method in type.GetMethods())
            {
                foreach (var attribute in Attribute.GetCustomAttributes(method))
                {
                    switch (attribute.GetType().Name)
                    {
                        case nameof(Before):
                            methods.Before.Add(method);
                            break;

                        case nameof(BeforeClass):
                            methods.BeforeClass.Add(method);
                            break;

                        case nameof(Test):
                            methods.Tests.Add(method);
                            break;

                        case nameof(AfterClass):
                            methods.AfterClass.Add(method);
                            break;

                        case nameof(After):
                            methods.After.Add(method);
                            break;
                    }
                }
            }
        }
    }
}
