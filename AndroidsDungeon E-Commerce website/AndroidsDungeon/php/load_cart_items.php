<?php
    session_start();
    include 'Cart.php';
    $cart = new Cart();
    if(isset($_SESSION['cart'])){
        $cart = unserialize($_SESSION['cart']);
    }
    echo "<form method='post'>";
    for ($i = 0; $i < $cart->get_depth(); $i++){
        $currentProduct = $cart->get_product($i);
        echo "<tr>";
        echo "<td>";
        echo "<div class='cart-info'>";
        echo "<img src='". $currentProduct->get_image() ."' alt'". $currentProduct->get_title() ." image'>";
        echo "<div>";
        echo "<p>". $currentProduct->get_title() ."</p>";
        echo "<small>Price: $". $currentProduct->get_price() ."</small>";
        echo "<br>";
        echo "<a href='../php/remove_item.php?product_no=". $i ."'>Remove</a>";
        echo "</div>";
        echo "</div>";
        echo "</td>";
        echo "<td><input type='number'name='qty' value='". $currentProduct->get_qty_ordered() ."' readonly></td>";
        echo "<td>$". $currentProduct->get_cost_total() ."</td>";
        echo "</tr>";
    }
    echo "</table>";
    echo "<div class='total-price'>";
    echo "<table>";
    echo "<tr>";
    echo "<td>Subtotal</td>";
    echo "<td>$". $cart->get_subtotal() ."</td>";
    echo "</tr>";
    echo "<tr>";
    echo "<td>tax</td>";
    echo "<td>$". $cart->get_gst() ."</td>";
    echo "</tr>";
    echo "<tr>";
    echo "<td>Total</td>";
    echo "<td>$". $cart->get_total() ."</td>";
    echo "</tr>";
    echo "<tr>";
    echo "<td class='tdd'><a href='payment_gateway.php' class='btn'>Proceed to Payment</a></td>";
    echo "</form>";
    echo "</tr>";
    echo "</table>";
    echo "</div>";
?>
       
