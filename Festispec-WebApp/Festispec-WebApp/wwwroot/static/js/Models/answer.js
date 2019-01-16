class Answer {
    get inspectorId() {
        return this._inspector_id;
    }

    set inspectorId(value) {
        this._inspector_id = value;
    }

    get answerContent() {
        return this._answerContent;
    }

    set answerContent(value) {
        this._answerContent = value;
    }

    get questionId() {
        return this._questionId;
    }

    set questionId(value) {
        this._questionId = value;
    }

    toJson() {
        return {
            'Content': this.answerContent,
            'QuestionId': this.questionId,
            'InspectorId': this.inspectorId,
        }
    }

    constructor(questionId, answerContent, inspectorId) {
        this._questionId = questionId;
        this._answerContent = answerContent;
        this._inspector_id = inspectorId;

    }
}