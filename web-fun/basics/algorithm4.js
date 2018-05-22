// 1.  Given an array and a value Y, count and print the number of array values greater than Y.

function greaterThanY(arr,val){
    var count = 0;
    for(i=0; i<arr.length; i++){
      if(arr[i]>val){
        count++;
      }
    }
    console.log("Number of values greater than "+val+": "+count);
  }

// 2.  Given an array, print the max, min and average values for that array.

function minMaxAvg(arr){
  var min = arr[0];
  var max = arr[0];
  var avg = 0;
  for(i=0;i<arr.length; i++){
    if(arr[i]<min){
      min = arr[i];
    }
    else if(arr[i]>max){
      max = arr[i];
    }
    avg += arr[i];
  }
  avg = avg/arr.length;
  console.log("Min: "+min+", Max: "+max+", Avg: "+avg);
}

// 3.  Given an array of numbers, create a function that returns a new array where negative values were replaced with the string ‘Dojo’.   For example, replaceNegatives( [1,2,-3,-5,5]) should return [1,2, "Dojo", "Dojo", 5].

function replaceNegatives(arr){
  for(i=0; i<arr.length; i++){
    if(arr[i]<0){
      arr[i] = "Dojo";
    }
  }
  return arr;
}

// 4.  Given an array, and indices start and end, remove vals in that index range, working in-place (hence shortening the array).  For example, removeVals([20,30,40,50,60,70],2,4) should return [20,30,70].

function removeVals(arr,start,end){
  for(i=start; i<=end; i++){
    arr[i]
  }
}