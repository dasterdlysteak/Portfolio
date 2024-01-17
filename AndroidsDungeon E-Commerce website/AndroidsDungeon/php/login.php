<?php
    session_start();
    $email = $_POST['email'];
    $password = $_POST['password'];
    if (($email=="") || ($password=="")) {
        echo("Please fill in required fields");
        echo "<a href='../html/login.html' class='btn'>Return to Login</a>";
        exit();
        }
        else {
        // connect to db
        require_once('conn_contract_db.php');

        // accounting for the hashed password in the database
        $key = "123abc";
        $password = crypt($password, $key);
        // preparing query
        $query = "SELECT * FROM LoginDetails where (Email = ?) AND (`password` = ?)";
        $stmt = $mysqli -> prepare($query);
        // Preparing Statement
        $stmt -> bind_param("ss", $email, $password);
        // execute statement
        $stmt -> execute();
        $result = $stmt -> get_result();

        if($result->num_rows == 1) {
            $row = $result -> fetch_array();
            $_SESSION['customer_id'] = $row['CustomerID'];
            $query = "SELECT * FROM Customer WHERE (CustomerID = ?)";
            try{
                $stmt = $mysqli -> prepare($query);
                $stmt -> bind_param("i", $_SESSION['customer_id']);
                $stmt -> execute();
                $result = $stmt -> get_result();
                $stmt -> close();
            } catch (Exception $ex){
                error_log($ex -> getMessage());
                exit("Error Querying Database first query". $ex->getMessage());
            }
            if($result->num_rows == 1) {
                // might be associated array
                $row = $result -> fetch_array();
                $_SESSION['customer_id'] = $row['CustomerID'];
                $_SESSION['first_name'] = $row['FirstName'];
                $_SESSION['last_name'] = $row['LastName'];
                $_SESSION['email'] = $row['Email'];  
                $_SESSION['phone'] = $row['Phone'];
                echo"<h2> Authentication Success !!! </h2>";
                header("location: ../index.php");
            }
            else{
                echo("<h2>Something didnt work retreiving from the customer Table<h2>");
                //header("Location: ../html/login.html");
                exit();
            }
        }
        else {
            echo("<h2>Something didnt work retreiving from the LoginDetails Table<h2>");
            //header("Location: ../html/login.html");
            exit();
        }
    }
?>