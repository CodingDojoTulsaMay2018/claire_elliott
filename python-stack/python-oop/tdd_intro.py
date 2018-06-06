import unittest
# 1.
def reverseList(num_list):
    for i in range(0,int(len(num_list)/2)):
        num_list[i], num_list[(len(num_list))-i-1] = num_list[(len(num_list))-i-1], num_list[i]
    return num_list
        

class reverseListTest(unittest.TestCase):
    def test1(self):
        self.assertTrue(reverseList([1,2,3,4]), [4,3,2,1])
    def test2(self):
        self.assertTrue(reverseList([3,5,-2,0]), [0,-2,5,3])
    def test3(self):
        self.assertNotEqual(reverseList([1,2,3,4,5]), [1,2,3,4,5])
    

# 2.
def isPalindrome(string):
    rev_string = ""
    for i in range(len(string)-1,-1,-1):
        rev_string += string[i]
    if rev_string == string:
        return True
    

class isPalindromeTest(unittest.TestCase):
    def test1(self):
        self.assertTrue(isPalindrome("racecar"),"racecar")
    def test2(self):
        self.assertNotEqual(isPalindrome("fox"),"xof")
    def test3(self):
        self.assertNotEqual(isPalindrome("devil never even lived"),"devil neve reven lived")
    def test4(self):
        self.assertTrue(isPalindrome("madam"),"madam")
    def test5(self):
        self.assertNotEqual(isPalindrome("Noon"),"nooN")

#3.
def sortChange(num):
    sorted_change = [0,0,0,0]
    if num > 25:
        sorted_change[0] = num//25
        num -= sorted_change[0]*25
    if num > 10:
        sorted_change[1] = num//10
        num -= sorted_change[1]*10
    if num > 5:
        sorted_change[2] = num//5
        num -= sorted_change[2]*5
    sorted_change[3] = num
    return sorted_change

class sortChangeTest(unittest.TestCase):
    def test1(self):
        self.assertTrue(sortChange(99),[3,2,0,4])
    def test2(self):
        self.assertTrue(sortChange(0),[0,0,0,0])
    def test3(self):
        self.assertTrue(sortChange(100),[4,0,0,0])
    def test4(self):
        self.assertNotEqual(sortChange(0),[1,0,0,0])
    def test5(self):
        self.assertNotEqual(sortChange(80),80)

# 4.
def factorial(num):
    if num < 1:
       return 1
    else:
       num = num * factorial(num - 1)
       return num

class factorialTest(unittest.TestCase):
    def test1(self):
        self.assertTrue(factorial(5),120)
    def test2(self):
        self.assertNotEqual(factorial(5),15)

def fibonacci(num):
    if num == 0:
        fib_list = [0]
        return fib_list
    if num == 1:
        fib_list = [0,1]
        return fib_list
    else:
        fib_list = fibonacci(num-1)
        fib_list.append(fib_list[-1] + fib_list[-2])
        return fib_list

class fibonacciTest(unittest.TestCase):
    def test1(self):
        self.assertTrue(fibonacci(0),[0])
    def test2(self):
        self.assertTrue(fibonacci(1),[0,1])
    def test3(self):
        self.assertNotEqual(fibonacci(5),[0,1,2,3,4,5])        

if __name__ == '__main__':
    unittest.main()