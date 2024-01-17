<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8" />
  <title>Androids Dungeon | Ecommerce Design</title>
  <meta name="viewport" content="width=device-width,initial-scale=1" />
  <meta name="description" content="" />
  <link rel="stylesheet" type="text/css" href="../css/main.css" />
  <link rel="icon" href="favicon.png">
  <link rel="preconnect" href="https://fonts.googleapis.com">
  <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
  <link href="https://fonts.googleapis.com/css2?family=Mooli&display=swap" rel="stylesheet">
  <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
</head>
<body>
    <div class="container">
      <div class="navbar">
        <div class="logo">
          <img src="../image/logo.webp" width="75px">
        </div>
        <nav>
          <ul id="MenuItems">
            <li><a href="../index.php">Home</a></li>
            <li><a href="products.php">Products</a></li>
            <li><a href="">Search</a></li>
            <li><a href="login.html">Login</a></li>
          </ul>
        </nav>
        <a href="cart.php"><img src="../image/shopping-bag.png" width="30px" height="30px"></a>      
        <img src="../image/menu.png" class="menu-icon" onclick="menutoggle()">  
    </div>
    </div>
  
  <!------ featured catagories ------> 
  <div class="small-container">
    <h2 class="title">Thank You!</h2>
    <div class="row">
      <?php session_start();
        echo "<h2>Thank You</h2><br>";
        echo "<h3>Your order Number is: ".$_SESSION['order-id']."</h3>";
        echo "<img  width='32%' height='auto' src='../image/search-img.png' alt='anime image'>";
        $_POST["input"] = "";
        ?>
    </div>
  </div>
  <!------ featured catagories ------> 
  <div class="footer">
    <div class="container">
      <p class="copywrite">copywrite 2023 - Jesse Hamilton-Young</p>
    </div>
  </div>
  <script>
    var MenuItems = document.getElementById("MenuItems");

    MenuItems.style.maxHeight = "0px";
    function menutoggle(){
      if(MenuItems.style.maxHeight == "0px"){
        MenuItems.style.maxHeight = "200px";
      }
      else{
        MenuItems.style.maxHeight = "0px";
      }
    }
  </script>
</body>
</html>