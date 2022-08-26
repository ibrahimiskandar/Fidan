// Register page Show/Hide Password

//const showBtn = Array.from(document.querySelectorAll(".showPass"));

//showBtn.forEach(element => {
//    element.addEventListener("click", function ()
//    {
//        if (element.previousElementSibling.type == "password") {
//            element.previousElementSibling.type = "text";
//        } else {
//            element.previousElementSibling.type = "password";
//        }
//    })
//});


const showBtn1 = document.querySelector(".showPassword1");
const showBtn2 = document.querySelector(".showPassword2");


showBtn1.addEventListener("click", function () {
    if (showBtn1.previousElementSibling.type == "password") {
        showBtn1.previousElementSibling.type = "text";
    } else {
        showBtn1.previousElementSibling.type = "password";
    }
})
showBtn2.addEventListener("click", function () {
    if (showBtn2.previousElementSibling.type == "password") {
        showBtn2.previousElementSibling.type = "text";
    } else {
        showBtn2.previousElementSibling.type = "password";
    }
})


//const showBtnTwo = Array.from(document.querySelectorAll(".showPass"));

//showBtnTwo.forEach(element => {
//    element.addEventListener("click", function () {
//        if (element.previousElementSibling.type == "password") {
//            element.previousElementSibling.type = "text";
//        } else {
//            element.previousElementSibling.type = "password";
//        }
//    })
//});




