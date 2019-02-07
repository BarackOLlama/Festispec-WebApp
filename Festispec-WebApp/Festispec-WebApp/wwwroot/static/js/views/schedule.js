class Schedule {
    constructor() {
        this.WebApp = new WebApp();
        this.calendar = $('.datepicker');
    }

    static convertDateToSaveAbleObject(date) {
        return `${date.split("/")[0]}-${date.split("/")[1]}-${date.split("/")[2]}T00:00:00`;
    }

    load() {
        this.calendar.datepicker({
            format: 'yyyy/mm/dd',
            startDate: '-3d'
        });
    }

    save() {
        let data = (this.calendar.val());
        if (!data) {
            alert('Selecteer een datum.');
        } else {
            let scheduleDate = Schedule.convertDateToSaveAbleObject(data);
            let schedule = new ScheduleModel(scheduleDate, this.WebApp.CurrentInspectorId);
            this.WebApp.saveScheduledItem(schedule, function (data, err) {
                if (err) {
                    console.log("Error:");
                    console.log(err)
                } else {
                    console.log("Success");
                    console.log(data)
                }
                
            });
        }
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
        let btn = document.getElementById('submit');
        btn.addEventListener('click', function () {
            page.save();
        }.bind(self))
    }
}

$(document).ready(function () {
    // For every page a new javascript view (js/views/index.js at the moment)
    // init the class
    let page = new Schedule();
    // Run method to modify this page with the data retrieved from the API
    page.load();
    new Events(page, this);
});