using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atributes
{
    /// <summary>
    /// Attribute to run tests
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class Test : Attribute
    {
        /// <summary>
        /// Expected excepton
        /// </summary>
        public Type Expected { get; set; }

        /// <summary>
        /// Ignore test running
        /// </summary>
        public string Ignore { get; set; }
    }
}
