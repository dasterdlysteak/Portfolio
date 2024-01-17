<?php
    try{
        include_once("conn_contract_db.php");
        include_once (__DIR__ . '/../php/Product.php');

        $query = "SELECT * FROM product";
        $stmt = $mysqli->prepare($query);
        $stmt->execute();
        $result = $stmt->get_result();

        while($row = $result->fetch_assoc()){
            $product = new Product($row["ProductID"], $row["Title"], $row["Author"], $row["Description"], $row["Genre"], $row["Price"], $row["Qty"],$row["Image"]);

            
            echo "<a class='col4' href='product_details.php?id=". $product->get_id() ."'>";
            echo "<img src='". $product->get_image() ."' alt='". $product->get_title() ." image'>";
            echo "<h4>". $product->get_title() ."</h4>";
            echo "<div class='rating'>";
            echo  "<i class='fa fa-star'></i>";
            echo  "<i class='fa fa-star'></i>";
            echo  "<i class='fa fa-star'></i>";
            echo  "<i class='fa fa-star'></i>";
            echo  "<i class='fa fa-star-half-o'></i>";
            echo "</div>";
            echo "<p>$". $product->get_price() ."</p>";
            echo "</a>";
        }
        $mysqli->close();


    }
    catch(Exception $ex){
        error_log($ex->getMessage());
        echo $ex;
    }
    
?>