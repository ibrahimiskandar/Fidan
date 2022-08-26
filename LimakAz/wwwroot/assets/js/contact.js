////Contact page Show/Hide Map
//function mapFunction() {
//    let contactMapHandler = document.querySelectorAll(".contact-map");
//    console.log("--->", contactMapHandler);

//    contactMapHandler.forEach(function(map, index) {
//        console.log("this", this);
//        console.log("index", index);
//        console.log("map--->>>", map);

//        map.previousElementSibling.previousElementSibling.previousElementSibling.childNodes[0].childNodes[2].addEventListener(
//            "click",
//            () => {
//                if (map.style.display === "none") {
//                    map.style.display = "block";
//                } else {
//                    map.style.display = "none";
//                }
//            }
//        );
//        console.log("map--->>>", mapsBtns);
//    });
//}
//mapFunction();

//function mapFunction() {
//    var x = document.getElementById("contact-map");
//    if (x.style.display === "none") {
//        x.style.display = "block";
//    }
//    else {
//        x.style.display = "none";
//    }
//}

//function mapFunction() {
//    let contactMapHandler = document.querySelectorAll(".contact-map");
//    console.log('--->', contactMapHandler);
//    contactMapHandler.forEach(function (map, index) {
//        console.log('this', this);
//        console.log('index', index);
//        console.log('map--->>>', map)
//        if (map.style.display === "none") {
//            map.style.display = "block";
//        }
//        else {
//            map.style.display = "none";
//        }
//    })

//};
function mapFunction() {
    let contactMapHandler = document.querySelectorAll(".address-map");
    console.log('--->', contactMapHandler);
    contactMapHandler.forEach(function (map, index) {
        console.log('this', this);
        console.log('index', index);
        console.log('map--->>>', map)
        if (map.style.display === "none") {
            map.style.display = "block";
        }
        else {
            map.style.display = "none";
        }
    })

};


//function mapFunction() {
//    var contactMap = document.getElementsByClassName('map-title');
//    console.log(contactMap)
//    contactMap.forEach(el => {
//        el.click(function () {
//            document.getElementById('contact-map').classList.toggle("d-block")
//        })
//    })
//}