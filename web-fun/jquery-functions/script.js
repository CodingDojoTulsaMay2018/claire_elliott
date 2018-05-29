$(document).ready(function(){
    // div 1
    $("#click-btn").click(function(){
        console.log("unlike most men amirite ladies?")
    })
    // div 2
    $("#hide").click(function(){
        $(".hide-show").hide();
    });
    // div 3
    $("#show").click(function(){
        $(".hide-show").show();
    })
    // div 4
    $("#toggle").click(function(){
        $(".toggle").toggle();
    })
    // div 5
    $("#slide-down").click(function(){
        $(".slide-ud").slideDown();
    })
    $("#slide-up").click(function(){
        $(".slide-ud").slideUp();
    })
    // div 6
    $("#slide-toggle").click(function(){
        $(".slide-toggle").slideToggle();
    })
    // div 7
    $("#fade-out").click(function(){
        $(".fade-function").fadeOut();
    })
    $("#fade-in").click(function(){
        $(".fade-function").fadeIn();
    })
    // div 8
    $("#add-class").click(function(){
        $(".add-class").addClass("elegent");
    })
    // div 9
    $("#before-btn").click(function(){
        $(".before-p").before("<span>🐱</span>")
    })
    // div 10
    $("#after-btn").click(function(){
        $(".after-p").after("<span>🐱</span>")
    })
    // div 11
    $("#append").click(function(){
        $(".append-p").append("<b>This is appended text by Scott. Not Claire.</b>")
    })
    // div 12
    $("#html-btn").click(function(){
        $(".html-p").html("I like turtles.🐢");
    })
    // div 13
    $("#attr-btn").click(function(){
        $("link:last").attr("href"," ");
    })
    // div 14
    $("#val-btn").click(function(){
        $("textarea").val("I scream, you scream, we all scream for ice cream");
    })
    // div 15
    $("#text-btn").click(function(){
        $(".text-p").text("This is such a boring method. oh em gee.");
    })
    // div 16
    $("#data-btn").click(function(){
        $( ".data-p" ).data( "scott", { animal: "cat", name: "Twiggy." } );
        $( "span:first" ).text( $( ".data-p" ).data( "scott" ).animal );
        $( "span:last" ).text( $( ".data-p" ).data( "scott" ).name );
    })
})