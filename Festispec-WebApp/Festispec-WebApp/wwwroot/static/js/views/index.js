class Index {
    constructor() {
        this.WebApp = new WebApp();
    }

    static start_inspection(id) {
        let cookie = getCookie('inspection');
        if (cookie) {
            if (cookie !== id) {
                eraseCookie('inspection');
            }
        }
        setCookie('inspection', id, 7);
        window.location.href = 'questions.html';
    }

    render_inspection_data() {
        // Select UL element created in the HTML based on ID. Keep the ID unique for every <ul>!
        let target_ul = $('#test_cj');

        //backup this to use out of scope
        // Run function from api_helper, retrieving the data for this inspector.
        this.WebApp.getInspections(function (inspectorData) {
            console.log(inspectorData);
            // returns the inspector's data, and if not leave the ul empty or write no inspections
            if (inspectorData) {
                // foreach through inspectorData, if you want to see the data before accessing it just execute console.log(inspectorData);
                // And check the console tab in your "Inspect element" option in the browser
                for (let index in inspectorData) {
                    let a = document.createElement('a');
                    a.id = inspectorData[index].id;
                    a.style.color = "red";
                    a.style.hover = "cursor: pointer;";
                    a.addEventListener('click', function () {
                        Index.start_inspection(inspectorData[index].id);
                    });
                    a.innerHTML = inspectorData[index].name;
                    // Add item to selected <ul>
                    target_ul.append(
                        // Add <li> to ul (list element)
                        $('<li>').append(
                            $('<ul>').append(
                                // Call the current list index (The list contains objects, in this case 2 inspector objects)
                                // So we need to for through the list (which we do above, in the for loop), and call the object attribute (or object functions, lists etc)
                                $('<li>').append(
                                    inspectorData[index].id
                                ),
                                $('<li style="cursor: pointer;">').append(
                                    a
                                )
                            )
                        )
                    )
                }
            } else {
                // write no inspection in ul
                target_ul.append(
                    // Add <li> to ul (list element)
                    $('<li>').append(
                        // Call the current list index (The list contains objects, in this case 2 inspector objects)
                        // So we need to for through the list (which we do above, in the for loop), and call the object attribute (or object functions, lists etc)
                        "No inspection data."
                    )
                )
            }

        })
    }
}

$(document).ready(function () {
    // For every page a new javascript view (js/views/index.js at the moment)
    // init the class
    let page = new Index();
    // Run method to modify this page with the data retrieved from the API
    page.render_inspection_data();
});