using System.Runtime.InteropServices;
#if UNITY_WEBGL && !UNITY_EDITOR
using UnityEngine;
#endif

namespace Agava.WebUtility
{
    public static class AdBlock
    {
        /// <returns>
        /// Status of an AdBlock addon in the browser.
        /// </returns>
        public static bool Enabled => GetAdBlockEnabled();

        [DllImport("__Internal")]
        private static extern bool GetAdBlockEnabled();

        [DllImport("__Internal")]
        private static extern bool AdBlockInitialize();

#if UNITY_WEBGL && !UNITY_EDITOR
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
#endif
        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Unity InitializeOnLoadMethod")]
        private static void Initialize()
        {
            AdBlockInitialize();
        }
    }
}
