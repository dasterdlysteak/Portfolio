-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema AndroidsDungeon
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `AndroidsDungeon` ;

-- -----------------------------------------------------
-- Schema AndroidsDungeon
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `AndroidsDungeon` DEFAULT CHARACTER SET utf8 ;
USE `AndroidsDungeon` ;

-- -----------------------------------------------------
-- Table `AndroidsDungeon`.`Customer`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `AndroidsDungeon`.`Customer` ;

CREATE TABLE IF NOT EXISTS `AndroidsDungeon`.`Customer` (
  `CustomerID` INT NOT NULL AUTO_INCREMENT,
  `FirstName` VARCHAR(45) NOT NULL,
  `LastName` VARCHAR(45) NOT NULL,
  `Email` VARCHAR(45) NOT NULL,
  `Phone` VARCHAR(45) NULL,
  PRIMARY KEY (`CustomerID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `AndroidsDungeon`.`Address`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `AndroidsDungeon`.`Address` ;

CREATE TABLE IF NOT EXISTS `AndroidsDungeon`.`Address` (
  `StreetAddress` VARCHAR(50) NOT NULL,
  `Suburb` VARCHAR(45) NOT NULL,
  `PostCode` VARCHAR(45) NOT NULL,
  `City` VARCHAR(45) NOT NULL,
  `CustomerID` INT NOT NULL,
  PRIMARY KEY (`CustomerID`),
  CONSTRAINT `fk_Address_Customer`
    FOREIGN KEY (`CustomerID`)
    REFERENCES `AndroidsDungeon`.`Customer` (`CustomerID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `AndroidsDungeon`.`Product`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `AndroidsDungeon`.`Product` ;

CREATE TABLE IF NOT EXISTS `AndroidsDungeon`.`Product` (
  `ProductID` INT NOT NULL AUTO_INCREMENT,
  `Title` VARCHAR(45) NULL,
  `Author` VARCHAR(45) NULL,
  `Description` VARCHAR(700) NULL,
  `Genre` VARCHAR(45) NULL,
  `Price` DOUBLE NULL,
  `Qty` INT NULL,
  `Image` VARCHAR(355) NULL,
  PRIMARY KEY (`ProductID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `AndroidsDungeon`.`Order`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `AndroidsDungeon`.`Order` ;

CREATE TABLE IF NOT EXISTS `AndroidsDungeon`.`Order` (
  `OrderId` INT NOT NULL AUTO_INCREMENT,
  `OrderTotal` DOUBLE NULL,
  `OrderStatus` VARCHAR(30) NULL,
  `CustomerID` INT NOT NULL,
  PRIMARY KEY (`OrderId`, `CustomerID`),
  INDEX `fk_Order_Customer1_idx` (`CustomerID` ASC) ,
  CONSTRAINT `fk_Order_Customer1`
    FOREIGN KEY (`CustomerID`)
    REFERENCES `AndroidsDungeon`.`Customer` (`CustomerID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `AndroidsDungeon`.`Review`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `AndroidsDungeon`.`Review` ;

CREATE TABLE IF NOT EXISTS `AndroidsDungeon`.`Review` (
  `ReviewID` INT NOT NULL AUTO_INCREMENT,
  `ReviewDetails` VARCHAR(45) NULL,
  `Rating` INT NULL,
  PRIMARY KEY (`ReviewID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `AndroidsDungeon`.`OrderProduct`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `AndroidsDungeon`.`OrderProduct` ;

CREATE TABLE IF NOT EXISTS `AndroidsDungeon`.`OrderProduct` (
  `OrderId` INT NOT NULL,
  `ProductID` INT NOT NULL,
  `QtyOrdered` INT NULL,
  PRIMARY KEY (`OrderId`, `ProductID`),
  INDEX `fk_Order_has_Product_Product1_idx` (`ProductID` ASC) ,
  INDEX `fk_Order_has_Product_Order1_idx` (`OrderId` ASC) ,
  CONSTRAINT `fk_Order_has_Product_Order1`
    FOREIGN KEY (`OrderId`)
    REFERENCES `AndroidsDungeon`.`Order` (`OrderId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Order_has_Product_Product1`
    FOREIGN KEY (`ProductID`)
    REFERENCES `AndroidsDungeon`.`Product` (`ProductID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `AndroidsDungeon`.`CustomerProductReview`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `AndroidsDungeon`.`CustomerProductReview` ;

CREATE TABLE IF NOT EXISTS `AndroidsDungeon`.`CustomerProductReview` (
  `CustomerID` INT NOT NULL,
  `ReviewID` INT NOT NULL,
  `ProductID` INT NOT NULL,
  PRIMARY KEY (`CustomerID`, `ReviewID`, `ProductID`),
  INDEX `fk_Customer_has_Review_Review1_idx` (`ReviewID` ASC) ,
  INDEX `fk_Customer_has_Review_Customer1_idx` (`CustomerID` ASC) ,
  INDEX `fk_Customer_has_Review_Product1_idx` (`ProductID` ASC) ,
  CONSTRAINT `fk_Customer_has_Review_Customer1`
    FOREIGN KEY (`CustomerID`)
    REFERENCES `AndroidsDungeon`.`Customer` (`CustomerID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Customer_has_Review_Review1`
    FOREIGN KEY (`ReviewID`)
    REFERENCES `AndroidsDungeon`.`Review` (`ReviewID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Customer_has_Review_Product1`
    FOREIGN KEY (`ProductID`)
    REFERENCES `AndroidsDungeon`.`Product` (`ProductID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `AndroidsDungeon`.`LoginDetails`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `AndroidsDungeon`.`LoginDetails` ;

CREATE TABLE IF NOT EXISTS `AndroidsDungeon`.`LoginDetails` (
  `Email` VARCHAR(45) NOT NULL,
  `Password` VARCHAR(256) NULL,
  `CustomerID` INT NOT NULL,
  PRIMARY KEY (`CustomerID`),
  INDEX `fk_LoginDetails_Customer1_idx` (`CustomerID` ASC),
  CONSTRAINT `fk_LoginDetails_Customer1`
    FOREIGN KEY (`CustomerID`)
    REFERENCES `AndroidsDungeon`.`Customer` (`CustomerID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `AndroidsDungeon`.`PaymentDetails`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `AndroidsDungeon`.`PaymentDetails` ;

CREATE TABLE IF NOT EXISTS `AndroidsDungeon`.`PaymentDetails` (
  `CardNo` VARCHAR(16) NOT NULL,
  `Expiry` VARCHAR(5) NOT NULL,
  `CCV` VARCHAR(3) NULL,
  `CustomerID` INT NOT NULL,
  PRIMARY KEY (`CustomerID`),
  CONSTRAINT `fk_PaymentDetails_Customer1`
    FOREIGN KEY (`CustomerID`)
    REFERENCES `AndroidsDungeon`.`Customer` (`CustomerID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;


VALUES (2, 22.00, "Shipped", 002);

INSERT INTO `Order`
VALUES (3, 16.00, "Shipped", 003);

INSERT INTO `Order`
VALUES (4, 16.00, "Shipped", 004);

INSERT INTO `Order`
VALUES (5, 13.50, "Shipped", 005);

INSERT INTO OrderProduct
VALUES (1, 01, 1);

INSERT INTO OrderProduct
VALUES (2, 02, 1);

INSERT INTO OrderProduct
VALUES (3, 03, 1);

INSERT INTO OrderProduct
VALUES (4, 03, 1);

INSERT INTO OrderProduct
VALUES (5, 04, 1);

INSERT INTO LoginDetails
VALUES ("user1", "password1", 001);

INSERT INTO LoginDetails
VALUES ("user2", "password2", 002);

INSERT INTO LoginDetails
VALUES ("user3", "password3", 003);

INSERT INTO LoginDetails
VALUES ("user4", "password4", 004);

INSERT INTO LoginDetails
VALUES ("user5", "password5", 005);

INSERT INTO PaymentDetails
VALUES ("0000000000000000", "11/24", "000", 001);

INSERT INTO PaymentDetails
VALUES ("1111111111111111", "08/24", "111", 002);

INSERT INTO PaymentDetails
VALUES ("2222222222222222", "06/24", "222", 003);

INSERT INTO PaymentDetails
VALUES ("3333333333333333", "05/24", "333", 004);

INSERT INTO PaymentDetails
VALUES ("4444444444444444", "04/24", "444", 005);