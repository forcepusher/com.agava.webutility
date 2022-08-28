using UnityEngine;

namespace Agava.WebUtility.Samples
{
    public class PlaytestingCanvas : MonoBehaviour
    {
        private void OnEnable()
        {
            WebApplication.InBackgroundChange += OnInBackgroundChange;
        }

        private void OnDisable()
        {
            WebApplication.InBackgroundChange -= OnInBackgroundChange;
        }

        private void OnInBackgroundChange(bool inBackground)
        {
            AudioListener.volume = inBackground ? 0f : 1f;
        }
    }
}
