<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8" />
  <title>Androids Dungeon | Ecommerce Design</title>
  <meta name="viewport" content="width=device-width,initial-scale=1" />
  <meta name="description" content="" />
  <link rel="stylesheet" type="text/css" href="css/main.css" />
  <link rel="icon" href="favicon.png">
  <link rel="preconnect" href="https://fonts.googleapis.com">
  <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
  <link href="https://fonts.googleapis.com/css2?family=Mooli&display=swap" rel="stylesheet">
  <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
  <script src="https://kit.fontawesome.com/a076d05399.js"></script>
</head>
<body>
  <div class="header">
    <div class="container">
      <div class="navbar">
        <div class="logo">
          <img src="image/logo.webp" width="75px">
        </div>
        <nav>
          <ul id="MenuItems">
          <?php
            session_start();
            if ((isset($_SESSION['first_name']))){
              echo("<li><h1>Welcome Back ". $_SESSION['first_name'] ."!</h1></li>");
            }
          ?>
            <li><a href="">Home</a></li>
            <li><a href="html/products.php">Products</a></li>
            <li><a href="html/search.php">Search</a></li>
            <li><a href="html/login.html">Login</a></li>
          </ul>
        </nav>
        <a href="html/cart.php"><img src="image/shopping-bag.png" width="30px" height="30px"></a>
        <img src="image/menu.png" class="menu-icon" onclick="menutoggle()">
      </div>
      <div class="row">
        <div class="col2">
          <h1>Your One Stop Shop<br>For All Things Manga</h1>
          <p>There's nothing a good book cant solve<br>
          Let your mind wander!</p>
          <a href="" class="btn">Explore Now &#8594;</a>
        </div>
        <div class="col2">
          <img src="image/main-page-img.png">
        </div>
      </div>
    </div>
  </div>
  <!------ featured catagories ------> 
  <div class="catagories">
    <div class="small-container">
      <div class="row">
        <div class="col3">
          <img src="image/manga1.jpg">
        </div>
        <div class="col3">
          <img src="image/manga2.jpg">
        </div>
        <div class="col3">        
          <img src="image/manga3.jpg">
        </div>
      </div>
    </div>
  </div>
  <!------ featured catagories ------> 
  <div class="small-container">
    <h2 class="title">Featured Products</h2>
    <div class="row">
      <a href="html/product_details.php?id=1" class="col4">
        <img src="image/manga1.jpg" alt="">
        <h4>One Piece Vol 100</h4>
        <div class="rating">
          <i class="fa fa-star"></i>
          <i class="fa fa-star"></i>
          <i class="fa fa-star"></i>
          <i class="fa fa-star"></i>
          <i class="fa fa-star-half-o"></i>
        </div>
        <p>$24.00</p>
      </a>
      <a href="html/product_details.php?id=2" class="col4">
        <img src="image/manga2.jpg" alt="">
        <h4>Jujutsu Kaisen Vol 4</h4>
        <div class="rating">
          <i class="fa fa-star"></i>
          <i class="fa fa-star"></i>
          <i class="fa fa-star"></i>
          <i class="fa fa-star"></i>
          <i class="fa fa-star-o"></i>
          </div>
        <p>$22.00</p>
          </a>
      <a href="html/product_details.php?id=3" class="col4">
        <img src="image/manga3.jpg" alt="">
        <h4>SpyXFamily Vol 2</h4>
        <div class="rating">
          <i class="fa fa-star"></i>
          <i class="fa fa-star"></i>
          <i class="fa fa-star"></i>
          <i class="fa fa-star"></i>
          <i class="fa fa-star-o"></i>
        </div>
        <p>$16.00</p>
          </a>
      <a href="html/product_details.php?id=4" class="col4">
        <img src="image/manga4.jpg" alt="">
        <h4>Assassination Classroom Vol 1</h4>
        <div class="rating">
          <i class="fa fa-star"></i>
          <i class="fa fa-star"></i>
          <i class="fa fa-star"></i>
          <i class="fa fa-star"></i>
          <i class="fa fa-star-o"></i>
        </div>
        <p>$13.50</p>
          </a>
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