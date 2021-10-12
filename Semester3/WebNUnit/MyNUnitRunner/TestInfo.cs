using System;

namespace MyNUnitRunner
{
    /// <summary>
    /// Tests information class
    /// </summary>
    public class TestInfo
    {
        /// <summary>
        /// Test result
        /// </summary>
        public string Result { get; }

        /// <summary>
        /// Test name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Reason of ignore
        /// </summary>
        public string IgnoreReason { get; }

        /// <summary>
        /// Test run time
        /// </summary>
        public TimeSpan Time { get; }

        /// <summary>
        /// Test info constructor
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="result">Result</param>
        /// <param name="ignoreReason">Reason of ignore</param>
        /// <param name="time">Time</param>
        public TestInfo(string name, string result, string ignoreReason, TimeSpan time)
        {
            this.Result = result;
            this.Name = name;
            this.IgnoreReason = ignoreReason;
            this.Time = time;
        }
    }
}
