function formatDate(date) {
    var monthNames = [
      "January", "February", "March",
      "April", "May", "June", "July",
      "August", "September", "October",
      "November", "December"
    ];
  
    var day = date.getDate();
    var monthIndex = date.getMonth();
    var year = date.getFullYear();
  
    return day + ' ' + monthNames[monthIndex] + ' ' + year;
  }


$(document).ready(function(){

    a="http://104.248.33.42:5000" + "/api/trips";
        
        $.ajax({
            type: 'GET',
            url: a,
            //data:DATA,
            //dataType:JSON
        }).done(function(data) {
            for(const trip of data) {
                console.log(trip)
                
                $( "#CardHolder" ).append(
                    `<div class="card" style="width:450px">
                        <div class="card profile-card-5">
                            <div class="card-img-block">
                                <img class="card-img-top" style="height:200px; width:445px;" src="https://marklangphotography.files.wordpress.com/2011/11/img_4003-v3-bw.jpg"
                                    alt="Card image cap">
                            </div>
                            <div class="card-body" style="background-color:black;">
                                <h5 class="card-title" style="color:antiquewhite;">From: ${trip.from} - To: ${trip.to}</h5>
                                <p class="card-text" style="color:antiquewhite;">Date: ${formatDate(new Date(trip.time))} with ${ trip.vehicle}</p>
                
                                <p align="right"> <a id="${trip.creatorID}" onClick="hh()" href="profile2.html"  class="btn btn-dark ">${trip.creatorID}</a></p>
                            </div>
                        </div>
                    </div>`
                    );
                   
            }
        });
});

function hh(){
    
    var value = $( this ).id();
    alert(value)
    console.log(value)
}