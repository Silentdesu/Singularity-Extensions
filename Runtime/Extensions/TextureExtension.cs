using UnityEngine;
using UnityEngine.UI;

namespace SingularityLab.Runtime.Extensions
{
    public static partial class TextureExtension
    {
        public static void SetTexture(this Image image, Texture texture, bool preserveAspect = false)
        {
            Rect newRect = new Rect(0.0f, 0.0f, texture.width, texture.height);
            Vector2 pivot = new Vector2(0.5f, 0.5f);

            image.sprite = Sprite.Create((Texture2D) texture, newRect, pivot, 100.0f);
            image.preserveAspect = preserveAspect;
        }

        public static Texture2D ConvertSpriteToTexture(this Sprite sprite)
        {
            var convertedSprite = new Texture2D((int) sprite.rect.width, (int) sprite.rect.height);
            var pixels = sprite.texture.GetPixels((int) sprite.textureRect.x,
                (int) sprite.textureRect.y,
                (int) sprite.textureRect.width,
                (int) sprite.textureRect.height);
            convertedSprite.SetPixels(pixels);
            convertedSprite.Apply();

            return convertedSprite;
        }
    }
}