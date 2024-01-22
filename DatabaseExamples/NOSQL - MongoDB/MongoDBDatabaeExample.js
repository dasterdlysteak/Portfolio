// Task 2:
use shoppingCartDB
db.createCollection("customers")
db.createCollection("shopping_carts")
db.createCollection("items")
db.createCollection("suppliers")


// Task 3: part a
db.customers.insertOne({
	customerID: 1,
	firstName: "John",
	lastName: "Brown",
	email: "jbrown100@yahoo.com",
	annualSpend: 100.00,
	phones: [{
		phoneNumber: "0427788128",
		phoneType: "Personal"
	}],
	addresses: [{
		addressType: "Business",
		street: "1st Street",
		city: "Adelaide",
		postalCode: "5000",
		state: "SA",
		country: "Australia"
	}],
	interests: [
		{interestName:"Furniture"},
		{interestName:"Electrical"}
	]
})

db.customers.insertOne({
	customerID: 2,
	firstName: "Jack",
	lastName: "White",
	email: "jwhite200@yahoo.com",
	annualSpend: 200,
	phones: [
		{phoneNumber: "0414237921", phoneType: "Personal"},
		{phoneNumber:"08-81091122", phoneType:"Business"}
	],
	addresses: [
		{addressType: "Personal",
		street: "2nd Street",
		city: "Melbourne",
		postalCode: "3001",
		state: "VIC",
		country: "Australia"},
		{addressType: "Postal",
		street: "Box 300 Richmond Post Office",
		city: "Richmond",
		postalCode: "3121",
		state: "VIC",
		country:"Australia"}
	],
	interests: [
		{interestName: "Gardening"},
		{interestName: "Electronic"},
		{interestName: "Furniture"}
	]
})

db.customers.insertOne({
	customerID: 3,
	firstName: "Jill",
	lastName: "Black",
	email: "jblack300@yahoo.com",
	annualSpend: 300.00,
	phones: {
		phoneNumber: "08-85678888",
		phoneType: "Business"
	},
	addresses: [
		{addressType: "Business",
		street: "10th Main Street",
		city: "Blackwood",
		postalCode: "5051",
		state: "SA",
		country: "Australia"},
		{addressType: "Postal",
		street: "Box 400 Blackwood Post Office",
		city: "Blackwood",
		postalCode: "5051",
		state: "SA",
		country: "Australia"},
		{addressType: "Personal",
		street: "5 High Street",
		city: "Belair",
		postalCode: "5052",
		state: "SA",
		country: "Australia"}
    ],
	interests: [{
		interestName: "Furniture"}]
})

// Task 3: part b
db.items.insertMany([	
	{itemID: 1,
	itemName: "Slow release fertiliser 20kg",
	price: 40.00,
	qtyOnHand: 10,
	supplierID: 1},
	{itemID: 2,
	itemName: "Organic fertiliser 20kg",
	price: 50.00,
	qtyOnHand: 20,
	supplierID: 1},
	{itemID: 3,
	itemName: "METHOD wall cabinet",
	price: 400.00,
	qtyOnHand: 30,
	supplierID: 2},
	{itemID: 4,
	itemName: "Applaro outdoor sofa set",
	price: 1500.00,
	qtyOnHand: 40,
	supplierID: 2}

])

// Task 3: part c
db.shopping_carts.insertOne({
    customerID: 1,
	cartDate: ISODate("2022-02-20 12:00:00"),
	deliveryInstructions: "Deliver to business address",
	deliveredOrNot: 1,
	deliveryDate: ISODate("2022-02-22"),
	ratingFromCustomer: "5",
	cart_items:[
		{itemID: 1,
		qtyOrdered: 2},
		{itemID: 2,
		qtyOrdered: 3}
	]
})

db.shopping_carts.insertOne({
	customerID: 2,
	cartDate: ISODate("2022-02-20 14:30:00"),
	deliveryInstructions: "Deliver to personal address",
	deliveredOrNot: 1,
	deliveryDate: ISODate("2022-02-23"),
	ratingFromCustomer: "4",
	cart_items:[
		{itemID: 3,
		qtyOrdered: 1},
		{itemID: 4,
		qtyOrdered: 1},
		{itemID: 1,
		qtyOrdered: 3}
	]
})
db.shopping_carts.insertOne({
	customerID: 2,
	cartDate: ISODate("2022-02-22 16:00:00"),
	deliveryInstructions:"",
	deliveredOrNot: 0,
	deliveryDate: "",
	ratingFromCustomer: "",
	cart_items:[{
		itemID: 1,
		qtyOrdered: 4
	}]
})
db.shopping_carts.insertOne({
	customerID: 3,
	cartDate: ISODate("2022-02-23 09:30:00"),
	deliveryInstructions: "Deliver to delivery address",
	deliveredOrNot: 0,
	deliveryDate: "",
	ratingFromCustomer: "",
	cart_items:[{
		itemID: 2,
		qtyOrdered: 2
	}]
})

