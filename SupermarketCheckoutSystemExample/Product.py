class Product:

    def __init__(self, bar_code,name, description, price):
        self.__bar_code = bar_code
        self.__name = name
        self.__description = description
        self.__price = price

    def setBarCode(self, bar_code):
        self.__bar_code = bar_code

    def setName(self, name):
        self.__name = name

    def setDescription(self, description):
        self.__description = description

    def setPrice(self, price):
        self.__price = price

    def getBarCode(self):
        return self.__bar_code

    def getName(self):
        return self.__name

    def getDescription(self):
        return self.__description

    def getPrice(self):
        return self.__price

    def __str__(self):
        return f"Barcode: {self.__bar_code}\nName: {self.__name}\nDescription: {self.__description}\nPrice: ${abs(self.__price):,.2f}"