using UnityEngine;
using UnityEngine.UI;

namespace SingularityLab.Runtime.UI
{
    public class LoadingProgressController : MonoBehaviour
    {
        public static LoadingProgressController Instance;
        [SerializeField] private Image _image;

        private void Awake()
        {
            Instance = this;
        }

        public void SetProgress(float progress)
        {
            _image.fillAmount = progress;
        }
    }
}