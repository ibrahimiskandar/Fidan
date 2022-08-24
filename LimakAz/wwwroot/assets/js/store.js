// Store Page Filter

const list = document.querySelectorAll(".nav-item");
const itemBox = document.querySelectorAll(".item-box");
const navLink = document.querySelectorAll(".nav-link");


for (let i = 0; i < list.length; i++) {
    list[i].addEventListener("click", function ()
    {
        for (let j = 0; j < list.length; j++)
        {
            navLink[j].classList.remove("active");
        }
        navLink[i].classList.add("active");

        let dataFilter = this.getAttribute("data-target-item");

        for (let k = 0; k < itemBox.length; k++)
        {
            itemBox[k].classList.remove("active");
            itemBox[k].classList.add("hide");

            if (itemBox[k].getAttribute("data-item") == dataFilter || dataFilter == "all")
            {
                itemBox[k].classList.remove("hide");
                itemBox[k].classList.add("active");
            }
        }
    })
}


// User Panel Content Header

const flagBtns = document.querySelectorAll("#headerList .nav-item .nav-link");
const tabPanes = Array.from(document.querySelectorAll(".active-tab"));

function removeActivesInFlag()
{
    for (let i = 0; i < flagBtns.length; i++)
    {
        flagBtns[i].classList.remove("active");
    }
}

function removeActivesInTabPane() {
    for (let i = 0; i < tabPanes.length; i++)
    {
        tabPanes[i].classList.remove("active");
    }
}

for (let i = 0; i < flagBtns.length; i++)
{
    flagBtns[i].addEventListener("click", function ()
    {
        if (!flagBtns[i].classList.contains("active"))
        {
            removeActivesInFlag();
            flagBtns[i].classList.add("active")
        }
        removeActivesInTabPane();
        let target = this.getAttribute("data-target");
        tabPanes.forEach(el => {
            if (target == el.getAttribute("data-id"))
            {
                el.classList.add("active");
            }
        })
    })
}