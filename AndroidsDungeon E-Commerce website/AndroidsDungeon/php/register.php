<?php
    //Getting user inputs from form
    $first_name=$_POST['first_name'];
    $last_name=$_POST['last_name'];
    $email=$_POST['email'];
    $phone=$_POST['phone'];
    $street_address=$_POST['street_address'];
    $suburb=$_POST['suburb'];
    $postcode=$_POST['postcode'];
    $city=$_POST['city'];
    $password=$_POST['password'];
    $repassword=$_POST['repassword'];

    if (($first_name == "") or ($last_name == "") or ($email == "")or ($street_address == "") or ($suburb == "") or ($postcode == "") 
    or ($city == "") or ($phone == "") or ($password == "") or ($repassword == ""))
    {
        echo("Please fill in required fields");
        echo "<a href='../html/register.html' class='btn'>Return to Registration</a>";
    }
    /*No blank fields are allowed

· The password must have a second confirmation password field to ensure it has been correctly entered

· Telephone number must be numeric

· Email address should contain @ and .*/
    elseif (!(strstr($email, "@")) or !(strstr($email, ".")))
    {
        echo("Please enter a valid email");
        echo "<a href='../html/register.html' class='btn'>Return to Registration</a>";
    }
    elseif (!(is_numeric($phone)))
    {
        echo("Please enter a valid telephone number");
        echo "<a href='../html/register.html' class='btn'>Return to Registration</a>";
    }
    elseif ($password != $repassword)
    {
        echo("Passwords do not match, Please Try Again");
        echo "<a href='../html/register.html' class='btn'>Return to Registration</a>";
    }
    else 
    {
        // connect to the db
        require_once('conn_contract_db.php');
        // defining queries
        $key = "123abc";
        $password = crypt($password, $key);
        $query1 = "INSERT INTO customer (FirstName, LastName, Email, Phone) VALUES(?, ?, ?, ?)";
        $query2 = "SELECT CustomerID FROM Customer WHERE Email LIKE ?";
        $query3 = "INSERT INTO `address` VALUES(?, ?, ?, ?, ?)";
        $query4 = "INSERT INTO login_details VALUES(?, ?, ?)";

        try {
            $stmt = $mysqli->prepare($query1);
            //Bind the parameters
            $stmt -> bind_param("ssss", $first_name, $last_name, $email, $phone);
            //Execute the query
            $stmt -> execute();
        
        } catch(Exception $ex){
            error_log($ex -> getMessage());
            exit("Error Querying Database first query". $ex->getMessage());
        }
        try
        {
            $stmt = $mysqli -> prepare($query2);
            $stmt -> bind_param("s", $email); // one parameter, one value -> "s", "ss", "si" etc.
            $stmt -> execute();
            $result = $stmt -> get_result();
            //print_r($result);
            while($row = $result -> fetch_assoc()) // Fetch as an associative array, key-value pairs
            {
               $cust_id = $row['CustomerID']; 
            }
        }
        catch (Exception $e)
        {
            //Write to the error log
            error_log($e -> getMessage());
            exit("Error connecting to the table");
        }
        try {
            $stmt = $mysqli->prepare($query3);
            //Bind the parameters
            $stmt -> bind_param("ssssi", $street_address, $suburb, $postcode, $city, $cust_id);
            //Execute the query
            $stmt -> execute();
        
        } catch(Exception $ex){
            error_log($ex -> getMessage());
            exit("Error Querying Database third query");
        }
        try {
            $stmt = $mysqli->prepare($query4);
            //Bind the parameters
            $stmt -> bind_param("ssi", $email, $password, $cust_id);
            //Execute the query
            $stmt -> execute();
            $mysqli -> close();
        
        } catch(Exception $ex){
            error_log($ex -> getMessage());
            exit("Error Querying Database fourth query");
        }
        header("location: ../html/login.html");
    }
?>