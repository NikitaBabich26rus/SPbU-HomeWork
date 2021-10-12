using System;

namespace Atributes
{
    /// <summary>
    /// Attribute to run methods after tests
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class After : Attribute
    {

    }
}
