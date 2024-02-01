-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 01, 2024 at 04:04 AM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `androidsdungeon`
--

-- --------------------------------------------------------

--
-- Table structure for table `address`
--

CREATE TABLE `address` (
  `StreetAddress` varchar(50) NOT NULL,
  `Suburb` varchar(45) NOT NULL,
  `PostCode` varchar(45) NOT NULL,
  `City` varchar(45) NOT NULL,
  `CustomerID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `address`
--



-- --------------------------------------------------------

--
-- Table structure for table `customer`
--

CREATE TABLE `customer` (
  `CustomerID` int(11) NOT NULL,
  `FirstName` varchar(45) NOT NULL,
  `LastName` varchar(45) NOT NULL,
  `Email` varchar(45) NOT NULL,
  `Phone` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `customer`
--




-- --------------------------------------------------------

--
-- Table structure for table `customerproductreview`
--

CREATE TABLE `customerproductreview` (
  `CustomerID` int(11) NOT NULL,
  `ReviewID` int(11) NOT NULL,
  `ProductID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `logindetails`
--

CREATE TABLE `logindetails` (
  `Email` varchar(45) NOT NULL,
  `Password` varchar(256) DEFAULT NULL,
  `CustomerID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `logindetails`
--




-- --------------------------------------------------------

--
-- Table structure for table `order`
--

CREATE TABLE `order` (
  `OrderId` VARCHAR(30) NOT NULL,
  `OrderTotal` double DEFAULT NULL,
  `OrderStatus` varchar(30) DEFAULT NULL,
  `CustomerID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `order`
--



-- --------------------------------------------------------

--
-- Table structure for table `orderproduct`
--

CREATE TABLE `orderproduct` (
  `OrderId` VARCHAR(30) NOT NULL,
  `ProductID` int(11) NOT NULL,
  `QtyOrdered` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `orderproduct`
--


-- --------------------------------------------------------

--
-- Table structure for table `paymentdetails`
--

CREATE TABLE `paymentdetails` (
  `CardNo` varchar(16) NOT NULL,
  `Expiry` varchar(5) NOT NULL,
  `CustomerID` int(11) NOT NULL,
  `OrderID` VARCHAR(30) NOT NULL,
  `NameOnCard` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `paymentdetails`
--


-- --------------------------------------------------------

--
-- Table structure for table `product`
--

CREATE TABLE `product` (
  `ProductID` int(11) NOT NULL,
  `Title` varchar(45) DEFAULT NULL,
  `Author` varchar(45) DEFAULT NULL,
  `Description` longtext DEFAULT NULL,
  `Genre` varchar(45) DEFAULT NULL,
  `Price` decimal(8,2) DEFAULT NULL,
  `Qty` int(11) DEFAULT NULL,
  `Image` varchar(355) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `product`
--

INSERT INTO `product` (`ProductID`, `Title`, `Author`, `Description`, `Genre`, `Price`, `Qty`, `Image`) VALUES
(1, 'One Piece: Vol 100', 'Echiro Oda', 'Join Monkey D. Luffy and his swashbuckling crew in their search for the ultimate treasure, One Piece!\r\n\r\nAs a child, Monkey D. Luffy dreamed of becoming King of the Pirates. But his life changed when he accidentally gained the power to stretch like rubber...at the cost of never being able to swim again! Years, later, Luffy sets off in search of the One Piece, said to be the greatest treasure in the world...\r\n\r\nThe big powers converge as Luffy, Law, and Kid face off against Kaido and Big Mom. Is there any hope of victory against this ultimate alliance?! Onigashima quakes with power as some of the fiercest pirates in the world go head-to-head!!', 'Shonen', 24.00, 12, '../image/manga1.jpg'),
(2, 'Jujutsu Kaisen: Vol 4', 'Gege Akutami', 'JuJutsu Sorcerers at it again!', 'Shonen', 22.00, 10, '../image/manga2.jpg'),
(3, 'SpyXFamily: Vol 2', 'Tatsuya Endo', 'Spy vs Assassin vs child', 'Comedy', 16.00, 16, '../image/manga3.jpg'),
(4, 'Assassination Classroom Vol 1', 'Yusei Matsui', 'When the misfits of Class 3-E get stuck with a smiley-faced, octopus-tentacled schoolteacher with bizarre superpowers, they discover they have a lot to learn…\r\n\r\nKoro Sensei has already blown up the moon. He promises not to do the same to the Earth on one condition…that he be allowed to teach a certain junior high school remedial class for one year. In addition, he’ll allow the students to attempt to take him out at any time without retaliating. Whoever succeeds gets a huge cash reward from the Ministry of Defense. But now the students of Class 3-E are the only ones standing in the way of the destruction of the planet!\r\n\r\nMeet the would-be assassins of class 3-E: Sugino, who let his grades slip and got kicked off the baseball team. Karma, who’s doing well in his classes but keeps getting suspended for fighting. And Okuda, who lacks both academic and social skills, yet excels at one subject: chemistry. Who has the best chance of winning that reward? Will the deed be accomplished through pity, brute force or poison...? And what chance does their teacher have of repairing his students’ tattered self-esteem?', 'Shonen', 13.50, 13, '../image/manga4.jpg'),
(5, 'Demon Slayer: vol 1', 'Koyoharu Gotouge', 'Tanjiro sets out on the path of the Demon Slayer to save his sister and avenge his family!\r\n\r\nIn Taisho-era Japan, kindhearted Tanjiro Kamado makes a living selling charcoal. But his peaceful life is shattered when a demon slaughters his entire family. His little sister Nezuko is the only survivor, but she has been transformed into a demon herself! Tanjiro sets out on a dangerous journey to find a way to return his sister to normal and destroy the demon who ruined his life.\r\n\r\nLearning to destroy demons won’t be easy, and Tanjiro barely knows where to start. The surprise appearance of another boy named Giyu, who seems to know what’s going on, might provide some answers—but only if Tanjiro can stop Giyu from killing his sister first!', 'Shonen', 24.00, 18, '../image/manga5.jpg'),
(6, 'Demon Slayer: Vol 2', 'Koyoharu Gotouge', 'Tanjiro sets out on the path of the Demon Slayer to save his sister and avenge his family!\r\n\r\nIn Taisho-era Japan, kindhearted Tanjiro Kamado makes a living selling charcoal. But his peaceful life is shattered when a demon slaughters his entire family. His little sister Nezuko is the only survivor, but she has been transformed into a demon herself! Tanjiro sets out on a dangerous journey to find a way to return his sister to normal and destroy the demon who ruined his life.\r\n\r\nDuring final selection for the Demon Slayer Corps, Tanjiro faces a disfigured demon and uses the techniques taught by his master, Urokodaki! As Tanjiro begins to walk the path of the Demon Slayer, his search for the demon who murdered his family leads him to investigate the disappearances of young girls in a nearby town.', 'Shonen', 14.00, 25, '../image/manga6.jpg'),
(7, 'Attack on Titan: Vol 1', 'HAJIME ISAYAMA ', 'Winner of the 2011 Kodansha Manga Award (Shonen) and nominated for the prestigious Osamu Tezuka Cultural Prize for 2012.\r\n\r\nThe megahit Attack on Titan anime is back, with Season Three announced for 2018!\r\n\r\nIn this post-apocalyptic sci-fi story, humanity has been devastated by the bizarre, giant humanoids known as the Titans. Little is known about where they came from or why they are bent on consuming mankind. Seemingly unintelligent, they have roamed the world for years, killing everyone they see. For the past century, what\'s left of man has hidden in a giant, three-walled city. People believe their 50-meter-high walls will protect them from the Titans, but the sudden appearance of an immense Titan is about to change everything.\r\n\r\nWinner of the 2011 Kodansha Manga Award (Shonen) and nominated for the prestigious Osamu Tezuka Cultural Prize for 2012.', 'Shonen, Senien', 24.00, 50, '../image/manga7.jpg'),
(8, 'Berserk: Vol 1', 'Kentaro Miura ', 'Created by Kentaro Miura, Berserk is manga mayhem to the extreme - violent, horrifying, and mercilessly funny - and the wellspring for the internationally popular anime series. Not for the squeamish or the easily offended, Berserk asks for no quarter - and offers none!\r\nHis name is Guts, the Black Swordsman, a feared warrior spoken of only in whispers. Bearer of a gigantic sword, an iron hand, and the scars of countless battles and tortures, his flesh is also indelibly marked with The Brand, an unholy symbol that draws the forces of darkness to him and dooms him as their sacrifice. But Guts won\'t take his fate lying down; he\'ll cut a crimson swath of carnage through the ranks of the damned - and anyone else foolish enough to oppose him! Accompanied by Puck the Elf, more an annoyance than a companion, Guts relentlessly follows a dark, bloodstained path that leads only to death...or vengeance.', 'Adult, Mediaeval', 19.25, 40, '../image/manga8.jpg');

-- --------------------------------------------------------

--
-- Table structure for table `review`
--

CREATE TABLE `review` (
  `ReviewID` int(11) NOT NULL,
  `ReviewDetails` varchar(45) DEFAULT NULL,
  `Rating` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `address`
--
ALTER TABLE `address`
  ADD PRIMARY KEY (`CustomerID`);

--
-- Indexes for table `customer`
--
ALTER TABLE `customer`
  ADD PRIMARY KEY (`CustomerID`);

--
-- Indexes for table `customerproductreview`
--
ALTER TABLE `customerproductreview`
  ADD PRIMARY KEY (`CustomerID`,`ReviewID`,`ProductID`),
  ADD KEY `fk_Customer_has_Review_Review1_idx` (`ReviewID`),
  ADD KEY `fk_Customer_has_Review_Customer1_idx` (`CustomerID`),
  ADD KEY `fk_Customer_has_Review_Product1_idx` (`ProductID`);

--
-- Indexes for table `logindetails`
--
ALTER TABLE `logindetails`
  ADD PRIMARY KEY (`CustomerID`),
  ADD KEY `fk_LoginDetails_Customer1_idx` (`CustomerID`);

--
-- Indexes for table `order`
--
ALTER TABLE `order`
  ADD PRIMARY KEY (`OrderId`,`CustomerID`),
  ADD KEY `fk_Order_Customer1_idx` (`CustomerID`);

--
-- Indexes for table `orderproduct`
--
ALTER TABLE `orderproduct`
  ADD PRIMARY KEY (`OrderId`,`ProductID`),
  ADD KEY `fk_Order_has_Product_Product1_idx` (`ProductID`),
  ADD KEY `fk_Order_has_Product_Order1_idx` (`OrderId`);

--
-- Indexes for table `paymentdetails`
--
ALTER TABLE `paymentdetails`
  ADD PRIMARY KEY (`CustomerID`,`OrderID`);

--
-- Indexes for table `product`
--
ALTER TABLE `product`
  ADD PRIMARY KEY (`ProductID`);

--
-- Indexes for table `review`
--
ALTER TABLE `review`
  ADD PRIMARY KEY (`ReviewID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `customer`
--
ALTER TABLE `customer`
  MODIFY `CustomerID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `product`
--
ALTER TABLE `product`
  MODIFY `ProductID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `review`
--
ALTER TABLE `review`
  MODIFY `ReviewID` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `address`
--
ALTER TABLE `address`
  ADD CONSTRAINT `fk_Address_Customer` FOREIGN KEY (`CustomerID`) REFERENCES `customer` (`CustomerID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `customerproductreview`
--
ALTER TABLE `customerproductreview`
  ADD CONSTRAINT `fk_Customer_has_Review_Customer1` FOREIGN KEY (`CustomerID`) REFERENCES `customer` (`CustomerID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Customer_has_Review_Product1` FOREIGN KEY (`ProductID`) REFERENCES `product` (`ProductID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Customer_has_Review_Review1` FOREIGN KEY (`ReviewID`) REFERENCES `review` (`ReviewID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `logindetails`
--
ALTER TABLE `logindetails`
  ADD CONSTRAINT `fk_LoginDetails_Customer1` FOREIGN KEY (`CustomerID`) REFERENCES `customer` (`CustomerID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `order`
--
ALTER TABLE `order`
  ADD CONSTRAINT `fk_Order_Customer1` FOREIGN KEY (`CustomerID`) REFERENCES `customer` (`CustomerID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `orderproduct`
--
ALTER TABLE `orderproduct`
  ADD CONSTRAINT `fk_Order_has_Product_Order1` FOREIGN KEY (`OrderId`) REFERENCES `order` (`OrderId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Order_has_Product_Product1` FOREIGN KEY (`ProductID`) REFERENCES `product` (`ProductID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `paymentdetails`
--
ALTER TABLE `paymentdetails`
  ADD CONSTRAINT `fk_PaymentDetails_Customer1` FOREIGN KEY (`CustomerID`) REFERENCES `customer` (`CustomerID`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
