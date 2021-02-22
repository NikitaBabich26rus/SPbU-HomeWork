using System;

namespace Attributes
{
    /// <summary>
    /// Attribute to run methods after tests class
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class AfterClass : Attribute
    {

    }
}
