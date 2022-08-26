
$('#try').click(function (e) {
    var url = "/Payment";
    e.preventDefault();
    fetch(url)
        .then(response => {
            return response.json();
        })
        .then(data => {
            console.log(data)

       })
})
