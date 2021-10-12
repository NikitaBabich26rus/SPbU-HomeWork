using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace HomeWork5
{
    /// <summary>
    /// Class for parsing methods.
    /// </summary>
    public class MethodLists
    {
        /// <summary>
        /// List for tests with attribute BeforeClass
        /// </summary>
        public List<MethodInfo> BeforeClass { get; set; } = new List<MethodInfo>();

        /// <summary>
        /// List for tests with attribute AfterClass
        /// </summary>
        public List<MethodInfo> AfterClass { get; set; } = new List<MethodInfo>();

        /// <summary>
        /// List for tests with attribute Before
        /// </summary>
        public List<MethodInfo> Before { get; set; } = new List<MethodInfo>();

        /// <summary>
        /// List for tests with attribute After
        /// </summary>
        public List<MethodInfo> After { get; set; } = new List<MethodInfo>();

        /// <summary>
        /// List for tests with attribute Test
        /// </summary>
        public List<MethodInfo> Tests { get; set; } = new List<MethodInfo>();
    }
}
