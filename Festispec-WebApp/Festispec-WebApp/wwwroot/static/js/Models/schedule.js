class ScheduleModel {
    constructor(date, inspectorId) {
        this._date = date;
        this._inspector_id = inspectorId;

    }

    get inspectorId() {
        return this._inspector_id;
    }

    set inspectorId(value) {
        this._inspector_id = value;
    }

    get Date() {
        return this._date;
    }

    set setDate(value) {
        this._date = value;
    }

    get convert() {
        let list = {
            'Date': this.Date,
            'InspectorId': this.inspectorId
        };

        return (list);
    }
}