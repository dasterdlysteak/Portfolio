<?php 
    //Start the session
    session_start();
    include 'Cart.php';
    
    //get the product_id and the quantity
    $product_id= $_POST["id"];
    $qty= $_POST["qty"];
    
    //store number of products in the shopping cart
    $counter = $_SESSION['counter'];
    $cart = new Cart();
    
    //unserialize the cart if the cart is not empty
    if ((isset($_SESSION['counter'])) && ($_SESSION['counter'] !=0)){
        $counter = $_SESSION['counter']; 
        //	unserialize convert the session object which is a string to a cart object
        $cart = unserialize($_SESSION['cart']);
    }  
    else {
        $_SESSION['counter'] = 0;
        $_SESSION['cart'] = "";
    }
    if (($product_id == "")or ($qty < 1))
    {
       //Redirect the user back to product page
       //header("Location:../html/products.php");
       exit();
    }
    else
    {
        //connect to server and select database
        require_once("conn_contract_db.php");
    
        //Create a select query to retrive the selected product 
        $query = "SELECT * FROM product WHERE (ProductID = ?)";
    
        //Run the mysql query
        $stmt = $mysqli->prepare($query);
        $stmt->bind_param("i", $product_id); 
        echo $product_id;
        $stmt->execute();
        $result = $stmt->get_result();
        //If there is a matching record select product_name, unit_price
        if(mysqli_num_rows($result) == 1)
        {
            //add products to the cart
            $row = $result -> fetch_assoc();
            $new_product = new Product($row["ProductID"], $row["Title"], $row["Author"], $row["Description"], $row["Genre"], $row["Price"], $row["Qty"],$row["Image"]);
            $new_product->set_qty_ordered($qty);
            $cart->add_product($new_product);
    
            //update the counter
            //print_r($cart);
            $_SESSION['counter'] = $counter+1;
            $_SESSION['cart'] = serialize($cart);
            //Redirect to the view_cart.php
            header("Location:../html/cart.php");
            exit();
        
        }
        else
        {
            //Redirect to back to the product page
            header("Location:../html/products.php");
            exit();
        }
        $mysqli->close();
    }
        

?>