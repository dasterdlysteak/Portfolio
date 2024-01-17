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
            <li>  
              <div class="s-box" id="s-box" tabindex="0">
              <form action="search.php" method="POST">
                    <div class="s-boxsearch">
                        <input autocomplete="off" onkeydown="fetchData()" onkeyup="fetchData()" type="text" name="input" id="input" placeholder="Search...">
                        <button class="search-button" type="submit">
                            <i class="fa fa-search"></i>
                        </button>
                    </div>
                </form>
                <ul class="dropdown" id="dropdown">

                </ul>
              </div>
            </li>
            <li><a href="../index.php">Home</a></li>
            <li><a href="products.php">Products</a></li>
            <li><a href="search.php">Search</a></li>
            <li><a href="login.html">Login</a></li>
          </ul>
        </nav>
        <a href="cart.php"><img src="../image/shopping-bag.png" width="30px" height="30px"></a>      
        <img src="../image/menu.png" class="menu-icon" onclick="menutoggle()">
      </div>
    </div>
  
  <!------ featured catagories ------> 
  <div class="small-container">
    <h2 class="title">All Products</h2>
    <div class="row">
      <?php include("../php/load_products.php");?>
    </div>
  </div>
  <!------ featured catagories ------> 
  <div class="footer">
    <div class="container">
      <p class="copywrite">copywrite 2023 - Jesse Hamilton-Young</p>
    </div>
  </div>
  <script>
  //Request
  function getHTTPObject() 
  { 
    var xmlhttp; 
    if(window.XMLHttpRequest)
    { 
      // Chrome, Firefox, Safari
      xmlhttp = new XMLHttpRequest(); 
    } 
    else
    { 
      //Internet Explorer
      xmlhttp=new ActiveXObject("Microsoft.XMLHTTP"); 
      if (!xmlhttp)
      { 
        xmlhttp=new ActiveXObject("Msxml2.XMLHTTP"); 
      } 
      
    } 
    return xmlhttp; 
  }
  //Create the HTTP Object 
  var http = getHTTPObject(); 
  //Get reply from the server
  function handleHttpResponse() 
  {    
    //If request finished and response is ready 
    if ((http.readyState == 4) && (http.status==200))
    { 
      var results=http.responseText; 
      //Modify the script to change the html element
      document.getElementById('dropdown').innerHTML = results; 
      } 
  } 
  // The server-side script URL
  var url = "../php/auto_complete.php?title="; 
  function fetchData()
  {      
    var title = document.getElementById("input").value; 
    if (title == ""){
      document.getElementById('dropdown').style.display = 'none';
      document.getElementById('s-box').style.padding = '5px 15px';
      document.getElementById('s-box').style.borderRadius = '30px';
      
    }
    else{
      document.getElementById('dropdown').style.display = 'block';
      document.getElementById('s-box').style.padding = '5px 0px';
      document.getElementById('s-box').style.borderRadius = '15px 15px 0 0';
    }
      http.open("GET", url + title, true); 
      http.onreadystatechange = handleHttpResponse; 
      http.send(null); 
    }
    

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