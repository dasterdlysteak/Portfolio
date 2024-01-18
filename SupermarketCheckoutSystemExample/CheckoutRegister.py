from Product import *
from Transaction import*
from datetime import *
from SupermarketDAO import *


class CheckoutRegister:

    def __init__(self):
        self.__product_list = []
        self.__total_due = 0
        self.__amount_paid = 0
        self.__shopping_cart = []
        self.__database = SupermarketDAO('supermarket.db')
        self.read_products()

    # function used to populate the product_list
    def read_products(self):
        self.__product_list = self.__database.listAllProducts()

    def getProductList(self):
        return self.__product_list

    def getTotalDue(self):
        return self.__total_due

    def getAmountPaid(self):
        return self.__amount_paid

    def getShoppingCart(self):
        return self.__shopping_cart

    # function for matching a scanned barcode with a product
    def scan_item(self, barcode):
        # looping through product_list
        for index in range(len(self.__product_list)):
            # save each barcode as a variable
            barcode_in_list = self.__product_list[index].getBarCode()
            # checking if scanned barcode matches the barcode of the current loop
            if barcode == barcode_in_list:
                # if match is found, add the item to the shopping_cart and return the item to the user
                self.add_to_cart(self.__product_list[index])
                return f"{self.__product_list[index].getName()} {self.__product_list[index].getDescription()} - " \
                       f"${abs(self.__product_list[index].getPrice()):,.2f}"
        # if no match found return error message
        return "ERROR!: scanned Barcode is incorrect"

    # function for adding scanned item to the shopping_cart
    def add_to_cart(self, item):
        # appending item to shopping_cart list
        self.__shopping_cart.append(item)
        # adding the item total to the total_due
        self.__total_due += item.getPrice()

    # function for paying total_due
    def accept_payment(self, payment_amount):
        # validating a payment has a positive value
        if payment_amount < 0:
            return "ERROR! negative numbers not accepted"
        # tracking the amount paid by a customer
        self.__amount_paid += payment_amount
        # subtracting payment amount from total_due
        self.__total_due = self.__total_due - payment_amount
        # if total_due is negative, alert the customer of change to be given
        if self.__total_due < 0:
            print(f"Payment Accepted\nYour change is ${abs(self.__total_due):,.2f}")
        else:
            print("Payment Accepted")

    # function for printed a receipt to the customer
    def print_receipt(self):
        print("\n Receipt: \n")
        # variable to hold total of all products as total_due is 0 after payment
        total = 0
        # looping through shopping_cart and printing item description/price
        for index in range(len(self.__shopping_cart)):
            print(f"{self.__shopping_cart[index].getName()} {self.__shopping_cart[index].getDescription()} "
                  f"{abs(self.__shopping_cart[index].getPrice()):,.2f}")
            # adding the price of each item to the total variable
            total += self.__shopping_cart[index].getPrice()
            # printing the total that was due, the total amount paid, and the change given to the customer
        print(f"\nTotal amount due: ${total:,.2f}\nAmount paid: "
              f"${self.__amount_paid:,.2f}\nChange given: ${abs(self.__total_due):,.2f}")

    # a function for saving the transaction details
    def save_transaction(self):
        # opening the psuedo-database for writing
        #with open('transactions.txt', 'a') as transaction:
        #    # writing current date to transaction
        #    transaction.write(f"transaction on {datetime.date(datetime.now())}\n")
        #    # looping through the shopping_cart and appending the barcode and price to the transaction record
        for item in range(len(self.__shopping_cart)):
            transaction = Transaction(datetime.date(datetime.now()), self.__shopping_cart[item].getBarCode(),
                                      self.__shopping_cart[item].getPrice())
            self.__database.addTransaction(transaction)
        #        transaction.write(f"item: {item + 1} - {self.__shopping_cart[item].getBarCode()} "
        #                          f"{self.__shopping_cart[item].getPrice()}\n")
        #    transaction.write("\n")



