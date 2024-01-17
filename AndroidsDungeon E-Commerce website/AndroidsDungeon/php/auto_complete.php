<?php
    include('conn_contract_db.php');
    include('Product.php');
    
    $param = "%".$_GET["title"]."%";



    //get the search key from the form

    if($param != ""){
        $query = "SELECT * FROM product WHERE Title LIKE ? LIMIT 5";
        $stmt = $mysqli->prepare($query);
        // Preparing Statement
        $stmt -> bind_param("s", $param);
        // execute statement
        $stmt -> execute();
        $result = $stmt -> get_result();
        while($row = $result->fetch_assoc()){
            $product = new Product($row["ProductID"], $row["Title"], $row["Author"], $row["Description"], $row["Genre"], $row["Price"], $row["Qty"],$row["Image"]);
            echo "<li>";
            echo "<a href='product_details.php?id=".$product->get_id()."'>".$product->get_title()."</a>";
            echo "</li>";
        }
        $mysqli->close();
    }
?>
