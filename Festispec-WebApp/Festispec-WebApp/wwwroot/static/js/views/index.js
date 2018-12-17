class index {
    constructor() {
        this.WebApp = new WebApp();
    }

    load_inspection_data() {
        // Select UL element created in the HTML based on ID. Keep the ID unique for every <ul>!
        let target_ul = $('#test_cj');
        // Run function from api_helper, retrieving the data for this inspector.
        this.WebApp.getInspections(function (inspectorData) {
            console.log(inspectorData);
            // returns the inspector's data, and if not leave the ul empty or write no inspections
            if (inspectorData) {
                // foreach through inspectorData, if you want to see the data before accessing it just execute console.log(inspectorData);
                // And check the console tab in your "Inspect element" option in the browser
                for (let index in inspectorData) {
                    // Add item to selected <ul>
                    target_ul.append(
                        // Add <li> to ul (list element)
                        $('<li>').append(
                            // Call the current list index (The list contains objects, in this case 2 inspector objects)
                            // So we need to for through the list (which we do above, in the for loop), and call the object attribute (or object functions, lists etc)
                            inspectorData[index].name
                        )
                    )
                }
            } else {
                // write no inspection in ul
            }
        
        })
    }
}