class WebApp {
    /**
     * Should have all the classes and instances
     * Adds Auth header
     * @param currentInspectorId
     */
    constructor(currentInspectorId = null) {
        if (!currentInspectorId) {
            currentInspectorId = getCookie('user_id');
            if (!isNaN(currentInspectorId)) {
                checkIfLoggedIn();
            }
        }
        this._CurrentInspectorId = currentInspectorId;
        $.ajaxSetup({
            headers: {
                'Authorization': `Bearer ${getCookie("jwt_token")}`,
            },
        });

        this.setInspectorByAccount(currentInspectorId);

    }

    get CurrentInspectorId() {
        return this._CurrentInspectorId;
    }

    set CurrentInspectorId(value) {
        this._CurrentInspectorId = value;
    }

    checkIfInspectionIsDone(inspection_id) {
        let cookie = getCookie("done");
        cookie = JSON.parse(cookie);
        let inspector_cookie = null;
        try {
            inspector_cookie = cookie[this.CurrentInspectorId.toString()];

        } catch (e) {
            let inspector_cookie = null;
        }

        if (!cookie || !inspector_cookie) {
            return false;
        } else {
            if (cookie[this.CurrentInspectorId.toString()].includes(inspection_id)) {
                return true;
            }
        }
    }

    saveInspectionFinishedToCookie(inspection_id) {
        let cookie = getCookie("done");
        if (cookie) {
            cookie = JSON.parse(cookie);
            let inspector_cookie = cookie[this.CurrentInspectorId.toString()];
            if (!inspector_cookie) {
                cookie[this.CurrentInspectorId] = `{[${inspection_id}]}`;

            } else {
                let length = cookie[this.CurrentInspectorId.toString()].length;
                cookie[this.CurrentInspectorId.toString()][length] = inspection_id;
                console.log(cookie);
            }
            eraseCookie("done");
            setCookie("done", JSON.stringify(cookie), 99);
        } else {
            let json = `{"${this.CurrentInspectorId}": [${inspection_id.toString()}]}`;
            cookie = JSON.parse(json);
            setCookie("done", JSON.stringify(cookie), 99);
        }
        return;
    }

    postAnswer(answer, callBack) {
        /**
         * Sends post request to target, receives response
         *
         * @param url Target URL
         * @param auth Authentication details
         * @param cb CallBack method
         */
        $.ajax({
            type: "POST",
            accepts: "application/json",
            contentType: "application/json",
            url: '/api/Answer',
            dataType: "json",
            data: JSON.stringify(answer),
            success: function (data) {
                return callBack(data);
            },
            error: function (error) {
                console.log(answer);
                return callBack(error);
            }
        });
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
                console.log(data);
                return callBack(data);
            }
        });
    }

    getFinishedInspections(callBack) {
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
                console.log(data);
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

    saveScheduledItem(scheduleModel, callBack) {
        /**
         * Sends post request to target, receives response
         *
         * @param url Target URL
         * @param auth Authentication details
         * @param cb CallBack method
         */
        $.ajax({
            type: "POST",
            accepts: "application/json",
            contentType: "application/json",
            url: '/Users/schedule/',
            dataType: "json",
            data: JSON.stringify(scheduleModel.convert),
            success: function (data) {
                return callBack(data);
            },
            error: function (error) {
                console.log("Error posting model: ");
                console.log(scheduleModel);
                return callBack(error);
            }
        });
    }
    
    setInspectorByAccount(id) {
        $.ajax({
            type: 'GET',
            url: `/Users/${id}`,
            success: function (data) {
                // setCookie("inspector", data[0], 7);
                setCookie("inspector", data.inspectors[0].id, 7);
            },
            error: function (error) {
                console.log(error);
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

    getQuestionnaireByInspection(InspectionId, callBack) {
        /**
         * Sends get request to target, receives response
         *
         * @param url Target URL
         * @param auth Authentication details
         * @param cb CallBack method
         */
        $.ajax({
            type: 'GET',
            url: `/api/Questionnaire/inspection/${InspectionId}`,
            success: function (data) {
                return callBack(data);
            }
        });
    }
}

