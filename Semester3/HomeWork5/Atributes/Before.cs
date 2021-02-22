using System;
using System.Collections.Generic;
using System.Text;

namespace Attributes
{
    /// <summary>
    /// Attribute to run methods before tests
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class Before: Attribute
    {
    }
}
