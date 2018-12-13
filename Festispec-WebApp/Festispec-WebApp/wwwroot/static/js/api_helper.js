class WebApp {
    /**
     * Should have all the classes and instances
     * @param currentInspectorId
     */
    constructor(currentInspectorId = null) {
        if(!currentInspectorId) {
            currentInspectorId = getCookie('user_id');
            if(!isNaN(currentInspectorId)) {
                checkIfLoggedIn();
            }
        }
        this._CurrentInspectorId = currentInspectorId;
        $.ajaxSetup({
            headers: {
                'Authorization': $.cookie('jwt_token')
            }
        })

    }

    get CurrentInspectorId() {
        return this._CurrentInspectorId;
    }

    set CurrentInspectorId(value) {
        this._CurrentInspectorId = value;
    }

    getInspectors() {
        /**
         * Sends get request to target, receives response
         *
         * @param url Target URL
         * @param auth Authentication details
         * @param cb CallBack method
         */
        $.ajax({
            type: 'GET',
            url: '/api/Inspections/',
            success: function (data) {
                console.log(data)
            }
        });

    }
}

let webApp = new WebApp(1);
