using System.Collections;
using SingularityLab.Runtime.Extensions;
using SingularityLab.Runtime.Singletons;
using TMPro;
using UnityEngine;

namespace SingularityLab.Runtime.UI
{
    public sealed class LoadingScreenController : BaseInstanceDontDestroy<LoadingScreenController>
    {
        [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private BaseProgressBar _baseProgressBar;

        protected override void Awake()
        {
            base.Awake();
            Hide();
        }

        private void Start()
        {
            if (_baseProgressBar != null)
            {
                StartCoroutine(ProgressBarAnimationRoutine());
            }
        }

        private IEnumerator ProgressBarAnimationRoutine()
        {
            while (true)
            {
                float timePassed = 0f;
                float animationTime = 2f;

                int segmentCount = 24;
                float progress = 0f;
                float progressCached = progress;
                float minProgressValue = 0.0f;


                int rotationCounter = 0;
                int rotationTick = 3;

                while (timePassed < 2 * animationTime)
                {
                    timePassed += Time.deltaTime;

                    progress = timePassed / animationTime;

                    progress = minProgressValue + progress * (1 - minProgressValue);

                    progress = Mathf.RoundToInt(progress * segmentCount) / (float) segmentCount;

                    _baseProgressBar.SetValue(progress);

                    if (!Mathf.Approximately(progress, progressCached))
                    {
                        rotationCounter++;

                        if (rotationCounter >= rotationTick)
                        {
                            rotationCounter = 0;
                        }

                        progressCached = progress;
                    }

                    yield return null;
                }

                

            }
        }

        private void EnableGroup()
        {
            _canvasGroup.EnableGroup();
        }

        private void DisableGroup()
        {
            _canvasGroup.DisableGroup();
        }

        public static void SetText(string text)
        {
            if (Instance == null)
            {
                Debug.LogError($"Loading screen is not initialized");
                return;
            }

            Instance.SetProgressText(text);
        }

        public static void Show()
        {
            if (Instance == null)
            {
                Debug.LogError($"Loading screen is not initialized");

                return;
            }

            Instance.EnableGroup();
        }

        public static void Hide()
        {
            if (Instance == null)
            {
                Debug.LogError($"Loading screen is not initialized");

                return;
            }

            Instance.DisableGroup();
        }

        private void SetProgressText(string text)
        {
            _textMeshProUGUI.text = text;
        }
    }
}