class Transaction:

    def __init__(self, date, barcode, amount):
        self.__date = date
        self.__barcode = barcode
        self.__amount = amount

    def __str__(self):
        return f"date: {self.__date}\nBarcode: {self.__barcode}\nPrice {self.__amount}"

    def getDate(self):
        return self.__date

    def getBarcode(self):
        return self.__barcode

    def getAmount(self):
        return self.__amount