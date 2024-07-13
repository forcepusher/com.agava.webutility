const clipboardLibrary = {

  // Class definition.

  $clipboard: {
    write: function (clipboardText, successCallbackPtr, errorCallbackPtr) {
      if (!navigator.clipboard) {
        clipboard.invokeErrorCallback(new Error("clipboard is available only in a secure context"), errorCallbackPtr);
        return;
      }

      navigator.clipboard.writeText(clipboardText).then(function () {
        dynCall('v', successCallbackPtr, []);
      }).catch(function (error) {
        clipboard.invokeErrorCallback(error, errorCallbackPtr);
      });
    },

    read: function (successCallbackPtr, errorCallbackPtr) {
      if (!navigator.clipboard) {
        clipboard.invokeErrorCallback(new Error("clipboard is available only in a secure context"), errorCallbackPtr);
        return;
      }

      navigator.clipboard.readText().then(function (clipboardText) {
        const clipboardTextUnmanagedStringPtr = clipboard.allocateUnmanagedString(clipboardText);
        dynCall('vi', successCallbackPtr, [clipboardTextUnmanagedStringPtr]);
        _free(clipboardTextUnmanagedStringPtr);
      }).catch(function (error) {
        clipboard.invokeErrorCallback(error, errorCallbackPtr);
      });
    },

    invokeErrorCallback: function (error, errorCallbackPtr) {
      var errorMessage;
      if (error instanceof Error) {
        errorMessage = error.message;
      } else {
        errorMessage = 'browser API thrown an unexpected type as error: ' + JSON.stringify(error);
      }

      const errorUnmanagedStringPtr = clipboard.allocateUnmanagedString(errorMessage);
      dynCall('vi', errorCallbackPtr, [errorUnmanagedStringPtr]);
      _free(errorUnmanagedStringPtr);
    },

    allocateUnmanagedString: function (string) {
      const stringBufferSize = lengthBytesUTF8(string) + 1;
      const stringBufferPtr = _malloc(stringBufferSize);
      stringToUTF8(string, stringBufferPtr, stringBufferSize);
      return stringBufferPtr;
    },
  },

  // External C# calls.

  ClipboardWrite: function (clipboardTextPtr, successCallbackPtr, errorCallbackPtr) {
    const clipboardText = UTF8ToString(clipboardTextPtr);

    clipboard.write(clipboardText, successCallbackPtr, errorCallbackPtr);
  },

  ClipboardRead: function (successCallbackPtr, errorCallbackPtr) {
    return clipboard.read(successCallbackPtr, errorCallbackPtr);
  },
}

autoAddDeps(clipboardLibrary, '$clipboard');
mergeInto(LibraryManager.library, clipboardLibrary);
