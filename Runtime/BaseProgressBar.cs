using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SingularityLab.Runtime
{
    public abstract class BaseProgressBar : MonoBehaviour
    {
        [FoldoutGroup("ProgressBar")] [SerializeField]
        protected Image _image;

        [FoldoutGroup("ProgressBar")] [SerializeField]
        protected TextMeshProUGUI _text;

        public Image ProgressBarImage => _image;

        public virtual void SetText(string text)
        {
            _text.text = text;
        }

        public virtual void SetValue(float value)
        {
            _image.rectTransform.localScale = new Vector3(Mathf.Clamp(value, 0f, 1f), 1, 1);
        }

        public virtual void SetRotationValue(float degree)
        {
            _image.rectTransform.Rotate(Vector3.forward, degree);
        }
    }
}