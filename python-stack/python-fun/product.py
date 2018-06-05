class Product:
    def sell(self):
        self.status = "sold"
        return self 

    def add_tax(self,sales_tax):
        print("{} including tax.".format(round(self.price + (self.price * sales_tax),2)))
        return self

    def return_item(self,reason_for_return):
        if reason_for_return == "defective":
            self.status = "defective"
            self.price = 0
        if reason_for_return == "like new":
            self.status = "for sale"
        if reason_for_return == "opened":
            self.status = "opened"
            self.price -= round(self.price * 0.20,2)
        return self
    
    def display_info(self):
        print("'{}' {} from {}, {}lb(s), {} + tax".format(self.status,self.item_name,self.brand,self.weight,self.price))
        return self

    def __init__(self,price,item_name,weight,brand):
        self.price = price
        self.item_name = item_name
        self.weight = weight
        self.brand = brand
        self.status = "for sale"
        self.display_info()
