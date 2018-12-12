class WebApp {
    /**
     * Should have all the classes and instances 
     * @param currentInspectorId
     */
    constructor(currentInspectorId) {
        this._CurrentInspectorId = currentInspectorId;
        
    }
    get CurrentInspectorId() {
        return this._CurrentInspectorId;
    }

    set CurrentInspectorId(value) {
        this._CurrentInspectorId = value;
    }
    
    getInspectors() {
        
    }
}

let webApp = new WebApp(1);
