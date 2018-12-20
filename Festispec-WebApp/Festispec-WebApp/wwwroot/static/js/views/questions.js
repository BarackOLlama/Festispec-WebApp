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
        this._get_questions(function (questions) {
            console.log(questions);
        })
    }

    build_question_list(questions, cb) {
        let target_ul = $('#QuestionsUl');
        
        for (let question in questions) {
            target_ul.append();
        }
    }
    
    _build_internal_ul(question) {
        
    }

    _get_questions(cb) {
        this.WebApp.getQuestionnaireByInspection(this.inspectionId, questionnaire => {
            if (questionnaire) {
                questionnaire = questionnaire.questions;
            }
            return cb(questionnaire);
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