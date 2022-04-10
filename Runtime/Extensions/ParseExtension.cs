using System;

namespace SingularityLab.Runtime.Extensions
{
    public static partial class ParseExtension
    {
        /// <summary>
        /// Parse from string to enum
        /// </summary>
        /// <param name="value">parsed string</param>
        private static T ParseEnum<T>(in string value)
        {
            return (T) Enum.Parse(typeof(T), value, true);
        }
    }
}