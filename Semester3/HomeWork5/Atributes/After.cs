using System;
using System.Collections.Generic;
using System.Text;

namespace Attributes
{
    /// <summary>
    /// Attribute to run methods after tests
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class After: Attribute
    {

    }
}
