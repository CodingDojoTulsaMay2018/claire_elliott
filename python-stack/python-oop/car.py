class Car:
    
    def fuelInfo(self):
        if self.fuel >= 95:
            return "Full"
        elif self.fuel < 95 and self.fuel > 70:
            return "Kinda Full"
        elif self.fuel < 70  and self.fuel > 5:
            return "Low"
        else:
            return "Empty"

    def display_all(self):
        print('Price: {}\nSpeed: {}\nFuel: {}\nMileage: {}\nTax: {}%'.format(self.price,self.speed,self.fuelInfo(),self.mileage,self.tax))

    def __init__(self,price,speed,fuel,mileage):
        self.price = price
        self.speed = speed
        self.fuel = fuel
        self.mileage = mileage
        
        if self.price > 10000:
            self.tax = 12
        else:
            self.tax = 10

        self.display_all()