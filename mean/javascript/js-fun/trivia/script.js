//VARIABLES
let count = 0;
sessionStorage.setItem("points", 0);
//FUNCTIONS
function grabAll(data){
    // Question
    $("#question").html(data.results[count].question);
    console.log(data.results[count].question);
    // Answers
    const arr = [];
    let finalStr = "";
    arr.push('<button id="correct" type=submit">'+data.results[count].correct_answer+'</button>');
    for(let i = 0; i < data.results[count].incorrect_answers.length; i++){
        arr.push('<button id="incorrect" type=submit">'+data.results[count].incorrect_answers[i]+'</button>');
    }
    for(let j = 0; j < 2; j++){
        var rand = Math.floor((Math.random() * 4));
        var temp = arr[j];
        arr[j] = arr[rand];
        arr[rand] = temp;
    }
    for(let answers of arr){
        finalStr += answers;
    }
    $("#answers").html(finalStr);
}
//DECLARATIONS
$.get("https://opentdb.com/api.php?amount=9&category=9&type=multiple", grabAll);
