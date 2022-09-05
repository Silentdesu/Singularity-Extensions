using Newtonsoft.Json;
using System;
using UnityEngine;

namespace SingularityLab.Runtime.DataStructures
{
    [Serializable]
    public struct Vector3Simple
    {
        public float X;
        public float Y;
        public float Z;

        [JsonConstructor]
        public Vector3Simple(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3Simple(Vector3 pos)
        {
            X = pos.x;
            Y = pos.y;
            Z = pos.z;
        }

        public void SetPosition(Vector3 newPosition)
        {
            X = newPosition.x;
            Y = newPosition.y;
            Z = newPosition.z;
        }

        public static Vector3Simple zero => new Vector3Simple(0, 0, 0);
        public static Vector3Simple one => new Vector3Simple(1, 1, 1);

        public static Vector3Simple operator +(Vector3Simple a, Vector3Simple b)
        {
            return new Vector3Simple(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Vector3Simple operator *(Vector3Simple v1, Vector3Simple v2)
        {
            return new Vector3Simple(v1.X * v2.X, v1.Y * v2.Y, v1.Z * v2.Z);
        }

        public static Vector3Simple operator *(Vector3Simple v1, float v2)
        {
            return new Vector3Simple(v1.X * v2, v1.Y * v2, v1.Z * v2);
        }

        public override string ToString()
        {
            return $"{X}, {Y}, {Z}";
        }
    }
}