using AOT;
using System;
using System.Runtime.InteropServices;
#if UNITY_WEBGL && !UNITY_EDITOR
using UnityEngine;
using UnityEngine.Scripting;

[assembly: AlwaysLinkAssembly]
#endif
namespace Agava.WebUtility
{
    public static class WebApplication
    {
        /// <remarks>
        /// Triggers way faster than <see cref="InBackground"/>,<br/>
        /// but don't forget to unsubscribe from this event.
        /// </remarks>
        public static event Action<bool> InBackgroundChangeEvent;

        /// <remarks>
        /// Triggers with a slight delay when going into background.<br/>
        /// Use <see cref="InBackgroundChangeEvent"/> when a faster result is needed.
        /// </remarks>
        public static bool InBackground => GetWebApplicationInBackground();

        [DllImport("__Internal")]
        private static extern bool GetWebApplicationInBackground();

        [DllImport("__Internal")]
        private static extern bool WebApplicationInitialize(Action<bool> onInBackgroundChange);

#if UNITY_WEBGL && !UNITY_EDITOR
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
#endif
        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Unity InitializeOnLoadMethod")]
        private static void Initialize()
        {
            WebApplicationInitialize(OnInBackgroundChange);
        }

        [MonoPInvokeCallback(typeof(Action<bool>))]
        private static void OnInBackgroundChange(bool hidden)
        {
            InBackgroundChangeEvent?.Invoke(hidden);
        }
    }
}
