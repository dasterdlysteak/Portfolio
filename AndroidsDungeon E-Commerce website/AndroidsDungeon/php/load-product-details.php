<?php
include_once("../php/Product.php");
    if (isset($_GET['id'])) {

        $productID = htmlspecialchars($_GET['id']);
    } else {
        echo "<p>Invalid request. Product ID not provided.</p>";
    }
    require_once('conn_contract_db.php');


    // preparing query
    $query = "SELECT * FROM product where (ProductID = ?)";
    $stmt = $mysqli -> prepare($query);
    // Preparing Statement
    $stmt -> bind_param("i", $productID );
    // execute statement
    $stmt -> execute();
    $result = $stmt -> get_result();

    if($result->num_rows == 1) {
        $row = $result -> fetch_array();
        $product = new Product($row["ProductID"], $row["Title"], $row["Author"], $row["Description"], $row["Genre"], $row["Price"], $row["Qty"],$row["Image"]);
        echo "<div class='col2'>";
        echo "<img src='". $product->get_image() ."' alt='". $product->get_title() ." image' width='100%'>";
        echo "</div>";
        echo "<div class='col2'>";
        echo "<form action='../php/add_to_cart.php' method='post'>";
        echo "<p>Home / Manga</p>";
        echo "<h1>". $product->get_title() ."</h1>";
        echo "<h4>". $product->get_author() ."</h4>";
        echo "<h4>". $product->get_genre() ."</h4>";
        echo "<h4>$". $product->get_price() ."</h4>";
        echo "<input class='pinput' type='number' name='qty' value='1'>";
        echo "<input type='hidden' name='id' value='". $product->get_id() ."'>";
        echo "<input type='submit' name='Submit' value='Add To Cart' class='btn'>";
        //echo "<a href='#' class='btn'>Add to Cart</a>";
        echo "</form>";
        echo "<h3>Product Details <i class='fa fa-indent'></i></h3>";
        echo "<br>";
        echo "<p>". $product->get_description() ."</p>";
        echo "</div>";
    }
    else {
        echo("<h2>Something didnt work retreiving from the Products Table<h2>");
        exit();
    }

    
    
    
    
    
    
    
    

?>