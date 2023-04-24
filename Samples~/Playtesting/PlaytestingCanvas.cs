using UnityEngine;
using UnityEngine.UI;

namespace Agava.WebUtility.Samples
{
    public class PlaytestingCanvas : MonoBehaviour
    {
        [SerializeField]
        private Text _adBlockStatusText;
        [SerializeField]
        private Text _isMobileText;

        private void OnEnable()
        {
            WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;
        }

        private void OnDisable()
        {
            WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;
        }

        private void Update()
        {
            _adBlockStatusText.color = AdBlock.Enabled ? Color.red : Color.green;
            _adBlockStatusText.text = $"{nameof(AdBlock)}.{nameof(AdBlock.Enabled)} = {AdBlock.Enabled}";
            _isMobileText.text = $"{nameof(Device)}.{nameof(Device.IsMobile)} = {Device.IsMobile}";
        }

        private void OnInBackgroundChange(bool inBackground)
        {
            // Use both pause and volume muting methods at the same time.
            // They're both broken in Web, but work perfect together. Trust me on this.
            AudioListener.pause = inBackground;
            AudioListener.volume = inBackground ? 0f : 1f;
        }
    }
}
