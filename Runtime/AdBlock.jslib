const library = {
    
    // Class definition.

    $adBlock: {
        fakeAdBannerIds: [
            'AdHeader',
            'AdContainer',
            'AD_Top',
            'homead',
            'ad-lead'
        ],

        initialize: function () {
            const fakeAdContainer = document.createElement('div');
            fakeAdContainer.innerHTML = adBlock.fakeAdBannerIds.map(function(fakeAdBannerId) {
                return '<div id=' + fakeAdBannerId + '></div>'
            }).join('');
            document.body.appendChild(fakeAdContainer);
        },

        getEnabled: function () {
            return !adBlock.fakeAdBannerIds.every(function(fakeAdBannerId) {
                const fakeAdBannerDiv = document.querySelector('#' + fakeAdBannerId);
                if (fakeAdBannerDiv) { return fakeAdBannerDiv.offsetParent; }

                return null;
            });
        },
    },

    // External C# calls.

    GetAdBlockEnabled: function () {
        return adBlock.getEnabled();
    },

    AdBlockInitialize: function () {
        adBlock.initialize();
    },
}

autoAddDeps(library, '$adBlock');
mergeInto(LibraryManager.library, library);
