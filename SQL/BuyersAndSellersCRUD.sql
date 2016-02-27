-- Temporarily disable foreign keys
SET FOREIGN_KEY_CHECKS=0;

Drop table if exists Buyer;
-- Create the Buyer table
Create Table Buyer
(
	BuyerID integer primary key AUTO_INCREMENT,
    BidderNumber integer unique,
    BuyerFirstName text,
    BuyerLastName text,
    BuyerAddress text,
    BuyerCity text,
    BuyerProvince text,
    BuyerPostalCode text,
    -- BuyerCountry Text,
    BuyerPhone Text,
    Permanent boolean default false,
    Banned boolean default false,
	Notes Text
);

-- this here is the code to create a blank buyer
INSERT INTO `buyer`
(`BuyerFirstName`,
`BuyerLastName`,
`BuyerAddress`,
`BuyerCity`,
`BuyerProvince`,
`BuyerPostalCode`,
`BuyerPhone`,
`BidderNumber`,
`Permanent`,
`Banned`,
`Notes` )
VALUES
("","","","","","","", 0,TRUE, FALSE, "");

Drop table if exists Seller;
-- Create the Seller table
Create Table Seller 
(
	SellerID integer primary key AUTO_INCREMENT,
    SellerCode char(30),
    SellerName text,
    SellerAddress text,
    SellerCity text,
    SellerProvince text,
    SellerPostalCode char(6),
    -- SellerCountry text,
    SellerPhone text,
    SellerOtherPhone text,
    SellerFax text,
    ContactFirstName text,
    ContactLastName text,
    -- SellerFileNumber text,
    -- DebtorFirstName text,
    -- DebtorLastName text,
    SellerPrivate boolean,
    GSTNumber text
);

-- Re-enable foreign keys
SET FOREIGN_KEY_CHECKS=1;

DELIMITER $$
DROP FUNCTION IF EXISTS ADD_BUYER $$
Create FUNCTION ADD_BUYER (
	N_BuyerFirstName text,
	N_BuyerLastName text,
    N_BuyerAddress text,
    N_BuyerCity text,
    N_BuyerProvince text,
    N_BuyerPostalCode text,
    N_BuyerPhone text,
    N_BuyerBidderNumber integer,
    N_BuyerPermanent boolean,
    N_BuyerBanned boolean,
	N_BuyerNotes text) RETURNS INTEGER

begin    
    INSERT INTO `buyer`
(`BuyerFirstName`,
`BuyerLastName`,
`BuyerAddress`,
`BuyerCity`,
`BuyerProvince`,
`BuyerPostalCode`,
`BuyerPhone`,
`BidderNumber`,
`Permanent`,
`Banned`,
`Notes`)
VALUES
(
	N_BuyerFirstName,
	N_BuyerLastName,
    N_BuyerAddress,
    N_BuyerCity,
    N_BuyerProvince,
    N_BuyerPostalCode,
    N_BuyerPhone,
    N_BuyerBidderNumber,
    N_BuyerPermanent,
    N_BuyerBanned,
	N_BuyerNotes)
;
    return LAST_INSERT_ID()
    ;
end $$

drop procedure if exists UPDATE_BUYER$$
create procedure UPDATE_BUYER(
	N_BuyerID integer,
	N_BuyerFirstName text,
	N_BuyerLastName text,
    N_BuyerAddress text,
    N_BuyerCity text,
    N_BuyerProvince text,
    N_BuyerPostalCode text,
    N_BuyerPhone text,
    N_BuyerBidderNumber integer,
    N_BuyerPermanent boolean,
    N_BuyerBanned boolean)
begin
	UPDATE `buyer`
		SET
		`BuyerFirstName` = N_BuyerFirstName,
		`BuyerLastName` = N_BuyerLastName,
		`BuyerAddress` = N_BuyerAddress,
		`BuyerCity` = N_BuyerCity,
		`BuyerProvince` = N_BuyerProvince,
		`BuyerPostalCode` = N_BuyerPostalCode,
		`BuyerPhone` = N_BuyerPhone,
		`BidderNumber` = N_BuyerBidderNumber,
		`Banned` = N_BuyerBanned,
		`Notes` = N_BuyerNotes
		WHERE `BuyerID` = N_BuyerID;
