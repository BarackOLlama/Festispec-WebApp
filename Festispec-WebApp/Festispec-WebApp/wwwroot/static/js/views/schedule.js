class Schedule {
    constructor() {
        this.WebApp = new WebApp();
    }
    
    load() {
        
    }
}

$(document).ready(function () {
    // For every page a new javascript view (js/views/index.js at the moment)
    // init the class
    let page = new Schedule();
    // Run method to modify this page with the data retrieved from the API
    page.load();
});