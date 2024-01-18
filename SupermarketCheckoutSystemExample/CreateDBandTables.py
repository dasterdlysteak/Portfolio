
import sqlite3

try:
    products = [('106', 'Beer', '6-Pack', 18.75),
                ('107', 'Bacon', '450g', 6.45),
                ('108', 'Salami', '200g', 3.00),
                ('109', 'Bread', '650g', 4.50),
                ('110', 'Cereal', '700g', 8.00),
                ('101', 'Milk', '2-Litres', 4.50),
                ('102', 'Juice', '1-Litre', 3.80),
                ('103', 'Olive Dip', '400g', 3.50),
                ('104', 'Cheese', '350g', 5.00),
                ('105', 'Crackers', '300g', 2.50)
                ]
    con = sqlite3.connect('supermarket.db')
    curs = con.cursor()
    print("database connected")
    curs.execute('''CREATE TABLE products (
    barcode TEXT,
    name TEXT,
    description TEXT,
    price REAL
    )''')
    curs.execute('''CREATE TABLE transactions (
        date TEXT,
        barcode TEXT,
        amount REAL
        )''')
    print("product and transaction tables created")
    curs.executemany('''INSERT INTO products VALUES(?,?,?,?)''', products)
    print("values added to DB")
    test = curs.execute('''SELECT * FROM products''').fetchall()
    print(test)
except sqlite3.Error as error:
    print("error connecting to database", error)

finally:
    if (con):
        con.commit()
        con.close()
        print("connection closed")
