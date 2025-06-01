const deviceLibrary = {

  // Class definition.

  $device: {
    isMobileDevice: undefined,

    getIsMobile: function () {
      if (device.isMobileDevice === undefined)
        device.isMobileDevice = navigator.maxTouchPoints > 0 && !!document.createElement('canvas').getContext('webgl').getExtension('WEBGL_compressed_texture_etc2');

      return device.isMobileDevice;
    },
  },

  // External C# calls.

  GetDeviceIsMobile: function () {
    return device.getIsMobile();
  },
}

autoAddDeps(deviceLibrary, '$device');
mergeInto(LibraryManager.library, deviceLibrary);