// Task 3: part d
db.suppliers.insertOne({
	supplierID: 1,
	supplierName: "Garden Grower",
	email: "business@gardensupplier.com.au",
	contactPhoneNo: "80-27732420",
	addresses:[
		{addressType: "business",
		street: "1 King Street",
		city: "Adelaide",
		postalCode: "5000",
		state: "SA",
		country: "Australia"},
		{addressType: "Postal",
		street: "Box 100 Grote Street Mail Centre",
		city: "Adelaide",
		postalCode: "5000",
		state: "SA",
		country: "Australia"}
	]
})

db.suppliers.insertOne({
	supplierID: 2,
	supplierName: "Home Improvement",
	email: "office@homeimprovement.com.au",
	contactPhoneNo: "08-82544665",
	addresses:[
		{addressType: "Business",
		street: "2 Queen Street",
		city: "Melbourne",
		postalCode: "3000",
		state: "VIC",
		country: "Australia"},
		{addressType: "Postal",
		street: "Box 200 Bourke Street Post Office",
		city: "Melbourne",
		postalCode: "3000",
		state: "VIC",
		
		country: "Australia"}
	]
})

// Task 4: part a
db.customers.find()


// Task 4: part b
//db.suppliers.find({supplierName: "Home Improvement"}, {_id: 0, supplierID: 0, addresses: 0})
db.suppliers.aggregate([
	{
		$match: {supplierName: "Home Improvement"}
	},
	{
		$lookup: 
		{
			from: "items",
			localField: "supplierID",
			foreignField: "supplierID",
			as: "items_supplied",	
		}
	},
	{
		$project: {_id: 0, supplierID: 0, addresses: 0, items_supplied: {_id: 0, supplierID: 0}}
	}
])

// Task 4: part c
db.shopping_carts.aggregate([
    {
        $match: {cartDate: ISODate("2022-02-20 14:30:00")}
    },
    {
        $lookup:
        {
            from: "items",
            localField: "cart_items.itemID",
            foreignField: "itemID",
            as: "items_in_cart"
        }
    },
    {
        $project: {cartID: 0, ratingFromCustomer: 0, cart_items: {qtyOrdered: 0}}
    }
])

/*a. Create another database named “shoppingCartDB2”. This time, in the new database, create a schema validation for the customer collection which you have design in Part 1 Task 7. The validator must:

i. Define the data fields with correct MongoDB data types that matched with the existing sample data. The type must cover the numeric, string, boolean, complex type like embedded object type. Provide an appropriate description of each field defined.

ii. Define all data fields as “required” with the exception of the following fields are not required:

1) customers.email

2) customers.firstName & customers.lastName (Note” later we may use company name instead)

3) carts.ratingFromCustomer

iii. The customer_address.addressType are restricted to these values (i.e. enum data type) e.g. “Postal”, “Delivery”, “Business”.

iv. annualSpend has minimum amount $0.00.
db.customers.insertOne({
	customerID: 1,
	firstName: "John",
	lastName: "Brown",
	email: "jbrown100@yahoo.com",
	annualSpend: 100.00,
	phones: {
		phoneNumber: "0427788128",
		phoneType: "Personal"
	},
	addresses: {
		addressType: "Business",
		street: "1st Street",
		city: "Adelaide",
		postalCode: "5000",
		state: "SA",
		country: "Australia"
	},
	interests: [
		{interestName:"Furniture"},
		{interestName:"Electrical"}
	]
})*/
// Task 5: part a
db.createCollection("customers", {
    validator: {
        $jsonSchema: {
            bsonType: "object",
            required: ["customerID", "annualSpend", "phones", "addresses", "interests"],
            properties: {
                customerID: {
                    bsonType: "int",
                    description: "an integer identifying the customer, is required"
                },
                firstName: {
                    bsonType: "string",
                    description: "is a string and is not required"
                },
                lastName: {
                    bsonType: "string",
                    description: "is a string and is not required"
                },
				email: {
					bsonType: "string",
					description: "is a string and not required"
				},
				annualSpend: {
					bsonType: ["double", "int"],
					minimum: 0.00,
					description: "is a decimal and is required"
				},
				phones: {
					bsonType: ["array"],
					items: {
						bsonType: "object",
						required: ["phoneNumber", "phoneType"],
						properties: {
							phoneNumber:{
								bsonType: "string",
								description: "is a string and is required"
							},
							phoneType:{
								bsonType: "string",
								description: "is a string and is required"}
						}
					}
				},
				addresses: {
					bsonType: ["array"],
					items: {
						bsonType: "object",
						required: ["addressType", "street", "city", "postalCode", "state", "country"],
						properties: {
							addressType: {
								bsonType: "string",
								enum: ["Postal", "Delivery", "Business"],
								description: "is a string and is required"
							},
							street: {
								bsonType: "string",
								description: "is a string and is required"
							},
							city: {
								bsonType: "string",
								description: "is a string and is required"
							},
							postalCode: {
								bsonType: "string",
								description: "is a string and is required"
							},
							state: {
								bsonType: "string",
								description: "is a string and is required"
							},
							country: {
								bsonType: "string",
								description: "is a string and is required"
							}
						}
					}
				},
				interests: {
					bsonType: ["array"],
					items: {
						bsonType: "object",
						required: ["interestName"],
						properties: {
							interestName: {
								bsonType: "string",
								description: "is a string and is required"
							}
						}
					}
				}
			}
		}
    }
})

