namespace SingularityLab.Runtime.Extensions
{
    using System.Runtime.CompilerServices;

    public static partial class MathXExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Map(float inMin, float inMax, float outMin, float outMax, float value)
        {
            if (value <= inMin)
                return outMin;
            if (value >= inMax)
                return outMax;

            return (outMax - outMin) * ((value - inMin) / (inMax - inMin)) + outMax;
        }
    }
}
