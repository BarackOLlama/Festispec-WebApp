class Answer {
    get inspectorId() {
        return this._inspector_id;
    }

    set inspectorId(value) {
        this._inspector_id = value;
    }

    get getAnswerContent() {
        return this._answerContent;
    }

    set setAnswerContent(value) {
        this._answerContent = value;
    }

    get questionId() {
        return this._questionId;
    }

    set questionId(value) {
        this._questionId = value;
    }

    get convert() {
        let list = [{
            'Id': 1,
            'Content': this._answerContent,
            'QuestionId': this._questionId,
            'InspectorId': this._inspector_id
        }];
        
        return JSON.stringify(list);
    }

    constructor(questionId, answerContent, inspectorId) {
        this._questionId = questionId;
        this._answerContent = answerContent;
        this._inspector_id = inspectorId;

    }
}