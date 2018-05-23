$(document).ready(function(){
    var dropmenuOne = "<select id='dropdown1' name='playerOne'><option></option><option value='boo.gif'>Boo</option><option value='spiderman.gif'>Spider-Man</option><option value='zombie.gif'>Zombie</option><option value='kitty.gif'>Kitty</option></select>";
    var dropmenuTwo = "<select id='dropdown2' name='playerTwo'><option></option><option value='boo.gif'>Boo</option><option value='spiderman.gif'>Spider-Man</option><option value='zombie.gif'>Zombie</option><option value='kitty.gif'>Kitty</option></select>";
    $("#beach").hover(
        function(){ $("#wrapper").addClass("beach") },
        function(){ $("#wrapper").removeClass("beach")
    })
    $("#planet").hover(
        function(){ $("#wrapper").addClass("planet") },
        function(){ $("#wrapper").removeClass("planet")
    })
    $("#dojo").hover(
        function(){ $("#wrapper").addClass("dojo") },
        function(){ $("#wrapper").removeClass("dojo")
    })
    $("#forest").hover(
        function(){ $("#wrapper").addClass("forest") },
        function(){ $("#wrapper").removeClass("forest")
    })
    $("#matrix").hover(
        function(){ $("#wrapper").addClass("matrix") },
        function(){ $("#wrapper").removeClass("matrix")
    })
    $("#snow").hover(
        function(){ $("#wrapper").addClass("snow") },
        function(){ $("#wrapper").removeClass("snow")
    })
    $("button").click(
        function(){ $(".container").html('<h1 class="step-2">Select Players</h1>'+dropmenuOne+""+dropmenuTwo)
        
    })
    $(".container").on('change', '#dropdown1', function(){
        var fighter = $(this).val();
        console.log(fighter);
        $("#fighterOne").html('<img src="'+$(this).val()+'">');
    })
    $(".container").on('change', '#dropdown2', function(){
        var fighter = $(this).val();
        console.log(fighter);
        $("#fighterTwo").html('<img src="'+$(this).val()+'">');
    })
})