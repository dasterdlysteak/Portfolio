from CheckoutRegister import *


def main():
    user = CheckoutRegister()
    continue_switch = True

    # while loop that deals with collecting input for scanning barcode as well as whether to continue scanning
    while continue_switch:
        # while loop for testing if the ValueError exception is triggered by the barcode
        while True:
            try:
                scanner = input("Please enter a barcode: ")
                # if exception not triggered break the loop
                break
            except ValueError:
                # if exception triggered loop continues to prompt user
                print("the barcode wasn't a number")
        print(user.scan_item(scanner))
        continue_prompt = input("Would you like to scan another item? (Y/N): ").upper()

        # testing loop that makes sure correct input is used
        while True:
            if continue_prompt == "Y":
                break
            elif continue_prompt == "N":
                break
            else:
                print("ERROR! - Unrecognised input")
                continue_prompt = input("Would you like to scan another item? (Y/N): ").upper()
        if continue_prompt == "N":
            # break the main barcode loop
            continue_switch = False

    # loop continues running until there is no longer an amount to pay
    while user.getTotalDue() > 0:
        # validation loop for negative numbers
        while True:
            print(f"Amount due: ${user.getTotalDue():,.2f}")
            try:
                payment_amount = float(input("Enter an Amount to pay: "))
                assert payment_amount > 0
                break
            except AssertionError:
                print("ERROR! negative numbers not accepted")
            except ValueError:
                print("ERROR! payment must be a number")
        user.accept_payment(payment_amount)

    user.print_receipt()
    user.save_transaction()

main()

