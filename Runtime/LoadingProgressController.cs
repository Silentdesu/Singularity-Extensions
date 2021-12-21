using UnityEngine;
using UnityEngine.UI;

namespace Singularity.Scripts.Utils
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