<?php
    session_start();
    include 'Cart.php';
    include 'phpcreditcard.php';
    if (isset($_SESSION['cart'])){
        $cart = new Cart();
        $cart = unserialize($_SESSION['cart']);
    }
    else{
        echo "<h1>Please Add Items To Cart to Make Purchases</h1>";
        echo "<a href='../html/products.php' class='btn'>Return to Products</a>";
    }

    $cardName = $_POST['card_name'];
    $cardNumber = $_POST['card_number'];
    $expiry = $_POST['expireMM']."/".$_POST['expireYY'];
    $customerID = $_SESSION['customer_id'];
    $ccv = $_POST['ccv'];
    $total =  $cart->get_total();
    $nullValue = NULL;
    $visa = "visa";


    if (($cardName == "") or ($cardNumber == "") or ($expiry == ""))
    {
        echo "<h1>Please fill in required fields</h1>";
        echo "<a href='../html/payment_gateway.php' class='btn'>Return to Payment Details</a>";
    }
    else if(!checkCreditCard ($cardNumber, $visa, $errornumber, $errortext)){
        echo "<h1>".$errortext."</h1>";
        echo "<a href='../html/payment_gateway.php' class='btn'>Return to Payment Details</a>";

    }
    else 
    {
        // connect to the db
        require_once('conn_contract_db.php');
        // defining queries
        $query1 = "INSERT INTO `Order` (OrderTotal, CustomerID) VALUES(?, ?)";
        $query2 = "INSERT INTO OrderProduct VALUES(?, ?, ?)";
        $query3 = "INSERT INTO PaymentDetails VALUES(?, ?, ?, ?, ?, ?)";

        try {
            $stmt = $mysqli->prepare($query1);
            //Bind the parameters
            $stmt->bind_param("di", $total, $customerID);
            //Execute the query
            $stmt -> execute();
        
        } catch(Exception $ex){
            error_log($ex -> getMessage());
            echo "<h1>".$customerID ."Error Querying Database first query</h1>";
            //exit($ex->getMessage());

        }
        try {
            $orderID = $mysqli->insert_id;
            $_SESSION['order-id'] = $orderID;
            $stmt = $mysqli->prepare($query2);
            //Bind the parameters
            for ($i = 0; $i < $cart->get_depth(); $i++){
                $currentProduct = $cart->get_product($i);
                $productID = $currentProduct->get_id();
                $qtyOrdered = $currentProduct->get_qty_ordered();
                $stmt -> bind_param("sii", $orderID, $productID, $qtyOrdered);
                //Execute the query
                $stmt -> execute();
            }
        } catch(Exception $ex){
            error_log($ex -> getMessage());
            exit("Error Querying Database third query");
        }
        try {
            $stmt = $mysqli->prepare($query3);
            //Bind the parameters
            $stmt -> bind_param("sssiis", $cardNumber, $expiry, $ccv, $customerID, $orderID, $cardName);
            //Execute the query
            $stmt -> execute();
            $mysqli -> close();
        
        } catch(Exception $ex){
            error_log($ex -> getMessage());
            exit("Error Querying Database fourth query".$ex);
        }
        
        header("Location: ../html/thankyou.php");
    }
?>