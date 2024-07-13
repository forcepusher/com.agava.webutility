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
        [SerializeField]
        private InputField _clipboardInputField;

        private void OnEnable()
        {
            WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;
        }

        private void OnDisable()
        {
            WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;
        }

        private void Awake()
        {
            WebApplication.CallbackLogging = true;
        }

        private void Update()
        {
            if (!WebApplication.IsRunningOnWebGL)
                return;

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

        public void OnCopyToClipboardButtonClick()
        {
            Clipboard.Write(_clipboardInputField.text);
        }

        public void OnPasteFromClipboardButtonClick()
        {
            Clipboard.Read((text) => _clipboardInputField.text = text);
        }
    }
}
