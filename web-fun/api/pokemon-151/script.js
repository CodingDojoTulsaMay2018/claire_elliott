$(document).ready(function(){
    $("button").click(function(){
        for(var i=1;i<=15;i++){
            $(".container").append('<img src="https://pokeapi.co/media/img/'+i+'.png"> ');
            // imgs must be loaded first before they will appear in the browser. idk why.
        }
    })
})