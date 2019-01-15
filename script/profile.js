$(document).ready(function() {
    $(".btn-pref .btn").click(function () {
        $(".btn-pref .btn").removeClass("btn-primary").addClass("btn-default");
        // $(".tab").addClass("active"); // instead of this do the below 
        $(this).removeClass("btn-default").addClass("btn-primary");   
    });
    });


    function ss(endpoint){
        a="https://cors-anywhere.herokuapp.com/http://104.248.33.42:5000" + endpoint;
        
        $.ajax({
            type: 'GET',
            url: a,
            //data:DATA,
            //dataType:JSON
        }).done(function(data) {
            for(const trip of data) {
                console.log(trip)
                $( "#CardHolder" ).append(
                    `<div class="card">
                        <div class="card profile-card-5">
                            <div class="card-img-block">
                                <img class="card-img-top" style="height:100px; weight:100px;" src="https://marklangphotography.files.wordpress.com/2011/11/img_4003-v3-bw.jpg"
                                    alt="Card image cap">
                            </div>
                            <div class="card-body" style="background-color:black;">
                                <h5 class="card-title" style="color:antiquewhite;">From: ${trip.from} - To: ${trip.to}</h5>
                                <p class="card-text" style="color:antiquewhite;">Date: ${trip.time} with ${trip.vehicle}</p>
                
                                <p align="right"> <a href="profile.html" class="btn btn-dark ">View</a></p>
                            </div>
                        </div>
                    </div>`
                    );
            }
            // data.forEach(element => {
            // }); 
    
     
        });
    }
    
    function gg(endpoint){
        a="https://cors-anywhere.herokuapp.com/http://104.248.33.42:5000" + endpoint;
        
        $.ajax({
            type: 'POST',
            url: a,
            crossDomain: true,
            data:JSON.stringify(DATA),
            dataType:"json",
            header: {
    
            }
        }).done(function(data) {
    
    
            console.log(data)
            // for(const trip of data) {
            //     console.log(trip)
            //     $( "#CardHolder" ).append(
            //         `<div class="card">
            //             <div class="card profile-card-5">
            //                 <div class="card-img-block">
            //                     <img class="card-img-top" style="height:100px; weight:100px;" src="https://marklangphotography.files.wordpress.com/2011/11/img_4003-v3-bw.jpg"
            //                         alt="Card image cap">
            //                 </div>
            //                 <div class="card-body" style="background-color:black;">
            //                     <h5 class="card-title" style="color:antiquewhite;">From: ${trip.from} - To: ${trip.to}</h5>
            //                     <p class="card-text" style="color:antiquewhite;">Date: ${trip.time} with ${trip.vehicle}</p>
                
            //                     <p align="right"> <a href="profile.html" class="btn btn-dark ">View</a></p>
            //                 </div>
            //             </div>
            //         </div>`
            //         );
            // }
            // // data.forEach(element => {
            // // }); 
    
     
        });
    }

