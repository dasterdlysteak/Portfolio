from SupermarketDAO import *
import hashlib
from Product import *
import sys


def product_bubble_sort(product_list):
    # looping to get each list element
    for item in range(len(product_list)):
        # looping to compare list elements
        for index in range(0, (len(product_list) - item - 1)):
            # if the current elements barcode is bigger the next elements barcode swap those elements
            if product_list[index].getBarCode() > product_list[index + 1].getBarCode():
                (product_list[index], product_list[index + 1]) = (product_list[index + 1], product_list[index])
    # return sorted list
    return product_list

# same as above except comparing by transaction data instead of barcode
def transaction_bubble_sort(transaction_list):
    for item in range(len(transaction_list)):
        for index in range(0, (len(transaction_list) - item - 1)):
            if transaction_list[index].getDate() > transaction_list[index + 1].getDate():
                (transaction_list[index], transaction_list[index + 1]) = (transaction_list[index + 1],
                                                                          transaction_list[index])
    return transaction_list


def main():

    """
    code used to create the bin file and store the demo username password combo
    user_name = "jesse"
    password = "password"
    credentials = f"{user_name}_{password}"

    with open('login.bin', 'wb') as file:
        file.write(hashlib.sha512(credentials.encode('utf-8')).digest())
        file.close()
    """
    # creating a database object for later use
    database = SupermarketDAO('supermarket.db')
    # a variable to manage the login loop
    login_success = False
    print("Welcome to the supermarket Admin system\nplease enter your credentials")
    # using the bin file for verification
    with open('login.bin', 'rb') as file:
        database_password = file.read()
        # loops until successfully logged in
        while not login_success:
            # collecting credentials from user
            user_name = input("Username: ")
            password = input("Password: ")
            # combining inputs and hashing the result
            credentials = f"{user_name}_{password}"
            credentials = hashlib.sha512(credentials.encode('utf-8')).digest()
            # if credentials match break login loop if not repeatedly ask for credentials until valid
            if credentials == database_password:
                login_success = True
                print("Login successful")
            else:
                login_success = False
                print("Login details do not match try again")

    continue_prompt = True
    # looping through the menu options until the program is terminated
    while continue_prompt:
        # printing a menu for the user
        print("====================================Menu====================================\n"
              "a. Add Products to Database\n"
              "b. List all Products in Database (Ascending order of Product bar-code)\n"
              "c. Find a Product in the Database, based on Product Bar-Code\n"
              "d. List All Transactions (Ascending order of date of transaction)\n"
              "e. Display a Bar chart of Products sold by quantity\n"
              "f. Display an Excel report of all transactions.\n"
              "g. Exit\n"
              "=============================================================================\n")
        user_choice = input("Please choose a menu option: ").lower()

        # switch statement for menu choice management
        match user_choice:
            case "a":
                print("Add a Product to DB\nplease enter product details to be added")
                # validating input data
                while True:
                    barcode = input("Barcode: ")
                    if not barcode.strip(" "):
                        print("Barcode cannot be blank")
                    else:
                        print(barcode)
                        break
                while True:
                    name = input("Name: ")
                    if not name.strip(" "):
                        print("Name cannot be blank")
                    else:
                        break
                while True:
                    description = input("Description: ")
                    if not description.strip(" "):
                        print("Description cannot be blank")
                    else:
                        break
                while True:
                    try:
                        price = float(input("Price: "))
                        break
                    except ValueError:
                        print("The price must be a number")
                # creating a product object from the inputs
                product_to_add = Product(barcode, name, description, price)
                # passing product object to the addProduct method
                success = database.addProduct(product_to_add)
                if success:
                    print("Product successfully added to DB")
                else:
                    print("Error adding product to DB")

                input("Press any key to continue")
            case "b":
                # requesting the product list from the database
                product_list = database.listAllProducts()
                # sorting the return product list
                product_list = product_bubble_sort(product_list)
                num = 1
                # print out of products
                for product in product_list:
                    print(f"========Item{num}========")
                    print(product.__str__())
                    num += 1
                input("Press any key to continue")

            case "c":
                # collecting barcode for request
                print("Please enter a product barcode to find")
                barcode = input("Barcode: ")
                print("====================")
                # querying the barcode against the database returning a product object
                print(database.findProduct(barcode).__str__())
                print("====================")
            case "d":
                # requesting the transaction list from the database
                transaction_list = database.listAllTransactions()
                # sorting the returned list
                transaction_list = transaction_bubble_sort(transaction_list)
                num = 1
                # print out transaction details
                for transaction in transaction_list:
                    print(f"========Item{num}========")
                    print(transaction.__str__())
                    num += 1
                input("Press any key to continue")
            case "e":
                # requesting a barchart to be made in the database object
                database.displayBarchartOfProductsSold()
                input("Press any key to continue")

            case "f":
                # requesting an excel report to be made in the database object
                database.displayExcelReportOfTransactions()
                input("Press any key to continue")

            case "g":
                # closing the program
                sys.exit()



main()

