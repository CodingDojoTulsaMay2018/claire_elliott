// class for min heap
class Heap{
    constructor(){
        this.data = [undefined];
    }
    add(val){
        this.data.push(val);
        this.repairUp(this.data.length-1);
    }
    remove(){
        let swap = this.data[1];
        this.data[1] = this.data[this.data.length-1];
        this.data[this.data.length-1] = swap;
        this.repairDown(1);
        return this.data.pop();
    }
    repairUp(startIdx){
        let parentIdx = Math.floor(startIdx/2);
        // check if need to swap with parents
        if(this.data[startIdx] < this.data[parentIdx] && parentIdx > 0){
            let swap = this.data[startIdx];
            this.data[startIdx] = this.data[parentIdx];
            this.data[parentIdx] = swap;
            this.repairUp(parentIdx);
        }
    }
    repairDown(startIdx){
        let swapIdx;
        let childOne = i * 2;
        let childTwo = childOne + 1;
        // check if need to swap with parents
        if(this.data[startIdx] > this.data[childOne] && this.data[childOne] < this.data[childTwo]){
            swapIdx = childOne;
        }
        else if(this.data[startIdx] > this.data[childTwo] && this.data[childTwo] < this.data[childOne]){
            swapIdx = childTwo;
        }
        if(swapIdx){
            let swap = this.data[swapIdx];
            this.data[swapIdx] = this.data[startIdx];
            this.data[startIdx] = swap;
            this.repairDown(swapIdx);
        }
    }
    static isValidMinHeap(arr){
        for(let i = 0; i < arr.length/2; i++){
            let childOne = (i * 2)+1;
            let childTwo = childOne + 1;
            if(arr[childOne] < arr[i] || arr[childTwo] < arr[i]){
                return false;
            }
        }
        return true;
    }
}
function heapify(arr){
    for(let i = 1; i < arr.length; i++){
        repairUp(arr, i);
    }
}
function repairUp(arr,idx){
    let parentIdx = Math.floor((idx-1)/2);
    // check if need to swap with parents
    if(arr[idx] < arr[parentIdx] && parentIdx >= 0){
        let swap = arr[idx];
        arr[idx] = arr[parentIdx];
        arr[parentIdx] = swap;
        this.repairUp(parentIdx);
    }
}
function repairDown(arr, startIdx, endIdx){
    let childOne = (i * 2)+1;
    let childTwo = childOne + 1;
    let swapIdx;
    if(arr[startIdx] > arr[childOne] && arr[childOne] < arr[childTwo] && childOne < endIdx){
        swapIdx = childOne;
    }
    else if(arr[startIdx] > arr[childTwo] && arr[childTwo] < arr[childOne] && childTwo < endIdx){
        swapIdx = childTwo;
    }
    if(swapIdx){
        let swap = arr[swapIdx];
        arr[swapIdx] = arr[startIdx];
        arr[startIdx] = swap;
        repairDown(arr, swapIdx, endIdx);
    }
}
function heapSort(arr){
    heapify(arr);
    for(let i = arr.length-1; i >= 0; i--){
        let swap = arr[0];
        arr[0] = arr[i];
        arr[i] = swap;
        repairDown(arr, 0, i);
    }
}