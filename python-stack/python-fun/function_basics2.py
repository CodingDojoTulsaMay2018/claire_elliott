# Countdown - Create a function that accepts a number as an input.  Return a new array that counts down by one, from the number (as arrays 'zero'th element) down to 0 (as the last element).  For example countDown(5) should return [5,4,3,2,1,0].
def countdown(beginning_num):
    arr = []
    while beginning_num >= 0:
        arr.append(beginning_num)
        beginning_num -= 1
    return arr

# Print and Return - Your function will receive an array with two numbers. Print the first value, and return the second.
def print_return(arr):
    print(arr[0])
    return arr[1]

# First Plus Length - Given an array, return the sum of the first value in the array, plus the array's length.
def first_plus_length(arr):
    return (arr[0] + len(arr))

# Values Greater than Second - Write a function that accepts any array, and returns a new array with the array values that are greater than its 2nd value.  Print how many values this is.  If the array is only element long, have the function return False
def values_greater_than(arr):
    greater_arr = []
    for i in arr:
        if i > arr[1]:
            greater_arr.append(i)
    if len(greater_arr) == 1:
        return False
    else:
        return len(greater_arr)

# This Length, That Value - Given two numbers, return array of length num1 with each value num2.  Print "Jinx!" if they are same.
def this_length_that_value(num1, num2):
    i = 0
    arr = []
    if num1 == num2:
        print("Jinx!")
    while i < num1:
        arr.append(num2)
        i += 1
    return arr

print(this_length_that_value(2, 3))