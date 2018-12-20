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
        this._get_questions(questions => {
            Question._build_question_list(questions);
        })
    }

    static _build_question_list(questions) {
        let target_ul = $('#QuestionsUl');
        console.dir(questions);
        for (let index in questions) {
            target_ul.append(Question._build_internal_ul(questions[index]));
        }
    }

    static _build_internal_ul(question) {
        return $(`<ul id=${question.id}>`)
            .append(
                $('<li>')
                    .append(
                        question.content
                    ),
                $('<li>')
                    .append(
                        Question._build_multiple_choice_answers(question.id, question.options)
                    )
            )
    }

    static _build_multiple_choice_answers(question_id, options) {
        let fields = options.split(';');
        console.dir(fields);

        let content = $(`<ul id="answers_${question_id}">`);
        if (!fields) {
            $('<li>').append(
                'No options available'
            )
        } else {
            let form = $(`<form id="form_${question_id}">`);
            for (let option in fields) {

                let temp = $('<li>').append(
                    '<input type="radio" id="inputd-' + question_id + '" name="group1"/><span id="input-' + question_id + '">' + fields[option] + '</span>'
                );
                form.append(temp);
            }

            content.append(form);
        }

        return content;
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