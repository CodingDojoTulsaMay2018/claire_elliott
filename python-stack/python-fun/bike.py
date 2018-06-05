class Bike:
    def __init__(self,price,max_speed):
        self.price = price
        self.max_speed = max_speed
        self.miles = 0
    
    def displayInfo(self):
        print('Price: {}, Max Speed: {}, Miles: {}'.format(self.price,self.max_speed,self.miles))
        return self

    def ride(self):
        print('Riding!!!')
        self.miles += 10
        return self
    
    def reverse(self):
        print('Reversing!!')
        if self.miles < 5:
            self.miles = 0
        else:
            self.miles -= 5
        return self
