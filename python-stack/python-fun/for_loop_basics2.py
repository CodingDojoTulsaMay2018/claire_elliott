# Biggie Size - Given an array, write a function that changes all positive numbers in the array to "big". Example: makeItBig([-1, 3, 5, -5]) returns that same array, changed to [-1, "big", "big", -5].
def make_it_big(arr):
    for i in range(0, len(arr)):
        if arr[i] > 0:
            arr[i] = "big"
    return arr

# Count Positives - Given an array of numbers, create a function to replace last value with number of positive values. Example, countPositives([-1,1,1,1]) changes array to [-1,1,1,3] and returns it.  (Note that zero is not considered to b a positive number).
def count_positives(arr):
    count = 0
    for i in arr:
        if i > 0:
            count += 1
    arr[len(arr)-1] = count
    return arr

# SumTotal - Create a function that takes an array as an argument and returns the sum of all the values in the array.  For example sumTotal([1,2,3,4]) should return 10
def sum_total(arr):
    sum_total = 0
    for i in arr:
        sum_total += i
    return sum_total
        
# Average - Create a function that takes an array as an argument and returns the average of all the values in the array.  For example multiples([1,2,3,4]) should return 2.5
def find_avg(arr):
    sum_total = 0.0
    for i in arr:
        sum_total += i
    return sum_total/len(arr)

# Length - Create a function that takes an array as an argument and returns the length of the array.  For example length([1,2,3,4]) should return 4
def arr_length(arr):
    return len(arr)

# Minimum - Create a function that takes an array as an argument and returns the minimum value in the array.  If the passed array is empty, have the function return false.  For example minimum([1,2,3,4]) should return 1; minimum([-1,-2,-3]) should return -3.
def min_arr(arr):
    if len(arr) == 0:
        return False
    else: min = arr[0]
    for i in arr:
        if i < min:
            min = i
    return min

# Maximum - Create a function that takes an array as an argument and returns the maximum value in the array.  If the passed array is empty, have the function return false.  For example maximum([1,2,3,4]) should return 4; maximum([-1,-2,-3]) should return -3.
def max_arr(arr):
    max = 0
    if len(arr) == 0:
        return False
    for i in arr:
        if i > max:
            max = i
    return max

# UltimateAnalyze - Create a function that takes an array as an argument and returns a dictionary that has the sumTotal, average, minimum, maximum and length of the array.
def ultimate_analysis(arr):
    arr_data = {"sumTotal": 0,"average": float(sum(arr))/len(arr),"minimum": arr[0],"maximum": arr[0]}
    for i in arr:
        arr_data["sumTotal"] += i
        if i <= arr_data["minimum"]:
            arr_data["minimum"] = i
        elif i >= arr_data["maximum"]:
            arr_data["maximum"] = i
    return arr_data 

# ReverseList - Create a function that takes an array as an argument and return an array in a reversed order.  Do this without creating an empty temporary array.  For example reverse([1,2,3,4]) should return [4,3,2,1]. This challenge is known to appear during basic technical interviews.
def reverse_list(arr):
    temp = 0
    count = 0
    while count < len(arr)/2:
        temp = arr[len(arr)-count-1]
        arr[len(arr)-count-1] = arr[count]
        arr[count] = temp
        count += 1
    return arr