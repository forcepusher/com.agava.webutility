const library = {
    
    // Class definition.
  
    $webApplication: {
        setInBackgroundChangeCallback: function (callbackPtr) {
            document.addEventListener('visibilitychange', function () {
                dynCall('vi', callbackPtr, [document.hidden]);
            });
        },

        getInBackground: function () {
            return document.hidden;
        },
    },

    // External C# calls.

    SetWebApplicationInBackgroundChangeCallback: function (callbackPtr) {
        webApplication.setInBackgroundChangeCallback(callbackPtr);
    },

    GetWebApplicationInBackground: function () {
        return webApplication.getInBackground();
    },
}

autoAddDeps(library, '$webApplication');
mergeInto(LibraryManager.library, library);