// Task 5: part b
// Im not sure why this would fail validation as email is not required: ask alex if KT was having a stronk
db.customers.insertOne({
	customerID: 1,
	firstName: "John",
	lastName: "Brown",
	annualSpend: 100.00,
	phones: [{
		phoneNumber: "0427788128",
		phoneType: "Personal"
	}],
	addresses: [{
		addressType: "Business",
		street: "1st Street",
		city: "Adelaide",
		postalCode: "5000",
		state: "SA",
		country: "Australia"
	}],
	interests: [
		{interestName:"Furniture"},
		{interestName:"Electrical"}
	]
})

//II
db.customers.insertOne({
	customerID: 1,
	firstName: "John",
	lastName: "Brown",
	email: "jbrown100@yahoo.com",
	annualSpend: 100.00,
	phones: [{
		phoneNumber: "0427788128",
		phoneType: "Personal"
	}],
	addresses: [{
		addressType: "Personal",
		street: "1st Street",
		city: "Adelaide",
		postalCode: "5000",
		state: "SA",
		country: "Australia"
	}],
	interests: [
		{interestName:"Furniture"},
		{interestName:"Electrical"}
	]
})
//III
db.customers.insertOne({
	customerID: 1,
	firstName: "John",
	lastName: "Brown",
	email: "jbrown100@yahoo.com",
	annualSpend: -100.00,
	phones: [{
		phoneNumber: "0427788128",
		phoneType: "Personal"
	}],
	addresses: [{
		addressType: "Business",
		street: "1st Street",
		city: "Adelaide",
		postalCode: "5000",
		state: "SA",
		country: "Australia"
	}],
	interests: [
		{interestName:"Furniture"},
		{interestName:"Electrical"}
	]
})

// Task 6: part 1
db.customers.insertOne({
	customerID: 10,
	companyName: "City Shopper Co. Ltd",
	website: "cityshopper.com.au",
	registeredDate: ISODate("2022-05-01 00:00:00"),
	annualSpend: 0.00,
	phones: [{
		phoneType: "Business",
		phoneNumber: "08-82778888"
	}],
	addresses: [{
		addressType: "Business",
		street: "1 First Street",
		city: "Adelaide",
		postalCode: "5000",
		state: "SA",
		country: "Australia"
	}],
	interests: [
		{interestName:"Gardening"},
		{interestName:"Tools"},
		{interestName: null}// this will fail validation
	]
})
// same again without null validation issue
db.customers.insertOne({
	customerID: 10,
	companyName: "City Shopper Co. Ltd",
	website: "cityshopper.com.au",
	registeredDate: ISODate("2022-05-01 00:00:00"),
	annualSpend: 0.00,
	phones: [{
		phoneType: "Business",
		phoneNumber: "08-82778888"
	}],
	addresses: [{
		addressType: "Business",
		street: "1 First Street",
		city: "Adelaide",
		postalCode: "5000",
		state: "SA",
		country: "Australia"
	}],
	interests: [
		{interestName:"Gardening"},
		{interestName:"Tools"},
		{interestName: ""}  
	]
})

db.customers.insertOne({
	customerID: 11,
	companyName: "Country Shopper Co. Ltd",
	registeredDate: ISODate("2022-05-15 00:00:00"),
	annualSpend: 100.00,
	phones: [{
		phoneType: "Business",
		phoneNumber: "08-82774444 "
	}],
	addresses: [{
		addressType: "Business",
		street: "2 second Street",
		city: "Adelaide",
		postalCode: "5000",
		state: "SA",
		country: "Australia"
	}],
	interests: [
		{interestName:"Power Tools"},
		{interestName:"Kitchenware"},
		
	]
})

//Task 6: part b
db.customers.find()
	
//Task 7: part a
db.customers.updateOne( 
	{ companyName: "City Shopper Co. Ltd" },
	{ $set: {website: "supershopper.com" }}
	)

//Task 7: part b
db.customers.updateMany(
	{ "addresses.postalCode" : "5000"},
	{ $set: {registeredDate: ISODate("2022-05-15 17:00:00")}}
)

//Task 7: part c
db.customers.deleteOne({companyName: "City Shopper Co. Ltd"})

//Task7: part d
db.customers.deleteMany({
	$and: [
		{registeredDate: {$lte: ISODate("2022-05-16 17:00:00")}}, {registeredDate: {$gt: ISODate("2022-05-01 00:00:00")}}
	]
})