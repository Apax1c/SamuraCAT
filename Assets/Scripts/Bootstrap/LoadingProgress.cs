using UnityEngine;
using UnityEngine.UI;

namespace IslandConstructors.Bootstrap
{
    public class LoadingProgress : MonoBehaviour
    {
        [SerializeField] private Slider loadingProgressBar;

        private float progressValue = 0f;
        private float progressMaxValue = 1f;

        private void Awake()
        {
            loadingProgressBar.value = progressValue;
            loadingProgressBar.maxValue = progressMaxValue;
        }

        public void SetProgressValue(int initializingLeft)
        {
            if (initializingLeft < 1)
            {
                return;
            }
            else
            {
                loadingProgressBar.value = Mathf.Lerp(progressValue, progressMaxValue / initializingLeft, 1f);
                progressValue = loadingProgressBar.value;
            }
        }
    }
}