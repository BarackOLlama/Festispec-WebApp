class Question {
    constructor(inspectionId = null) {
        if (!inspectionId) {
            inspectionId = getCookie('inspection');
            if (!inspectionId) {
                window.location.href = 'index.html';
            }
        }
        this.inspectionId = inspectionId;
        this.WebApp = new WebApp();
    }

    render_question_data() {
        this.WebApp.getQuestionnaireByInspection(this.inspectionId, questionnaire => {
            console.log(questionnaire);
        })
    }
}

$(document).ready(function () {
    // For every page a new javascript view (js/views/index.js at the moment)
    // init the class
    let page = new Question();
    // Run method to modify this page with the data retrieved from the API
    page.render_question_data();
});