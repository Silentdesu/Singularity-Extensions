namespace SingularityLab.Runtime.Extensions
{
    using SingularityLab.Runtime.DataStructures;
    using System.Runtime.CompilerServices;
    using UnityEngine;

    public static class Vector3SimpleExtension
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Simple ToVector3Simple(this Vector3 vector3)
            => new Vector3Simple(vector3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 ToVector3(this Vector3Simple vector3Simple)
            => new Vector3(vector3Simple.X, vector3Simple.Y, vector3Simple.Z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TransformSimple ToSimple(this Transform transform)
        {
            return new TransformSimple(transform.position.ToVector3Simple(),
                transform.eulerAngles.ToVector3Simple(),
                transform.localScale.ToVector3Simple());
        }
    }
}