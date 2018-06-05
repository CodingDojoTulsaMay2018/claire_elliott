class Animal:
    def walk(self):
        if self.health > 0:
            self.health -= 1
        return self
    
    def run(self):
        if self.health >= 5:
            self.health -= 5
        return self

    def displayHealth (self):
        print('{} health remaining'.format(self.health))
        return self
    
    def __init__(self,name,health):
        self.name = name
        self.health = health

class Dog(Animal):
    def __init__(self,name):
        super().__init__(self,health=150)
    
    def pet(self):
        self.health += 5
        return self
    
class Dragon(Animal):
    def __init__(self,name):
        super().__init__(self,health=170)
    
    def fly(self):
        if self.health >= 10:
            self.health -= 10
        return self
    
    def displayHealth(self):
        print('I am a dragon! ',self.health,'health remaining.')
        return self

animal1 = Animal("fluffy",50)

animal2 = Dog("Scruffy")

animal3 = Dragon("Scorchy")

animal1.walk().walk().walk().run().run().displayHealth()

animal2.walk().walk().walk().run().run().pet().displayHealth()

animal3.walk().walk().walk().run().run().displayHealth()


