# As part of this assignment, please create a function randInt() where

# randInt() returns a random integer between 0 to 100
# randInt(max=50) returns a random integer between 0 to 50
# randInt(min=50) returns a random integer between 50 to 100
# randInt(min=50, max=500) returns a random integer between 50 and 500
# Create this function without using random.randInt() but you are allowed to use random.random().
import random
def rand_int(min = False, max = False):
    if max:
        num = random.random()*max
        return int(num)
    elif min:
        num = range(min, 100)
        return int(random.choice(num))
    elif max and min:
        num = range(min, max)
        return int(random.choice(num))
    num = random.random()*100
    return int(num)