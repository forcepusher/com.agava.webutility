const library = {
    
    // Class definition.

    $device: {
        getIsMobile: function () {
            const isMobileDevice = /Android|webOS|iPhone|iPad|iPod|BlackBerry|BB|PlayBook|IEMobile|Windows Phone|Kindle|Silk|Opera Mini/i.test(navigator.userAgent);
            return isMobileDevice;
        },
    },

    // External C# calls.

    GetDeviceIsMobile: function () {
        return device.getIsMobile();
    },
}

autoAddDeps(library, '$device');
mergeInto(LibraryManager.library, library);
