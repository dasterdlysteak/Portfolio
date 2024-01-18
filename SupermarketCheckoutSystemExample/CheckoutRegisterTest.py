import unittest
from CheckoutRegister import *
from Product import *


class CheckoutRegisterTestCase(unittest.TestCase):

    def setUp(self):
        self.user = CheckoutRegister()

    def test_scan_item(self):
        test_var = self.user.scan_item(111)
        self.assertEqual(test_var.strip(), "milk - 2 litres - $2.50")
        test_var = self.user.scan_item(112)
        self.assertEqual(test_var.strip(), "juice - 1 litre - $4.00")
        test_var = self.user.scan_item(113)
        self.assertEqual(test_var.strip(), "olive dip - 400g - $5.00")
        test_var = self.user.scan_item("aaa")
        self.assertEqual(test_var.strip(), "ERROR!: scanned Barcode is incorrect")
        test_var = self.user.scan_item(444)
        self.assertEqual(test_var.strip(), "ERROR!: scanned Barcode is incorrect")

    def test_accept_payment(self):
        self.user.scan_item(111)
        error = self.user.accept_payment(-6)
        self.assertEqual("ERROR! negative numbers not accepted", error)
        works = self.user.accept_payment(2.50)
        self.assertEqual(0, self.user.getTotalDue())

    def test_Product_list(self):
        list = self.user.getProductList()
        barcode_list = ["111", "112", "113"]
        for index in range(3):
            self.assertIsInstance(list[index], Product, "this is not a Product Object")
            self.assertEqual(list[index].getBarCode(), barcode_list[index])

    def test_total_due(self):
        self.user.scan_item("aaa")
        total_due = self.user.getTotalDue()
        self.assertEqual(total_due, 0)
        self.user.scan_item(111)
        total_due = self.user.getTotalDue()
        self.assertEqual(total_due, 2.50)
        self.user.scan_item(112)
        total_due = self.user.getTotalDue()
        self.assertEqual(6.50, total_due)



    def test_amount_paid(self):
        self.assertEqual(self.user.getAmountPaid(), 0)
        self.user.scan_item(112)
        self.user.accept_payment(4.00)
        self.assertEqual(self.user.getAmountPaid(), 4.00)

    def test_Shopping_cart(self):
        product_list = self.user.getProductList()
        self.user.add_to_cart(product_list[0])
        cart_item = self.user.getShoppingCart()
        self.assertIsInstance(cart_item[0], Product)
        self.assertEqual(product_list[0], cart_item[0])

    def test_product_getters(self):
        product = Product(111, "Milk - 2 litres", 2.50)
        barcode = product.getBarCode()
        description = product.getDescription()
        price = product.getPrice()
        self.assertEqual(barcode, 111)
        self.assertEqual(description, "Milk - 2 litres")
        self.assertEqual(price, 2.50)



