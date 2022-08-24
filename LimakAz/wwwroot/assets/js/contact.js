////Contact page Show/Hide Map
function mapFunction() {
    let contactMapHandler = document.querySelectorAll(".contact-map");
    console.log("--->", contactMapHandler);

    contactMapHandler.forEach(function(map, index) {
        console.log("this", this);
        console.log("index", index);
        console.log("map--->>>", map);

        map.previousElementSibling.previousElementSibling.previousElementSibling.childNodes[0].childNodes[2].addEventListener(
            "click",
            () => {
                if (map.style.display === "none") {
                    map.style.display = "block";
                } else {
                    map.style.display = "none";
                }
            }
        );
        console.log("map--->>>", mapsBtns);
    });
}
mapFunction();

//function mapFunction() {
//    var contactMap = document.getElementsByClassName('map-title');
//    console.log(contactMap)
//    contactMap.forEach(el => {
//        el.click(function () {
//            console.log("salammm")
//            document.getElementById('contact-map').classList.toggle("d-block")
//        })
//    })
//}