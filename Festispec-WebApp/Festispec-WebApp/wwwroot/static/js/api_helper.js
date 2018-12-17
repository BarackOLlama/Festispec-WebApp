class WebApp {
    /**
     * Should have all the classes and instances
     * Adds Auth header
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
                'Authorization': getCookie('jwt_token')
            }
        })

    }

    get CurrentInspectorId() {
        return this._CurrentInspectorId;
    }

    set CurrentInspectorId(value) {
        this._CurrentInspectorId = value;
    }

    getInspectors(callBack) {
        /**
         * Sends get request to target, receives response
         *
         * @param url Target URL
         * @param auth Authentication details
         * @param cb CallBack method
         */
        $.ajax({
            type: 'GET',
            url: '/Users/',
            success: function (data) {
                return callBack(data);
            }
        });
    }
    
    getAllInspections(callBack) {
        /**
         * Sends get request to target, receives response
         *
         * @param url Target URL
         * @param auth Authentication details
         * @param cb CallBack method
         */
        $.ajax({
            type: 'GET',
            url: '/api/inspections/',
            success: function (data) {
                return callBack(data);
            }
        });
    }
    
    getInspections(callBack) {
        /**
         * Sends get request to target, receives response
         *
         * @param url Target URL
         * @param auth Authentication details
         * @param cb CallBack method
         */
        let id = this.CurrentInspectorId;
        $.ajax({
            type: 'GET',
            url: `/api/Inspections/inspector/${id}`,
            success: function (data) {
                return callBack(data);
            }
        });
    }
    getInspection(InspectionId, callBack) {
        /**
         * Sends get request to target, receives response
         *
         * @param url Target URL
         * @param auth Authentication details
         * @param cb CallBack method
         */
        $.ajax({
            type: 'GET',
            url: `/api/Inspections/${id}`,
            success: function (data) {
                return callBack(data);
            }
        });
    }
    
    getQuestionnaire(QuestionnaireId, callBack) {
        /**
         * Sends get request to target, receives response
         *
         * @param url Target URL
         * @param auth Authentication details
         * @param cb CallBack method
         */
        $.ajax({
            type: 'GET',
            url: `/api/Questionnaire/${id}`,
            success: function (data) {
                return callBack(data);
            }
        });
    }
}

