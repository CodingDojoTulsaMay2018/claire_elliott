$(document).ready(function(){
    $(".dress1 img").hover(function(){
        $(this).attr("src","img/dress01_back.jpg")
    },function(){
        $(this).attr("src","img/dress01_front.jpg")
    })
    $(".dress2 img").hover(function(){
        $(this).attr("src","img/dress02_back.jpg")
    },function(){
        $(this).attr("src","img/dress02_front.jpg")
    })
    $(".dress3 img").hover(function(){
        $(this).attr("src","img/dress03_back.jpg")
    },function(){
        $(this).attr("src","img/dress03_front.jpg")
    })
    $(".dress4 img").hover(function(){
        $(this).attr("src","img/dress04_back.jpg")
    },function(){
        $(this).attr("src","img/dress04_front.jpg")
    })
})