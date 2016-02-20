-- Temporarily disable foreign keys
SET FOREIGN_KEY_CHECKS=0;

Drop table if exists Buyer;
-- Create the Buyer table
Create Table Buyer
(
	BuyerID integer primary key AUTO_INCREMENT,
    BidderNumber integer,
    BuyerFirstName text,
    BuyerLastName text,
    BuyerAddress text,
    BuyerCity text,
    BuyerProvince text,
    BuyerPostalCode text,
    -- BuyerCountry Text,
    BuyerPhone Text,
    Permanent boolean default false,
    Banned boolean default false
);


Drop table if exists Seller;
-- Create the Seller table
Create Table Seller 
(
	SellerID integer primary key AUTO_INCREMENT,
    SellerCode char(30),
    SellerName text,
    SellerStreet text,
    SellerCity text,
    SellerProvince text,
    SellerPostalCode char(6),
    -- SellerCountry text,
    SellerPhone text,
    SellerOtherPhone text,
    SellerFax text,
    ContactFirstName text,
    ContactLastName text,
    SellerFileNumber text,
    DebtorFirstName text,
    DebtorLastName text,
    Private boolean,
    GSTNumber text
);

-- Re-enable foreign keys
SET FOREIGN_KEY_CHECKS=1;

DELIMITER $$
DROP FUNCTION IF EXISTS ADD_BUYER $$
Create FUNCTION ADD_BUYER (N_BuyerFirstName text,
	N_BuyerLastName text,
    N_BuyerAddress text,
    N_BuyerCity text,
    N_BuyerProvince text,
    N_BuyerPostalCode text,
    N_BuyerPhone text,
    N_BuyerBidderNumber integer,
    N_BuyerPermanent boolean,
    N_BuyerBanned boolean) RETURNS INTEGER

begin    
    INSERT INTO `buyer`
(`BuyerFirstName`,
`BuyerAddress`,
`BuyerCity`,
`BuyerProvince`,
`BuyerPostalCode`,
`BuyerPhone`,
`BidderNumber`,
`Permanent`,
`Banned` )
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
    N_BuyerBanned)
;
    return LAST_INSERT_ID()
    ;
end $$

drop procedure if exists UPDATE_BUYER$$
create procedure UPDATE_BUYER(N_BuyerID integer,
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
		`BuyerAddress` = N_BuyerAddress,
		`BuyerCity` = N_BuyerCity,
		`BuyerProvince` = N_BuyerProvince,
		`BuyerPostalCode` = N_BuyerPostalCode,
		`BuyerPhone` = N_BuyerPhone,
		`BidderNumber` = N_BuyerBidderNumber,
		`Banned` = N_BuyerBanned
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
BuyerFirstName,
BuyerAddress,
BuyerCity,
BuyerProvince,
BuyerPostalCode,
BuyerPhone,
BidderNumber,
Permanent,
Banned
FROM `buyer`;

DELIMITER $$
DROP FUNCTION IF EXISTS ADD_CON $$
Create FUNCTION ADD_CON(N_SellerCode text, 
N_SellerFirstName text, 
N_SellerAddress text, 
N_SellerCity text, 
N_SellerProvince text, 
N_SellerPostalCode text, 
N_SellerPhone text, 
N_SellerOtherPhone text, 
N_SellerFax text, 
N_ContactFirstName text, 
N_SellerFileNumber text,
N_SellerDriverLicense text,
N_GSTNumber boolean) RETURNS INTEGER
begin
        insert into CONS(SellerCode, 
        SellerFirstName, 
        SellerAddress, 
        SellerCity, 
        SellerProvince, 
        SellerPostalCode, 
        SellerPhone, 
        SellerOtherPhone, 
        SellerFax, 
        ContactFirstName, 
        SellerFileNumber,
        SellerDriverLicense,
        GSTNumber) 
        
        values (N_SellerCode, 
        N_SellerFirstName, 
        N_SellerAddress, 
        N_SellerCity, 
        N_SellerProvince, 
        N_SellerPostalCode, 
        N_SellerPhone, 
        N_SellerOtherPhone, 
        N_SellerFax, 
        N_ContactFirstName, 
        N_SellerFileNumber,
        N_SellerDriverLicense,
        N_GSTNumber);
        return LAST_INSERT_ID();
        
end $$
DELIMITER ;

drop procedure if exists UPDATE_CON;
create procedure UPDATE_CON(
N_SellerID integer, 
N_SellerCode text, 
N_SellerFirstName text, 
N_SellerAddress text, 
N_SellerCity text, 
N_SellerProvince text, 
N_SellerPostalCode text, 
N_SellerPhone text,
N_SellerOtherPhone text, 
N_SellerFax text, 
N_ContactFirstName text, 
N_SellerFileNumber text,
N_SellerDriverLicense text,
N_GSTNumber boolean)
UPDATE `cons`
SET
`SellerCode` = N_SellerCode,
`SellerFirstName` = N_SellerFirstName,
`SellerAddress` = N_SellerAddress, 
`SellerCity` = N_SellerCity, 
`SellerProvince` = N_SellerProvince,
`SellerPostalCode` = N_SellerPostalCode,
`SellerPhone` = N_SellerPhone,
`SellerOtherPhone` = N_SellerOtherPhone,
`SellerFax` = N_SellerFax,
`ContactFirstName` = N_ContactFirstName,
`SellerFileNumber` = N_SellerFileNumber,
SellerDriverLicense = N_SellerDriverLicense,
GSTNumber = N_GSTNumber
WHERE `SellerID` = N_SellerID;

drop procedure if exists DEL_CON;
create procedure DEL_CON(N_SellerID integer)
DELETE FROM CONS
WHERE SellerID = N_SellerID;

DROP PROCEDURE IF EXISTS GET_CONS;
Create Procedure GET_CONS()
    SELECT
SellerID,
SellerCode,
SellerFirstName,
SellerAddress, 
SellerCity, 
SellerProvince,
SellerPostalCode,
SellerPhone,
SellerOtherPhone,
SellerFax,
ContactFirstName,
SellerFileNumber 'CON_FILE#',
SellerDriverLicense,
GSTNumber
FROM `seller`;