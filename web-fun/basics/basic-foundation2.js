// Biggie Size - Given an array, write a function that changes all positive numbers in the array to "big".  Example: makeItBig([-1,3,5,-5]) returns that same array, changed to [-1, "big", "big", -5].

function biggieSize(arr){
    for(i = 0; i < arr.length; i++){
        if(arr[i] > 0){
            arr[i] = "big";
        }
    }
    return arr;
}

// Print Low, Return High - Create a function that takes array of numbers.  The function should print the lowest value in the array, and return the highest value in the array.

function lowHigh(arr){
    var low = arr[0];
    var high = arr[0];
    for(i = 0; i < arr.length; i++){
        if(arr[i] < low){
            low = arr[i];
        }
        else if(arr[i] > high){
            high = arr[i];
        }
    }
    console.log(low);
    return high;
}

// Print One, Return Another - Build a function that takes array of numbers.  The function should print second-to-last value in the array, and return first odd value in the array.

function printReturn(arr){
    console.log(arr[arr.length-2]);
    for(i = 0; i < arr.length; i++){
        if(arr[i] % 2 !== 0){
            return arr[i];
        }
    }
}

// Double Vision - Given array, create a function to return a new array where each value in the original has been doubled.  Calling double([1,2,3]) should return [2,4,6] without changing original.

function dblVision(arr){
    var dblArr = [];
    for(i = 0; i < arr.length; i++){
        dblArr[i] = arr[i]*2;
    }
    return dblArr;
}

// Count Positives - Given array of numbers, create function to replace last value with number of positive values.  Example, countPositives([-1,1,1,1]) changes array to [-1,1,1,3] and returns it.

function countPositives(arr){
    var count = 0;
    for(i = 0; i < arr.length; i++){
        if(arr[i] > 0){
            count++;
        }
    }
    arr[arr.length-1] = count;
    return arr;
}

// Evens and Odds - Create a function that accepts an array.  Every time that array has three odd values in a row, print "That's odd!".  Every time the array has three evens in a row, print "Even more so!"

function evenOdds(arr){
    for(i = 0; i < arr.length; i++){
      if(arr[i] % 2 !== 0 && arr[i+1] % 2 !== 0 && arr[i+2] % 2 !== 0){
            console.log("That's odd!");
        }
      if(arr[i] % 2 === 0 && arr[i+1] % 2 === 0 && arr[i+2] % 2 === 0){
        console.log("Even more so!");
      }
    }
}

// Increment the Seconds - Given an array of numbers arr, add 1 to every second element, specifically those whose index is odd (arr[1], [3], [5], etc).  Afterward. console.log each array value and return arr.

function incrSeconds(arr){
    for(i = 0; i < arr.length; i ++){
        if(i % 2 !== 0){
            arr[i] += 1;
        }
        console.log(arr[i]);
    }
    return arr;
}

// Previous Lengths - You are passed an array containing strings.  Working within that same array, replace each string with a number - the length of the string at previous array index - and return the array.

function prevLength(arr){
    for(i = arr.length-1; i > 0; i--){
        arr[i] = arr[i-1].length;
    }
    arr[0] = 0;
    return arr;
}

// Add Seven to Most - Build function that accepts array. Return a new array with all values except first, adding 7 to each. Do not alter the original array.

function addSeven(arr){
    var sevenArr = [];
    for(i = 1; i < arr.length; i++){
        sevenArr.push(arr[i]+7);
    }
    return sevenArr;
}

// Reverse Array - Given an array, write a function that reverses values, in-place.  Example: reverse([3,1,6,4,2]) return same array, containing [2,4,6,1,3].  Do this without creating an empty temporary array.  (Hint: you'll need to swap values).

function reverseArr(arr){
    var temp = 0;
    for(i = 0; i < arr.length/2; i++){
        temp = arr[i];
        arr[i] = arr[arr.length-1-i];
        arr[arr.length-1-i] = temp;
    }
    return arr;
}

// Outlook: Negative - Given an array, create and return a new one containing all the values of the provided array, made negative (not simply multiplied by -1). Given [1,-3,5], return [-1,-3,-5].

function makeNegativeVals(arr){
    var negArr = [];
    for(i = 0; i < arr.length; i++){
        if(arr[i] > 0){
            negArr[i] = arr[i] * -1;
        } else {
            negArr[i] = arr[i];
        }
    }
    return negArr;
}

// Always Hungry - Create a function that accepts an array, and prints "yummy" each time one of the values is equal to "food".  If no array elements are "food", then print "I'm hungry" once.

function alwaysHungry(arr){
    var count = 0;
    for(i = 0; i < arr.length; i++){
        if(arr[i] === "food"){
            console.log("yummy");
            count = 1;
        }
    }
    if(count === 0){
        console.log("I'm hungry");
    }
}

// Swap Toward the Center - Given array, swap first and last, third and third-to-last, etc.  Input[true,42,"Ada",2,"pizza"] becomes ["pizza", 42, "Ada", 2, true].  Change [1,2,3,4,5,6] to [6,2,4,3,5,1].

function swapToCenter(arr){
    var temp = 0;
    for(i = 0; i < arr.length/2; i++){
        temp = arr[i];
        arr[i] = arr[arr.length-1-i];
        arr[arr.length-1-i] = temp;
    }
    return arr;
}

// Scale the Array - Given an array arr and a number num, multiply all values in arr by num, and return the changed array arr.  For example, scaleArray([1,2,3],3) should return [3,6,9].

function scaleArray(arr,val){
    for(i = 0; i < arr.length; i++){
        arr[i] = arr[i] * val;
    }
    return arr;
}