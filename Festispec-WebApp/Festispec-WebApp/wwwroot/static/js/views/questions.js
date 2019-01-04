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
        this.formList = [];
        this.multipleChoiceFormList = [];
    }

    render_question_data() {
        this._get_questions(questions => {
            this._build_question_list(questions);
        })
    }

    _build_question_list(questions) {
        let target_ul = $('#QuestionsUl');
        for (let index in questions) {
            target_ul.append(this._build_internal_ul(questions[index]));
        }
        console.log(JSON.stringify(this.multipleChoiceFormList, null, 4));
    }

    _build_internal_ul(question) {
        return $(`<ul style="list-style: none" id=${question.id}>`)
            .append(
                $('<li>')
                    .append(
                        question.content
                    ),
                $('<li>')
                    .append(
                        this._build_multiple_choice_answers(question.id, question.options)
                    )
            )
    }

    _build_multiple_choice_answers(question_id, options) {
        let fields = options.split(';');
        let content = $(`<ul style="list-style: none" id="answers_${question_id}">`);
        if (!fields) {
            $('<li>').append(
                'No options available')
        } else {
            let form_id = `form_${question_id}`;
            let form = $(`<form id="${form_id}" data-type="multiple">`);
            for (let option in fields) {
                let sliced_option_name = fields[option].split('|')[0];
                let sliced_option_text = fields[option].split('|')[1];
                let item = `<input type="radio" data-type="${sliced_option_name}" id="inputd-${question_id}" name="group_${question_id}"/><span id="input-${question_id}">${sliced_option_text}</span>`;
                let temp = $('<li>').append(
                    item
                );
                form.append(temp);
            }

            content.append(form);
            this.multipleChoiceFormList.push(`group_${question_id}`)
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

    _check_if_forms_are_filled() {
        // Count the multiple choice questions, and compare that to the amount of radio buttons checked to make sure we
        // have enough checked answers.
        
        let amount_of_questions = this.multipleChoiceFormList.length, amount_of_checked_buttons = Question._is_selected();
        if(amount_of_questions !== amount_of_checked_buttons) {
            alert('Please fill out all multiple choice answers.');
        }
 
    }
    
    static _is_selected(){
        let checked_buttons = 0;
        let radios = document.getElementsByTagName('input');
        for (let i = 0; i < radios.length; i++) {
            if (radios[i].type === 'radio' && radios[i].checked) {
                checked_buttons++;
            }
        }
        
        return checked_buttons;
    };
}

$(document).ready(function () {
    // For every page a new javascript view (js/views/questions.js at the moment)
    // init the class
    let page = new Question();
    // Run method to modify this page with the data retrieved from the API
    page.render_question_data();
    let btn = document.getElementById('answerButton');
    btn.addEventListener('click', function () {
        page._check_if_forms_are_filled();
    }.bind(this))
});