end;
$$
DELIMITER ;

drop procedure if exists RESET_BUYER_BIDNUMS;
create procedure RESET_BUYER_BIDNUMS()
UPDATE `buyer`
SET
`BidderNumber` = null
WHERE Permanent = FALSE; 

drop procedure if exists GET_BUYERS;
create procedure GET_BUYERS()
SELECT
BuyerID,
CONCAT(BuyerFirstName, " ", BuyerLastName) as BuyerName,
BuyerFirstName,
BuyerLastName,
BuyerAddress,
BuyerCity,
BuyerProvince,
BuyerPostalCode,
BuyerPhone,
BidderNumber,
Permanent,
Banned,
Notes
FROM `buyer`;

DELIMITER $$
DROP FUNCTION IF EXISTS ADD_SELLER $$
Create FUNCTION ADD_SELLER(N_SellerCode text, 
N_SellerName text, 
N_SellerAddress text, 
N_SellerCity text, 
N_SellerProvince text, 
N_SellerPostalCode text, 
N_SellerPhone text, 
N_SellerOtherPhone text, 
N_SellerFax text, 
N_ContactFirstName text, 
N_ContactLastName text, 
-- N_SellerFileNumber text,
N_SellerPrivate boolean,
N_GSTNumber text) RETURNS INTEGER
begin
        insert into seller(SellerCode, 
        SellerName, 
        SellerAddress, 
        SellerCity, 
        SellerProvince, 
        SellerPostalCode, 
        SellerPhone, 
        SellerOtherPhone, 
        SellerFax, 
        ContactFirstName, 
        ContactLastName, 
        -- SellerFileNumber,
        SellerPrivate,
        GSTNumber) 
        
        values (N_SellerCode, 
        N_SellerName,  
        N_SellerAddress, 
        N_SellerCity, 
        N_SellerProvince, 
        N_SellerPostalCode, 
        N_SellerPhone, 
        N_SellerOtherPhone, 
        N_SellerFax, 
        N_ContactFirstName, 
        N_ContactLastName, 
        -- N_SellerFileNumber,
        N_SellerPrivate,
        N_GSTNumber);
        return LAST_INSERT_ID();
        
end $$
DELIMITER ;

drop procedure if exists UPDATE_SELLER;
create procedure UPDATE_SELLER(
N_SellerID integer, 
N_SellerCode text, 
N_SellerName text, 
N_SellerAddress text, 
N_SellerCity text, 
N_SellerProvince text, 
N_SellerPostalCode text, 
N_SellerPhone text,
N_SellerOtherPhone text, 
N_SellerFax text, 
N_ContactFirstName text, 
N_ContactLastName text, 
-- N_SellerFileNumber text,
N_SellerPrivate boolean,
N_GSTNumber boolean)
UPDATE `seller`
SET
`SellerCode` = N_SellerCode,
`SellerName` = N_SellerName,
`SellerAddress` = N_SellerAddress, 
`SellerCity` = N_SellerCity, 
`SellerProvince` = N_SellerProvince,
`SellerPostalCode` = N_SellerPostalCode,
`SellerPhone` = N_SellerPhone,
`SellerOtherPhone` = N_SellerOtherPhone,
`SellerFax` = N_SellerFax,
`ContactFirstName` = N_ContactFirstName,
`ContactLastName` = N_ContactLastName,
-- `SellerFileNumber` = N_SellerFileNumber,
`SellerPrivate` = N_SellerPrivate,
`GSTNumber` = N_GSTNumber
WHERE `SellerID` = N_SellerID;

drop procedure if exists DEL_SELLER;
create procedure DEL_SELLER(N_SellerID integer)
DELETE FROM seller
WHERE SellerID = N_SellerID;

DROP PROCEDURE IF EXISTS GET_SELLERS;
Create Procedure GET_SELLERS()
    SELECT
SellerID,
SellerCode,
SellerName,
SellerAddress, 
SellerCity, 
SellerProvince,
SellerPostalCode,
SellerPhone,
SellerOtherPhone,
SellerFax,
ContactFirstName,
ContactLastName,
-- SellerFileNumber 'SELLER_FILE#',
SellerPrivate,
GSTNumber
FROM `seller`;