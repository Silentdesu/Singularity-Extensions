using UnityEngine;

namespace SingularityLab.Runtime.Extensions
{
    public static partial class MeshRendererExtension
    {
        public static Material SetMaterialInstance(this MeshRenderer[] meshRenderers)
        {
            var materialInstance = meshRenderers[0].material;

            foreach (var meshRenderer in meshRenderers)
            {
                meshRenderer.sharedMaterial = materialInstance;
            }

            return materialInstance;
        }
    }
}