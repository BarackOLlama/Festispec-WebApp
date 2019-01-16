class Question {
    constructor(inspectionId = null, HTML_PAGE) {
        if (!inspectionId) {
            inspectionId = getCookie('inspection');
            if (!inspectionId) {
                window.location.href = 'index.html';
            }
        }
        this.inspectorId = getCookie("inspector");
        this.inspectionId = inspectionId;
        this.WebApp = new WebApp();
        this.formList = [];
        this.multipleChoiceFormList = [];
        this.openQuestionFormList = [];
        this.openQuestionTableFormList = [];
        this.multipleChoiceTableFormList = [];

        this.multipleChoiceType = "Multiple Choice vraag";
        this.multipleChoiceTableType = "Multiple Choice Tabelvraag";
        this.openQuestionType = "Open Vraag";
        this.openQuestionTableType = "Open Tabelvraag";

        // Add events (buttons etc)
        new Events(this, HTML_PAGE);
    }

    _save_items_to_db(save) {
        let json_list = {};
    }

    /**
     * Check to make sure the questionnaire is answered as a whole.
     * @private
     */
    _check_if_forms_are_filled() {
        // Count the multiple choice questions, and compare that to the amount of radio buttons checked to make sure we
        // have enough checked answers.
        let multi = this._check_multiple_choice();
        let multi_choice = this._check_multiple_choice_table();
        let open = this._check_open_questions();
        let open_table = this._check_open_question_table();

        if (multi && multi_choice && open && open_table) {
            let multi_answers = this._retrieve_multiple_choice_answers();

        } else {
            let multi_answers = this._retrieve_multiple_choice_answers();
            let open_answers = this._retrieve_open_question_answers();

            for (let answer in multi_answers) {
                console.log(multi_answers[answer].toJSON());
            }
            for (let answer in open_answers) {
                console.log(open_answers[answer].toJSON());
            }
        }
    }

    /**
     * Retrieves all questions of this type.
     * @private
     */
    _retrieve_multiple_choice_answers() {
        let list = this.multipleChoiceFormList;
        let answer_list = [];
        for (let i in list) {
            let group = `${list[i]}`;
            let items = $(`[data-question=${group}]`);
            console.dir(items);

            for (let i in items) {
                if (items[i].checked) {
                    let answer_char = items[i].dataset.type;
                    let answer = new Answer(group, answer_char, this.inspectorId);
                    answer_list.push(answer);
                }
            }
        }

        return answer_list;
    }

    /**
     * Retrieves all questions of this type.
     * @private
     */
    _retrieve_open_question_answers() {
        let list = this.openQuestionFormList;
        let answer_list = [];
        for (let i in list) {
            let item = $(`#inputd-${list[i]}`);
            let answer = new Answer(item[0].dataset.type, item.val(), this.inspectorId);
            answer_list.push(answer);
        }

        return answer_list;
    }
    
    /**
     * Checks if all questions of this type are answered.
     * @private
     */
    _check_multiple_choice() {
        let amount_of_questions = this.multipleChoiceFormList.length,
            amount_of_checked_buttons = Question._is_selected();
        if (amount_of_questions !== amount_of_checked_buttons) {
            alert('Please fill out all multiple choice answers.');
        }

    }

    /**
     * Checks if all questions of this type are answered.
     * @private
     */
    _check_open_questions() {
        let list = this.openQuestionFormList;
        for (let i in list) {
            let item = $(`#${list[i]}`);
            if (!item.val()) {
                Question._add_color(false, item);
            } else {
                Question._add_color(true, item);
            }
        }
    }

    /**
     * Checks if all questions of this type are answered.
     * @private
     */
    _check_multiple_choice_table() {
        let list = this.multipleChoiceTableFormList;
        let accepted = true;
        for (let i in list) {
            for (let j in list[i]) {
                let item = $(`#${list[i][j]}`);
                let value = item.val();
                if (!value) {
                    Question._add_color(false, item);
                    accepted = false;
                } else {
                    Question._add_color(true, item);
                }
            }

            if (!accepted) {
                return false;
            }
        }

        return true;
    }

    /**
     * Checks if all questions of this type are answered.
     * @private
     */
    _check_open_question_table() {
        let list = this.openQuestionTableFormList;
        for (let i in list) {
            for (let j in list[i]) {
                let item = $(`#${list[i][j]}`);
                let value = item.val();
                if (!value) {
                    Question._add_color(false, item);
                } else {
                    Question._add_color(true, item);
                }
            }
        }
    }

    /**
     * Renders all HTML lists into one list we see in the view.
     */
    render_question_data() {
        this._get_questions(questions => {
            this._build_question_list(questions);
        })
    }

    /**
     * Builds all answers into a HTML list
     * @param questions
     * @private
     */
    _build_question_list(questions) {
        let target_ul = $('#QuestionsUl');
        for (let index in questions) {
            target_ul.append(this._build_internal_ul(questions[index]));
        }

    }

    /**
     * Builds question list based on question type, returns valid HTML
     * @param question
     * @returns {*|jQuery|*|*}
     * @private
     */
    _build_internal_ul(question) {
        // console.log(question);

        switch (question.questionType.name) {
            case this.multipleChoiceType:
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
                    );
            case this.openQuestionType:
                return $(`<ul style="list-style: none" id=${question.id}>`)
                    .append(
                        $('<li>')
                            .append(
                                question.content
                            ),
                        $('<li>')
                            .append(
                                this._build_open_question_answer(question.id)
                            )
                    );
            case this.multipleChoiceTableType:
                return $(`<ul style="list-style: none" id=${question.id}>`)
                    .append(
                        $('<li>')
                            .append(
                                question.content
                            ),
                        $('<li>')
                            .append(
                                this._build_open_multi_choice_answer_table(question.id, question.columns, question.options)
                            )
                    );

            case this.openQuestionTableType:
                return $(`<ul style="list-style: none" id=${question.id}>`)
                    .append(
                        $('<li>')
                            .append(
                                question.content
                            ),
                        $('<li>')
                            .append(
                                this._build_open_question_table(question.id, question.columns)
                            )
                    )
        }

    }

    /**
     * Build's an open question and returns valid HTML
     * @param question_id
     * @returns {jQuery.fn.init|jQuery|HTMLElement}
     * @private
     */
    _build_open_question_answer(question_id) {
        let content;
        let form_id = `form_${question_id}`;
        let form = $(`<form id="${form_id}" data-type="multiple">`);
        let item = `<input type="text" autocomplete="off" id="inputd-${question_id}" data-type="${question_id}" name="question" style="margin-bottom:10px" class="form-control col-md-12" placeholder="Tekst hier.."/>`;
        let temp = $('<li>').append(
            item
        );
        form.append(temp);

        content = form;
        this.openQuestionFormList.push(`${question_id}`);


        return content;
    }


    /**
     * Build's a table with multiple choice text questions and returns valid HTML
     * @param question_id
     * @param columns
     * @param options
     * @returns {jQuery.fn.init|jQuery|HTMLElement}
     * @private
     */
    _build_open_multi_choice_answer_table(question_id, columns, options) {
        if (!columns) {
            return;
        }
        let ul = $(`<ul style="list-style: none" id=open_${question_id}>`);

        let fields = options.split(';');
        let available_answers_to_fill = [];
        for (let i = 0; i < fields.length; i++) {
            let option = fields[i].split('|');

            available_answers_to_fill.push(option[0].toLowerCase());
            ul.append(
                $('<li>').append(
                    `${option[0]}: ${option[1]}`
                )
            )
        }

        let rows = columns.split('|');
        let rowCount = rows[0];

        let table = document.createElement("table");
        table.className = "table";
        let row = document.createElement("tr");
        for (let i = 1; i < rows.length; i++) {
            let head = document.createElement("th");

            let content = document.createTextNode(rows[i]);

            head.appendChild(content);
            row.appendChild(head);

        }
        table.appendChild(row);

        for (let i = 0; i < rowCount; i++) {
            let row = document.createElement("tr");
            let question_textboxes = [];
            for (let j = 1; j < rows.length; j++) {
                let input_id = `${question_id}-${i}-${j}`;
                let column = document.createElement("td");
                let textarea = document.createElement('textarea');
                textarea.placeholder = "Text here...";
                textarea.setAttribute('data-name', `${input_id}`);
                textarea.id = input_id;
                textarea.setAttribute('cols', '40');
                textarea.className = "form-control";
                textarea.addEventListener('input', function (t) {
                    if (available_answers_to_fill.includes(t.data.toLowerCase())) {
                        textarea.value = t.data;
                    } else {
                        textarea.value = '';
                    }
                }.bind(this));
                column.appendChild(textarea);
                row.appendChild(column);
                question_textboxes.push(input_id);
            }
            this.multipleChoiceTableFormList.push(question_textboxes);
            table.appendChild(row);
        }
        ul.append(
            $('<li>').append(
                table
            )
        );
        return ul;

    }

    /**
     * Build's a list with open questions and returns valid HTML
     * @param question_id
     * @param columns
     * @returns {*}
     * @private
     */
    _build_open_question_table(question_id, columns) {
        if (!columns) {
            return;
        }
        let rows = columns.split('|');
        let rowCount = rows[0];

        let table = document.createElement("table");
        table.className = "table";
        let row = document.createElement("tr");
        for (let i = 1; i < rows.length; i++) {
            let head = document.createElement("th");

            let content = document.createTextNode(rows[i]);

            head.appendChild(content);
            row.appendChild(head);

        }
        table.appendChild(row);

        for (let i = 0; i < rowCount; i++) {
            let question_textboxes = [];
            let row = document.createElement("tr");
            for (let j = 1; j < rows.length; j++) {
                let input_id = `${question_id}-${i}-${j}`;
                let column = document.createElement("td");
                let textarea = document.createElement('textarea');
                textarea.placeholder = "Text here...";
                textarea.setAttribute('data-name', `${input_id}`);
                textarea.setAttribute('cols', '40');
                textarea.id = input_id;
                textarea.className = "form-control";
                column.appendChild(textarea);
                row.appendChild(column);
                question_textboxes.push(input_id)
            }
            this.openQuestionTableFormList.push(question_textboxes);
            table.appendChild(row);
        }


        return table;
    }

    /**
     * Build's a list with multiple choice questions and returns valid HTML
     * @param question_id
     * @param options
     * @returns {jQuery.fn.init|jQuery|HTMLElement}
     * @private
     */
    _build_multiple_choice_answers(question_id, options) {
        if (!options) {
            return;
        }
        let fields = options.split(';');
        let content = $(`<ul style="list-style: none" id="answers_${question_id}">`);
        if (!fields) {
            $('<li>').append(
                'No options available')
        } else {
            let form_id = `${question_id}`;
            let form = $(`<form id="${form_id}" data-type="multiple">`);
            for (let option in fields) {
                let sliced_option_name = fields[option].split('|')[0];
                let sliced_option_text = fields[option].split('|')[1];
                let item_id = `${question_id}_${sliced_option_name}`;
                let item = `<input type="radio" data-type="${sliced_option_name}" data-question="${question_id}" id="${item_id}" name="group_${question_id}"/><span id="input-${question_id}">${sliced_option_text}</span>`;
                let temp = $('<li>').append(
                    item
                );
                form.append(temp);
            }

            content.append(form);
            this.multipleChoiceFormList.push(`${question_id}`)
        }

        return content;
    }

    /**
     * Returns all the questions from a questionnaire
     * @param cb
     * @private
     */
    _get_questions(cb) {
        this.WebApp.getQuestionnaireByInspection(this.inspectionId, questionnaire => {
            if (questionnaire) {
                questionnaire = questionnaire.questions;
            }
            return cb(questionnaire);
        })
    }


    /**
     * Adds a colored border to an input field
     * @param accepted
     * @param item
     * @private
     */
    static _add_color(accepted, item) {
        if (accepted) {
            $(item).addClass("green-border");
        } else {
            $(item).addClass("red-border");
            $(item).focus();
        }
    }

    /**
     * Counts all the radiobuttons that are selected, returns the value
     * Match the value with the amount of radiobutton questions, and we know
     * if all the radio button forms are filled.
     * @returns {number}
     * @private
     */
    static _is_selected() {
        let checked_buttons = 0;
        let radios = document.getElementsByTagName('input');
        for (let i = 0; i < radios.length; i++) {
            if (radios[i].type === 'radio' && radios[i].checked) {
                checked_buttons++;
            }
        }

        return checked_buttons;
    }
}

class Events {
    constructor(page, self) {
        this.setConfirmButton(page, self)
    }

    /**
     * Add Event to submit form button
     * @param page
     * @param self
     */
    setConfirmButton(page, self) {
        let btn = document.getElementById('answerButton');
        btn.addEventListener('click', function () {
            page._check_if_forms_are_filled();
        }.bind(self))
    }
}

$(document).ready(function () {
    // For every page a new javascript view (js/views/questions.js at the moment)
    // init the class
    let page = new Question();
    // Run method to modify this page with the data retrieved from the API
    page.render_question_data();


});