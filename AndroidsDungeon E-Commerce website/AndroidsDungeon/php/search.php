<?php
    include('conn_contract_db.php');
    include('Product.php');
    
    
    if(isset($_POST["input"])){
        $param = "%".$_POST["input"]."%";



        //get the search key from the form

        if($param != ""){
            $query = "SELECT * FROM product WHERE Title LIKE ?";
            $stmt = $mysqli->prepare($query);
            // Preparing Statement
            $stmt -> bind_param("s", $param);
            // execute statement
            $stmt -> execute();
            $result = $stmt -> get_result();
            if($result->num_rows > 0){
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
            }
            else{
                echo "<div class='col4'>";
                echo "<h2>No Results Found</h2>";
                echo "</div>";
                echo "<br>";
                echo "<img  width='50%' height='auto' src='../image/error-img.png' alt='Error image'>";
                $_POST["input"] = "";
            
            }
            $mysqli->close();
            $_POST["input"] = "";
        }
    }
    else{
        echo "<h2>Search our Catalogue!</h2>";
        echo "<img  width='32%' height='auto' src='../image/search-img.png' alt='anime image'>";
        $_POST["input"] = "";

    }
?>
