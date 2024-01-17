<?php
    class Product{
        private $productID = 0;
        private $title = "";
        private $author = "";
        private $description = "";
        private $genre = "";
        private $price = 0.00;
        private $qty = 0;
        private $image = "";
        private $qtyOrdered = 0;
    
        public function __construct($id, $title, $author, $description, $genre, $price, $qty, $image){
            $this->productID = $id;
            $this->title = $title;
            $this->author = $author;
            $this->description = $description;
            $this->genre = $genre;
            $this->price = $price;
            $this->qty = $qty;
            $this->image = $image;
            $this->qty_ordered = 0;
        }
        // as I do not need to ever use a partial product object I will forgoe the use of setters
        // i have now decided to use a setter for qty ordered as it is not needed from the database but is required for the cart
        // getting and setting this field seperately from the constructor as is needed has been decided
        public function get_id(){
            return $this->productID;
        }
        public function get_title(){
            return $this->title;
        }
        public function get_author(){
            return $this->author;
        }
        public function get_description(){
            return $this->description;
        }
        public function get_genre(){
            return $this->genre;
        }
        public function get_price(){
            return $this->price;
        }
        public function get_qty(){
            return $this->qty;
        }
        public function get_image(){
            return $this->image;
        }
        public function get_qty_ordered(){
            return $this->qtyOrdered;
        }
        public function set_qty_ordered($qtyOrdered){
            $this->qtyOrdered = $qtyOrdered;
        }
        public function get_cost_total(){
            $costTotal = $this->qtyOrdered * $this->price;
            return number_format($costTotal, 2);
        }
        public function toString(){
            return $this->productID. " " .$this->title. " " .$this->author. " " .$this->description. " " .$this->genre. " " .$this->price. " " .$this->qty. " " .$this->image;
        }
    }

?>