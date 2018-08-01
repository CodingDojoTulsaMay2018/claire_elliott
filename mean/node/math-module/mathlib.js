module.exports = function (){
    return {
      add: function(num1, num2) { 
            answer = num1 + num2;
            console.log("the sum is:", num1 + num2);
      },
      multiply: function(num1, num2) {
           answer = num1 * num2;
      },
      square: function(num) {
           answer = num*num;
      },
      random: function(num1, num2) {
        return num2 - Math.floor((Math.random() * (num2-num1))+1);
      }
  };
};