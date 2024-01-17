<?php
// Connect to the server
$server = "127.0.0.1:3306";
$user = "root";
$password = "";
$database = "AndroidsDungeon";
$mysqli = mysqli_connect($server, $user, $password, $database) or die ("Error conneting to the database:" . mysqli_connect_error());
?>