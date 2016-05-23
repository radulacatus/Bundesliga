exports.config = {
    framework: 'jasmine',
    seleniumAddress: 'http://localhost:4444/wd/hub',
    specs: ['E2E/Games/AddGameSpecs.js'],
    capabilities: {
        browserName: 'chrome'
    },
    rootElement: '[ng-app="app"]',
    onPrepare: function () {
        browser.driver.manage().window().maximize();
    }
};