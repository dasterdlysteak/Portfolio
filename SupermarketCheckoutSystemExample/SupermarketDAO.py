import os
import sqlite3
from Product import *
from Transaction import *
from openpyxl import Workbook
from openpyxl.chart import BarChart, Reference


class SupermarketDAO:

    def __init__(self, db_name):
        self.__db_name = db_name

    # method used to add a product to the database
    def addProduct(self, product):
        try:
            # connect to the database
            con = sqlite3.connect(self.__db_name)
            # create a curser
            curs = con.cursor()
            # splitting the product object to be added into structured data for the DB entry
            values = (product.getBarCode(), product.getName(), product.getDescription(), product.getPrice())
            # executing sql query to insert product data into database
            curs.execute('''INSERT INTO transactions VALUES(?,?,?,?)''', values)

        except sqlite3.Error as error:
            # if an exception is caught notify the user and display appropriate error
            print("error storing transaction ", error)

        finally:
            # if connection is active, commit the changes and close the connection
            if(con):
                con.commit()
                con.close()

    def listAllProducts(self):
        try:
            # connect to DB
            con = sqlite3.connect(self.__db_name)
            curs = con.cursor()
            # fetching a list of products from the db
            product_list = curs.execute('''SELECT * FROM products''').fetchall()
            products = []
            # for each product retrieved from DB create a product object and append to the Products[] list
            for product in product_list:
                current_product = Product(product[0], product[1], product[2], product[3])
                products.append(current_product)
            # return the list of product objects
            return products
        except sqlite3.Error as error:
            # if an exception is caught notify the user and display appropriate error
            print("error fetching products ", error)
        finally:
            # if a connection is active close it
            if(con):
                con.close()

    def findProduct(self, barcode):
        # connect to the DB
        con = sqlite3.connect(self.__db_name)
        curs = con.cursor()
        # creating a query to select product based on passed in barcode
        result = curs.execute('''Select * FROM products WHERE barcode = (?)''', (barcode,)).fetchall()
        # separating each field in result in order to create a Product object
        for index in result:
            product = Product(index[0], index[1], index[2], index[3])
        # if active close connection
        if (con):
            con.close()
        # return Product object
        return product

    def listAllTransactions(self):
        try:
            # connect to the database
            con = sqlite3.connect(self.__db_name)
            curs = con.cursor()
            # fetching list or transactions from database
            transaction_list = curs.execute('''SELECT * FROM transactions''').fetchall()
            transactions = []
            # for each transaction create a transaction object
            for transaction in transaction_list:
                current_transaction = Transaction(transaction[0], transaction[1], transaction[2])
                # append each object to list
                transactions.append(current_transaction)
            # return the list of transaction objects
            return transactions
        # if there is an error notify the user and display appropriate error
        except sqlite3.Error as error:
            print("error fetching transactions", error)
        finally:
            # if DB connection active close it
            if(con):
                con.close()

    def displayBarchartOfProductsSold(self):
        # creating a workbook object
        workbook = Workbook()
        # designating a sheet in the workbook
        sheet = workbook.active
        # retrieving a list of transactions
        transactions = self.listAllTransactions()
        # creating dictionaries to hold a key and value
        quantity_dict = {}
        name_dict = {}
        # for each transaction in the list fill the name dictionary
        for transaction in transactions:
            # using the barcode from transaction to retrieve the name from the found product object
            name_dict[transaction.getBarcode()] = self.findProduct(transaction.getBarcode()).getName()
            # not present keeps track of whether this is the first time we are adding a particular entry into the
            # quantity dict
            not_present = True
            # for each transaction, loop through the quantity dict and search for an entry that has the same barcode
            for key in quantity_dict:
                # if the current transaction already exists in the dict add one to the quantity count for that entry
                if transaction.getBarcode() == key:
                    # not present prevents us from changing the quantity value to 1 in the next step
                    not_present = False
                    # adding one to the count
                    quantity_dict[transaction.getBarcode()] = quantity_dict[transaction.getBarcode()] + 1

            # if the barcode is not present in the quantity list create a new entry with the count of 1
            if not_present:
                quantity_dict[transaction.getBarcode()] = 1
        # appending the above worked out names and values into the spreadsheet
        rows = [['name', 'quantity']]
        # looping through each entry in the names dict and appending the name, also the corosponding
        # quantity from the quantity dict
        for key in name_dict:
            rows.append([name_dict[key], quantity_dict[key]])
        # setting the boundaries for the spreadsheet
        width = len(rows[0])
        height = len(rows)
        chart = BarChart()
        data = Reference(worksheet=sheet,
                         min_row=1,
                         max_row=height,
                         min_col=2,
                         max_col=width)
        # appending data to spreadsheet
        for row in rows:
            sheet.append(row)
        # referencing the titles in the spread sheet
        chart.add_data(data, titles_from_data=True)
        # setting the titles to use in the barchart
        title = str(Reference(sheet, min_col=1, max_col=1, min_row=2, max_row=height))
        # setting the titles to the categories in the barchart and the title for the chart itself
        chart.set_categories(title)
        chart.title = "Product Sales"
        # selecting the barchart and passing in the data
        sheet.add_chart(chart, "E2")

        # saving the completed spreadsheet
        workbook.save("product_bar_chart.xlsx")
        os.system(r"product_bar_chart.xlsx")  # Automatically open and display barchart
        print("Barchart created Successfully!")


    def addTransaction(self, transaction):
        try:
            # connect to database
            con = sqlite3.connect(self.__db_name)
            curs = con.cursor()
            # structuring the data passed in (from the transaction object)
            values = (transaction.getDate(), transaction.getBarcode(), transaction.getAmount())
            # query the database to add the structured data
            curs.execute('''INSERT INTO transactions VALUES(?,?,?)''', values)
        # if an error occurs notify the user and display appropriate error
        except sqlite3.Error as error:
            print("error storing transaction", error)

        finally:
            # if the connection is active commit changes and close
            if(con):
                con.commit()
                con.close()



    # date of transaction, barcode, name, and quantity
    def displayExcelReportOfTransactions(self):
        # creating a workbook and sheet to work with
        workbook = Workbook()
        sheet = workbook.active
        # retrieving the list of transactions
        transactions = self.listAllTransactions()
        # creating a list to hold values and adding titles to the list
        structured_data = [['Transaction Date', 'Barcode', 'Name']]

        for transaction in transactions:
            # for each transaction in list find the appropriate product
            product_details = self.findProduct(transaction.getBarcode())
            # creating a list with the details need from the transaction and the name from the corrosponding
            # product object
            value = [transaction.getDate(), transaction.getBarcode(),
                     product_details.getName()]
            # appending the above list to the structured data list
            structured_data.append(value)
        # Appending each list in the structured data list
        for row in structured_data:
            sheet.append(row)
        # saving the spreadsheet
        workbook.save('excel_report.xlsx')
        os.system(r'excel_report.xlsx')
        print("excel report created successfully")

