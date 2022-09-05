using SingularityLab.Runtime.Extensions;
using System;
using UnityEngine;

namespace SingularityLab.Runtime.DataStructures
{
    [Serializable]
    public struct TransformSimple
    {
        public Vector3Simple position;
        public Vector3Simple rotation;
        public Vector3Simple scale;

        public TransformSimple(Vector3Simple position, Vector3Simple rotation, Vector3Simple scale)
        {
            this.position = position;
            this.rotation = rotation;
            this.scale = scale;
        }

        public TransformSimple(Vector3 position)
        {
            this.position = position.ToVector3Simple();
            this.rotation = Vector3Simple.zero;
            this.scale = Vector3Simple.one;
        }

        public static TransformSimple CreateDefault()
        {
            return new TransformSimple()
            {
                position = Vector3Simple.zero,
                rotation = Vector3Simple.zero,
                scale = Vector3Simple.one,
            };
        }

        public override string ToString()
        {
            return position +
                   $"\n{rotation}" +
                   $"\n{scale}";
        }

    }
}