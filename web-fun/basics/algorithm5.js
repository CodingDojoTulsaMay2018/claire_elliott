// Return the given array, after setting any negative values to zero.  For example resetNegatives( [1,2,-1, -3]) should return [1,2,0,0].
function negsToZero(arr){
    for(i=0; i<arr.length; i++){
        if(arr[i] < 0){
            arr[i] = 0;
        }
    }
    return arr;
}

// Given an array, move all values forward by one index, dropping the first and leaving a ‘0’ value at the end.  For example moveForward( [1,2,3]) should return [2,3,0].
function moveFwd(arr){
    var temp;
    for(var i=0; i<arr.length; i++){
        arr[i] = arr[i+1];
    }
    arr[arr.length-1] = 0;
    return arr;
}

// Given an array, return an array with values in a reversed order.  For example, returnReversed([1,2,3]) should return [3,2,1].
function rvOrder(arr){
    for(i=0; i<arr.length/2; i++){
        var temp = arr[i];
        arr[i] = arr[arr.length-i-1];
        arr[arr.length-i-1] = temp;
    }
    return arr;
}

// Create a function that changes a given array to list each original element twice, retaining original order.  Have the function return the new array.  For example repeatTwice( [4,”Ulysses”, 42, false] ) should return [4,4, “Ulysses”, “Ulysses”, 42, 42, false, false].
function repeatTwice(arr){
    arr.length = arr.length*2;
    for(i=arr.length/2-1; i>=0; i--){
        arr[(i*2)] = arr[i];
        arr[i*2+1] = arr[i];
    }
    return arr;
}