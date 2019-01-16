function gg(){

    var formData = {
        username: $("#username").val(),
        name: $("#name").val(),
        surname: $("#lastname").val(),
        email: $("#email").val(), 
    }

    a="http://104.248.33.42:5000" + "/api/users";
        
console.log(JSON.stringify(formData))
    $.ajax({
        type: 'POST',
        url: a,
        data:JSON.stringify(formData),
        header:{
            "Content-Type":"application/json"
        }
    }).done(function(data) {
        console.log(data)
    });
    console.log(formData)
};
