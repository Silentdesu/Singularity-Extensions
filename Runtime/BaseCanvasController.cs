using Sirenix.OdinInspector;
using UnityEngine;

namespace Singularity.Scripts.Utils
{
    public abstract class BaseCanvasController : SerializedMonoBehaviour
    {
        [SerializeField] protected CanvasAppearPosition _canvasPosition = CanvasAppearPosition.None;

        public virtual void ShowInstant()
        {
            gameObject.SetActive(true);
        }

        public virtual void HideInstant()
        {
            gameObject.SetActive(false);
        }
    }

    public enum CanvasAppearPosition
    {
        None,
        Left,
        Right,
        Up,
        Down
    }
}