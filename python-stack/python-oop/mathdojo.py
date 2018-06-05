class MathDojo:
    def add(self,num,*args):
        for i in args:
            self.total += i
        self.total += num
        return self
    def subtract(self,num,*args):
        for i in args:
            self.total -= i
        self.total -= num
        return self
    def result(self):
        return self.total
    def __init__(self):
        self.total = 0

md = MathDojo()
print(md.add(2).add(2,5,1).subtract(3,2).result())