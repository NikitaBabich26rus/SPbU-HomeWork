using System;
using System.Collections.Generic;
using System.Text;

namespace Attributes
{
    /// <summary>
    /// Attribute to run methods before class tests
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class BeforeClass: Attribute
    {
    }
}
