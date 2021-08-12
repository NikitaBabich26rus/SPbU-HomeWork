using System;

namespace Homework7.Models
{
    public class TestViewModel
    {
        /// <summary>
        /// Test result
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// Test name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Reason of ignore
        /// </summary>
        public string IgnoreReason { get; set; }

        /// <summary>
        /// Test run time
        /// </summary>
        public TimeSpan Time { get; set; }

        /// <summary>
        /// Launch time
        /// </summary>
        public DateTime StartTime { get; set; }
    }
}
