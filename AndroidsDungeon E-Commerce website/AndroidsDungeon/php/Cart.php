<?php
    include("Product.php");
    class Cart{
        private $products;
        private $depth;

        function __construct(){
            $this->products = array();
            $this->depth = 0;
        }

        function add_product($product) {
            foreach ($this->products as $current_product){
                // for each product in the products list check if the passed in product is the same
                if ($product->get_id() == $current_product->get_id()){
                    // if passed in product is the same simply add the qty ordered from both products together
                    $addToOrdered = $current_product->get_qty_ordered() + $product->get_qty_ordered();
                    // update qtyOrdered of the product in the list
                    $current_product->set_qty_ordered($addToOrdered);
                    // if there is a match stop, otherwise continue on to adding the new product to the list 
                    return;
                }
            }
            
            $this->products[$this->depth] = $product;
            $this->depth++;
        }

        function delete_product($product_no){
            unset($this->products[$product_no]);
            $this->products = array_values($this->products);
            $this->depth--;
        }

        function get_depth(){
            return $this->depth;
        }
        function get_product($product_no){
            return $this->products[$product_no];
        }
        // fix bug where orders over 1000 dollars break the math due to the number formating adding a , (remove formatting here and add to html displays)
        function get_subtotal(){
            $total = 0;
            foreach($this->products as $product){
                $total = $total + $product->get_cost_total();
            }
            return number_format($total, 2);
        }
        function get_gst(){
            $total = $this->get_subtotal() * 0.1;
            return number_format($total, 2);
        }
        function get_total(){
            $total = $this->get_subtotal() + $this->get_gst();
            return number_format($total, 2);
        }
    }
?>