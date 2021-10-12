using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebNUnit.Models
{
    /// <summary>
    /// View model for test.
    /// </summary>
    public class TestViewModel
    {
        /// <summary>
        /// Test id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Test result.
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// Test name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Reason of ignore.
        /// </summary>
        public string IgnoreReason { get; set; }

        /// <summary>
        /// Test run time.
        /// </summary>
        public TimeSpan Time { get; set; }

        /// <summary>
        /// Launch time.
        /// </summary>
        public DateTime StartTime { get; set; }
    }
}
