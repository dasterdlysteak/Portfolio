<?php
    session_start();
    if ((isset($_SESSION['first_name']))){
    
?>
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
  <div class="page-container">
    <div class="content-wrap">
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
    <!------ Payment-Form ------>   
    <div class="pcontainer">
        <form action="../php/process_payment.php" method="Post">
            <div class="row">
                <div class="col">
                    <h3 class="title">billing address</h3>
                    <div class="inputBox">
                        <span>Full Name :</span>
                        <?php                        
                            $first = $_SESSION['first_name'];
                            $last = $_SESSION['last_name'];
                            echo "<input type='text'  value='".$first." ".$last."'>"; 
                        ?>                    
                    </div>
                    <div class="inputBox">
                        <span>Email :</span>
                        <?php
                            echo "<input type='text' value='".$_SESSION['email']."'>"; 
                        ?>
                    </div>
                    <div class="inputBox">
                        <span>Street Address :</span>
                        <input type="text" placeholder="309 Adelaide Street">
                    </div>
                    <div class="inputBox">
                        <span>City :</span>
                        <input type="text" placeholder="Adelaide">
                    </div>

                    <div class="flex">
                        <div class="inputBox">
                            <span>State :</span>
                            <input type="text" placeholder="South Australia">
                        </div>
                        <div class="inputBox">
                            <span>zip code :</span>
                            <input type="text" placeholder="5000">
                        </div>
                    </div>
                </div>
                <div class="col">
                    <h3 class="title">payment</h3>
                    <div class="inputBox">
                        <span>Cards Accepted :</span>
                        <img src="../image/card_img.png" alt="paypal, visa, mastercard, amex">
                    </div>
                    <div class="inputBox">
                        <span>Name on Card :</span>
                        <input type="text" name="card_name" placeholder="John Smith">
                    </div>
                    <div class="inputBox">
                        <span>Credit Card-Number :</span>
                        <input type="number" name="card_number" placeholder="0000-0000-0000-0000">
                    </div>
                    <div class="inputBox">
                        <span>CCV :</span>
                        <input style="width:60px;" type="number" name="ccv" placeholder="000">
                    </div>
                    <div class="flex">
                        <div class="inputBox">
                            <span>Expiry :</span>
                            <select name='expireMM' id='expireMM'>
                                <option value=''>Month</option>
                                <option value='01'>January</option>
                                <option value='02'>February</option>
                                <option value='03'>March</option>
                                <option value='04'>April</option>
                                <option value='05'>May</option>
                                <option value='06'>June</option>
                                <option value='07'>July</option>
                                <option value='08'>August</option>
                                <option value='09'>September</option>
                                <option value='10'>October</option>
                                <option value='11'>November</option>
                                <option value='12'>December</option>
                            </select> 
                            <select name='expireYY' id='expireYY'>
                                <option value=''>Year</option>
                                <option value='23'>2023</option>
                                <option value='24'>2024</option>
                                <option value='25'>2025</option>
                                <option value='26'>2026</option>
                                <option value='27'>2027</option>
                            </select> 
                      </div>
                      </div>
                  </div>
            </div>
            <input type="submit" value="proceed to checkout" class="submit-btn">
        </form>
      </div>
    </div>
    <!------ footer ------> 
    <div class="footer">
      <div class="container">
        <p class="copywrite">copywrite 2023 - Jesse Hamilton-Young</p>
      </div>
    </div>
  </div>
  <script>
    var Indicator = document.getElementById("Indicator")
  </script>
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
<?php
    }
    else{
        header("Location:../html/login.html");    
    }
?>