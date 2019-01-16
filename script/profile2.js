// $(".btn-pref .btn").click(function () {
//     $(".btn-pref .btn").removeClass("btn-primary").addClass("btn-default");
//     // $(".tab").addClass("active"); // instead of this do the below 
//     $(this).removeClass("btn-default").addClass("btn-primary");   
// });
function delete_cookie( name ) {
    document.cookie = name + '=; expires=Thu, 01 Jan 1970 00:00:01 GMT;';
  }
  delete_cookie(".");
$(document).ready(function(){
console.log(g)
    a="http://104.248.33.42:5000" + "/api/users/"+g;
        
        $.ajax({
            type: 'GET',
            url: a,
            //data:DATA,
            //dataType:JSON
        }).done(function(data) {
           
                $( "#ProfileData" ).append(
                    `<h1>${data[0].name} ${data[0].surname}</h1>
                        <p>${data[0].age} , ${data[0].nationality}</p>
                    <div class="btn-group">
                        <button type="button" class="btn btn-light btn-lg"><a href="profileedit.html">Profil Düzenle</a></button>
                    </div>`
                    );

                    $( "#BioData" ).append(
                        `<h1 style="font-size:25px;">BIOGRAPHY</h1>
                        <p>${data[0].gender} - ${data[0].bio}</p>
                        `
                        );


            
        });
});


