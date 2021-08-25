using System.Collections.Concurrent;

namespace MyNUnitRunner
{
    /// <summary>
    /// Info about assembly.
    /// </summary>
    public class AssemblyInfo
    {
        /// <summary>
        /// Assembly name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Assembly tests.
        /// </summary>
        public ConcurrentQueue<TestInfo> Tests { get; set; } = new();
    }
}
