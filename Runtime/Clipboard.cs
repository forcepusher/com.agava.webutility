using AOT;
using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Agava.WebUtility
{
    public static class Clipboard
    {
        private static Action s_onWriteSuccessCallback;
        private static Action<string> s_onWriteErrorCallback;

        private static Action<string> s_onReadSuccessCallback;
        private static Action<string> s_onReadErrorCallback;

        #region Write
        public static void Write(string text, Action onSuccessCallback = null, Action<string> onErrorCallback = null)
        {
            s_onWriteSuccessCallback = onSuccessCallback;
            s_onWriteErrorCallback = onErrorCallback;

            ClipboardWrite(text, OnWriteSuccessCallback, OnWriteErrorCallback);
        }

        [DllImport("__Internal")]
        private static extern void ClipboardWrite(string text, Action successCallback, Action<string> errorCallback);

        [MonoPInvokeCallback(typeof(Action))]
        private static void OnWriteSuccessCallback()
        {
            if (WebApplication.CallbackLogging)
                Debug.Log($"{nameof(Clipboard)}.{nameof(OnWriteSuccessCallback)} invoked");

            s_onWriteSuccessCallback?.Invoke();
        }

        [MonoPInvokeCallback(typeof(Action<string>))]
        private static void OnWriteErrorCallback(string errorMessage)
        {
            if (WebApplication.CallbackLogging)
                Debug.Log($"{nameof(Clipboard)}.{nameof(OnWriteErrorCallback)} invoked, {nameof(errorMessage)} = {errorMessage}");

            s_onWriteErrorCallback?.Invoke(errorMessage);
        }
        #endregion

        #region Read
        public static void Read(Action<string> onSuccessCallback, Action<string> onErrorCallback = null)
        {
            s_onReadSuccessCallback = onSuccessCallback;
            s_onReadErrorCallback = onErrorCallback;

            ClipboardRead(OnReadSuccessCallback, OnReadErrorCallback);
        }

        [DllImport("__Internal")]
        private static extern void ClipboardRead(Action<string> successCallback, Action<string> errorCallback);

        [MonoPInvokeCallback(typeof(Action<string>))]
        private static void OnReadSuccessCallback(string text)
        {
            if (WebApplication.CallbackLogging)
                Debug.Log($"{nameof(Clipboard)}.{nameof(OnReadSuccessCallback)} invoked, {nameof(text)} = {text}");

            s_onReadSuccessCallback?.Invoke(text);
        }

        [MonoPInvokeCallback(typeof(Action<string>))]
        private static void OnReadErrorCallback(string errorMessage)
        {
            if (WebApplication.CallbackLogging)
                Debug.Log($"{nameof(Clipboard)}.{nameof(OnReadErrorCallback)} invoked, {nameof(errorMessage)} = {errorMessage}");

            s_onReadErrorCallback?.Invoke(errorMessage);
        }
        #endregion
    }
}
