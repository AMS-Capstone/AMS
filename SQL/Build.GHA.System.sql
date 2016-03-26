-- USE GHATest;
-- Purpose: The statements below create the tables for the GHA system.alter. The script is broken into 3 major phases.
-- [1] Drop Tables if it exists
-- [2] Create Tables
-- [3] Load Tables With Data
-- [4] Create Prod

-- Disabling foreign keys
SET FOREIGN_KEY_CHECKS=0;

-- [1][1]				[1][1] --
-- [1][1]				[1][1] --
-- [1][1]  DROP TABLES 	[1][1] --
-- [1][1]				[1][1] --
-- [1][1]				[1][1] --
-- [1][1]				[1][1] --

drop table if exists VehiclePictures;
drop table if exists Payment;
drop table if exists VehicleFee;
drop table if exists VehicleCondnReqs;
drop table if exists AuctionSale;
drop table if exists Vehicle;
drop table if exists Seller;
drop table if exists Buyer;
drop table if exists PaymentType ;
drop table if exists GST;
drop table if exists FeeType;
drop table if exists conditionstatus;
drop table if exists Auction;

-- [2][2]						[2][2] --
-- [2][2]						[2][2] --
-- [2][2]  CREATE TABLES 		[2][2] --
-- [2][2]						[2][2] --
-- [2][2]						[2][2] --
-- [2][2]						[2][2] --

-- Create the Auction table
Create Table Auction 
(
	AuctionID integer primary key AUTO_INCREMENT,
    AuctionDate DateTime,
    AuctionTotal double,
    SurCharges double,
    CashCharges double,
    ChequeCharges double,
    CreditCardCharges double
);
    
-- Create the conditionstatus table
Create Table conditionstatus
(
	ConditionID integer primary key AUTO_INCREMENT,
    ConditionCode tinytext,
    ConditionDescription text
);

-- Create Table FeeType
Create Table FeeType
(
	FeeID integer primary key AUTO_INCREMENT,
    FeeCost double,
    FeeType text
);

-- Create Table GST
Create Table GST 
(
	GSTID integer primary key AUTO_INCREMENT,
    GSTPercent double,
    GSTStatus boolean
);

-- Create Table PaymentType
Create Table PaymentType
(
	PaymentTypeID integer primary key AUTO_INCREMENT,
    SurchargeInPercent double,
    PaymentDescription text
);

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
    BuyerLicense Text,
    BuyerPhone Text,
    Permanent boolean default false,
    Banned boolean default false,
	Notes Text
);


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

-- Create the vehicle table
Create Table Vehicle
(
	VehicleID integer primary key AUTO_INCREMENT,
    LotNumber text, 
    Year text, 
    Make text,
    Model text,
    VIN text,
    Color text,
    Mileage int,
    Units text,
    Province text,
    Transmission text, 
    VehicleOptions text,
    SellerID integer,
	constraint FK_Vehicle_SellerID foreign key (SellerID) references Seller(SellerID)
);

-- Create table AuctionSale 
Create Table AuctionSale 
(
	AuctionSaleID integer primary key AUTO_INCREMENT,
    AuctionID integer,
    constraint FK_AuctionSale_AuctionID foreign key (AuctionID) references Auction(AuctionID),
    VehicleID integer,
    constraint FK_AuctionSale_VehicleID foreign key (VehicleID) references Vehicle(VehicleID),
    BuyerID integer,
    constraint FK_AuctionSale_BuyerID foreign key (BuyerID) references Buyer(BuyerID),
	BidderNumber integer,
    SellingPrice double, 
    BuyersFee double, 
    Deposit double,
    ConditionID integer,
    constraint FK_AuctionSale_ConditionID foreign key (ConditionID) references conditionstatus(ConditionID),
    GSTID integer,
    constraint FK_AuctionSale_GSTID foreign key (GSTID) references GST(GSTID),
    Total double, 
    Saledate date,
    Notes text
);

-- Create table Vehicle CondnReqs
Create Table VehicleCondnReqs
(
	VehicleConReqID integer primary key AUTO_INCREMENT,
    VehicleID integer,
    constraint FK_VehicleCondnReqs_VehicleID foreign key (VehicleID) references Vehicle(VehicleID),
	Reserve double,
    Record boolean, 
    CallOnHigh boolean,
    Comments text,
    EstValue double,
    dateIn date,
    ForSale boolean
);

-- Create table VehicleFee
Create Table VehicleFee
(
	VehicleFeeID integer primary key AUTO_INCREMENT,
    VehicleConReqID integer,
    constraint FK_VehicleConReqID foreign key (VehicleConReqID) references VehicleCondnReqs(VehicleConReqID),
    FeeID integer,
    constraint FK_VehicleFee_FeeID foreign key(FeeID) references FeeType(FeeID),
    VehiclFeeCost double
);

-- Create Table Payment
Create Table Payment
(
	PaymentID integer primary key AUTO_INCREMENT,
    PaymentAmount double,
    AuctionSaleID integer,
    constraint FK_Payment_AuctionSaleID foreign key (AuctionSaleID) references AuctionSale(AuctionSaleID),
    PaymentTypeID integer,
    Surcharges double,
    constraint FK_Payment_PaymentTypeID foreign key (PaymentTypeID) references PaymentType(PaymentTypeID),
    PaymentDate datetime
);

Create Table VehiclePictures 
 ( 
	 ImageID integer primary key AUTO_INCREMENT,
     Image longblob, 
     
     VehicleID integer, 
     constraint FK_VehiclePictures_VehicleID foreign key (VehicleID) references Vehicle(VehicleID) 
 ); 

-- Enabling foreign keys
SET FOREIGN_KEY_CHECKS=1;

-- [3][3]						[3][3] --
-- [3][3]						[3][3] --
-- [3][3]  Store Data in Tables	[3][3] --
-- [3][3]						[3][3] --
-- [3][3]						[3][3] --
-- [3][3]						[3][3] --

-- Store Blank Buyer, (We need this if a vehicle is not purchased for an auction

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
("","","","","Alberta","","", 0,TRUE, FALSE, "");

INSERT INTO `conditionstatus` (`ConditionCode`) VALUES ('Not Sold');
INSERT INTO `conditionstatus` (`ConditionCode`) VALUES ('Conditional');
INSERT INTO  `conditionstatus` (`ConditionCode`) VALUES ('Refused');
INSERT INTO  `conditionstatus` (`ConditionCode`) VALUES ('Sold');
INSERT INTO  `conditionstatus` (`ConditionCode`) VALUES ('Paid');

INSERT INTO `paymenttype` (`PaymentDescription`, `SurchargeInPercent`) VALUES ('Cash', 0.00);
INSERT INTO `paymenttype` (`PaymentDescription`, `SurchargeInPercent`) VALUES ('Cheque', 0.00);
INSERT INTO `paymenttype` (`PaymentDescription`, `SurchargeInPercent`) VALUES ('Credit Card', 0.04);
INSERT INTO `paymenttype` (`PaymentDescription`, `SurchargeInPercent`) VALUES ('Debit', 0.00);

INSERT INTO `feetype` (`FeeType`) VALUES ('Towing');
INSERT INTO `feetype` (`FeeType`) VALUES ('Cleaning');
INSERT INTO `feetype` (`FeeType`) VALUES ('Miscellaneous');
INSERT INTO `feetype` (`FeeType`) VALUES ('Storage');

INSERT INTO `gst` (`GSTPercent`, `GSTStatus`) VALUES (5.0, 1);


-- [4][4]					[4][4] --
-- [4][4]					[4][4] --
-- [4][4]  CREATE PROD 		[4][4] --
-- [4][4]					[4][4] --
-- [4][4]					[4][4] --
-- [4][4]					[4][4] --

-- Settings Management STORED PROCEDURES

delimiter //
DROP PROCEDURE IF EXISTS sp_createGSTEntry //
CREATE PROCEDURE sp_createGSTEntry
( pGstPercent integer,pGSTStatus boolean)

BEGIN
	
	INSERT INTO GST (GstPercent,GSTStatus)
	VALUES (pGSTPercent, pGSTStatus);

END//

DROP PROCEDURE IF EXISTS sp_viewGSTEntries //
CREATE PROCEDURE sp_viewGSTEntries()

BEGIN
	
	Select GSTID, GSTPercent, GSTStatus
	FROM GST;

END//

DROP PROCEDURE IF EXISTS sp_updateGSTEntry //
CREATE PROCEDURE sp_updateGSTEntry(IN pGstID integer, IN pGSTPercent integer, pGSTStatus boolean)

BEGIN

	UPDATE GST
	SET
	GSTPercent = pGSTPercent,
	GSTStatus = pGSTStatus
	WHERE GSTID = pGstID;
END//

DROP PROCEDURE IF EXISTS sp_createConditionStatus //
CREATE PROCEDURE sp_createConditionStatus
(IN pConditionCode tinyText, IN pConditionDescription text, IN pStatus boolean)

BEGIN
	
	INSERT INTO conditionstatus (ConditionCode,ConditionDescription)
	VALUES (pConditionCode, pConditionDescription);

END//

DROP PROCEDURE IF EXISTS sp_viewConditionStatus //
CREATE PROCEDURE sp_viewConditionStatus()

BEGIN
	
	Select ConditionId,CONCAT( ConditionCode , if (ConditionDescription is null, "", CONCAT( ' - ' , ConditionDescription))) as Description
	FROM conditionstatus;

END//

DROP PROCEDURE IF EXISTS sp_updateConditionStatus //
CREATE PROCEDURE sp_updateConditionStatus(IN pConditionId integer, IN pConditionDescription text, pConditionCode tinyText, IN pStatus boolean)

BEGIN

	UPDATE conditionstatus
	SET
	ConditionCode = pConditionCode,
	ConditionDescription = pConditionDescription,
    status = pStatus 
	WHERE ConditionID = pConditionId;
END//

DROP PROCEDURE IF EXISTS sp_createFeeType //
CREATE PROCEDURE sp_createFeeType
(IN pFeeCost double, IN pFeeType text, in pStatus boolean)

BEGIN
	
	INSERT INTO FeeType (FeeCost,FeeType)
	VALUES (pFeeCost, pFeeType);

END//

DROP PROCEDURE IF EXISTS sp_viewFeeTypes //
CREATE PROCEDURE sp_viewFeeTypes()

BEGIN
	
	Select FeeId, CONCAT(FeeType, " - ", if(FeeCost is null, 0.00, FeeCost)) as description
	FROM FeeType;

END//

DROP PROCEDURE IF EXISTS sp_updateFeeType //
CREATE PROCEDURE sp_updateFeeType(IN pFeeId integer, IN pFeeType text, pFeeCost double)

BEGIN

	UPDATE FeeType
	SET
	FeeCost = pFeeCost,
	FeeType = pFeeType, 
    Status = pStatus
	WHERE FeeId = pFeeId;
END//

DROP PROCEDURE IF EXISTS sp_createPaymentType //	
CREATE PROCEDURE sp_createPaymentType
(IN pPaymentDescription text)

BEGIN
	
	INSERT INTO PaymentType (PaymentDescription, Status)
	VALUES (pPaymentDescription);

END //

DROP PROCEDURE IF EXISTS sp_viewPaymentType //
CREATE PROCEDURE sp_viewPaymentType()

BEGIN
	
	Select PaymentTypeId, PaymentDescription
	FROM PaymentType;

END//

DROP PROCEDURE IF EXISTS sp_updatePaymentType //
CREATE PROCEDURE sp_updatePaymentType(IN pPaymentId integer, IN pPaymentDescription text)

BEGIN

	UPDATE PaymentType
	SET
	PaymentDescription = pPaymentDescription
	WHERE PaymentTypeId = PaymentTypeId;
END //

DROP PROCEDURE IF EXISTS sp_getGSTByID //
CREATE PROCEDURE sp_getGSTByID(IN pGstID integer)
BEGIN
	Select GSTPercent, GSTStatus
    FROM GST
    where GSTID = pGstID;
END//

DROP PROCEDURE IF EXISTS sp_getconditionstatusByID //
CREATE PROCEDURE sp_getconditionstatusByID(IN pConditionID integer)
BEGIN
	Select ConditionCode, ConditionDescription
    FROM conditionstatus
    where ConditionID = pConditionID;
END//

DROP PROCEDURE IF EXISTS sp_getFeeTypeByID //
CREATE PROCEDURE sp_getFeeTypeByID(IN pFeeID integer)
BEGIN
	Select FeeCost, FeeType
    FROM feetype
    where FeeID = pFeeID;
END//

DROP PROCEDURE IF EXISTS sp_getPaymentTypeByID //
CREATE PROCEDURE sp_getPaymentTypeByID(IN pPaymentTypeID integer)
BEGIN
	Select PaymentDescription
    FROM paymenttype
    where PaymentTypeID = pPaymentTypeID;
END//


-- Buyers Stored Procedures

DROP FUNCTION IF EXISTS sp_createBuyer //
Create FUNCTION sp_createBuyer (
	pBuyerFirstName text,
	pBuyerLastName text,
    pBuyerAddress text,
    pBuyerCity text,
    pBuyerProvince text,
    pBuyerPostalCode text,
    pBuyerPhone text,
    pBuyerLicense text,
    pBuyerBidderNumber integer,
    pBuyerPermanent boolean,
    pBuyerBanned boolean,
	pBuyerNotes text) RETURNS INTEGER

begin    
    INSERT INTO `buyer`
(`BuyerFirstName`,
`BuyerLastName`,
`BuyerAddress`,
`BuyerCity`,
`BuyerProvince`,
`BuyerPostalCode`,
`BuyerPhone`,
`BuyerLicense`,
`BidderNumber`,
`Permanent`,
`Banned`,
`Notes`)
VALUES
(
	pBuyerFirstName,
	pBuyerLastName,
    pBuyerAddress,
    pBuyerCity,
    pBuyerProvince,
    pBuyerPostalCode,
    pBuyerPhone,
    pBuyerLicense,
    pBuyerBidderNumber,
    pBuyerPermanent,
    pBuyerBanned,
	pBuyerNotes)
;
    return LAST_INSERT_ID()
    ;
end //

DROP PROCEDURE IF EXISTS sp_updateBuyer //
CREATE PROCEDURE sp_updateBuyer(
	pBuyerID integer,
	pBuyerFirstName text,
	pBuyerLastName text,
    pBuyerAddress text,
    pBuyerCity text,
    pBuyerProvince text,
    pBuyerPostalCode text,
    pBuyerPhone text,
    pBuyerLicense text,
    pBuyerBidderNumber integer,
    pBuyerPermanent boolean,
    pBuyerBanned boolean,
	pBuyerNotes text)
begin
	UPDATE `buyer`
		SET
		`BuyerFirstName` = pBuyerFirstName,
		`BuyerLastName` = pBuyerLastName,
		`BuyerAddress` = pBuyerAddress,
		`BuyerCity` = pBuyerCity,
		`BuyerProvince` = pBuyerProvince,
		`BuyerPostalCode` = pBuyerPostalCode,
		`BuyerPhone` = pBuyerPhone,
		`BuyerLicense` = pBuyerLicense,
		`BidderNumber` = pBuyerBidderNumber,
		`Banned` = pBuyerBanned,
		`Notes` = pBuyerNotes
		WHERE `BuyerID` = pBuyerID;
end //

DROP PROCEDURE IF EXISTS sp_resetBuyerBidnums //
CREATE PROCEDURE sp_resetBuyerBidnums()
BEGIN
UPDATE `buyer`
SET
`BidderNumber` = null
WHERE Permanent = FALSE; 
END //

DROP PROCEDURE IF EXISTS sp_viewBuyers //
CREATE PROCEDURE sp_viewBuyers()
BEGIN
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
BuyerLicense,
IF(BidderNumber = 0 , "", BidderNumber) as BidderNumber,
Permanent,
Banned,
Notes
FROM `buyer` ;
END //

-- Sellers Stored procedures 

DROP FUNCTION IF EXISTS sp_createSeller //
Create FUNCTION sp_createSeller(pSellerCode text, 
pSellerName text, 
pSellerAddress text, 
pSellerCity text, 
pSellerProvince text, 
pSellerPostalCode text, 
pSellerPhone text, 
pSellerOtherPhone text, 
pSellerFax text, 
pContactFirstName text, 
pContactLastName text, 
-- pSellerFileNumber text,
pSellerPrivate boolean,
pGSTNumber text) RETURNS INTEGER
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
        
        values (pSellerCode, 
        pSellerName,  
        pSellerAddress, 
        pSellerCity, 
        pSellerProvince, 
        pSellerPostalCode, 
        pSellerPhone, 
        pSellerOtherPhone, 
        pSellerFax, 
        pContactFirstName, 
        pContactLastName, 
        -- pSellerFileNumber,
        pSellerPrivate,
        pGSTNumber);
        return LAST_INSERT_ID();
        
end //

DROP PROCEDURE IF EXISTS sp_updateSeller //
CREATE PROCEDURE sp_updateSeller(
pSellerID integer, 
pSellerCode text, 
pSellerName text, 
pSellerAddress text, 
pSellerCity text, 
pSellerProvince text, 
pSellerPostalCode text, 
pSellerPhone text,
pSellerOtherPhone text, 
pSellerFax text, 
pContactFirstName text, 
pContactLastName text, 
-- pSellerFileNumber text,
pSellerPrivate boolean,
pGSTNumber text)
BEGIN
	UPDATE `seller`
	SET
`SellerCode` = pSellerCode,
`SellerName` = pSellerName,
`SellerAddress` = pSellerAddress, 
`SellerCity` = pSellerCity, 
`SellerProvince` = pSellerProvince,
`SellerPostalCode` = pSellerPostalCode,
`SellerPhone` = pSellerPhone,
`SellerOtherPhone` = pSellerOtherPhone,
`SellerFax` = pSellerFax,
`ContactFirstName` = pContactFirstName,
`ContactLastName` = pContactLastName,
-- `SellerFileNumber` = pSellerFileNumber,
`SellerPrivate` = pSellerPrivate,
`GSTNumber` = pGSTNumber
	WHERE `SellerID` = pSellerID;
	END //

DROP PROCEDURE IF EXISTS sp_deleteSeller // 
CREATE PROCEDURE sp_deleteSeller(pSellerID integer)
BEGIN
DELETE FROM seller
WHERE SellerID = pSellerID;
END //

DROP PROCEDURE IF EXISTS sp_viewSellers //
CREATE PROCEDURE sp_viewSellers()
BEGIN
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
SellerPrivate,
GSTNumber
FROM `seller`;
END //

-- DROP PROCEDURE IF EXISTS sp_getSellers //
-- CREATE PROCEDURE sp_getSellers()
-- BEGIN
-- Select SellerID, SellerName
--   FROM seller;
-- END//

-- Auction Queries
DROP PROCEDURE IF EXISTS sp_findAuction //
CREATE PROCEDURE `sp_findAuction`(IN pAuctionYear text)
BEGIN
	select date_format(auctiondate, '%M %e %Y') As AuctionDate, AuctionID, AuctionTotal 
    from AUCTION
    where YEAR(AUCTION.AUCTIONDATE) = pAuctionYear
    order by AuctionDate asc;
END //

DROP FUNCTION IF EXISTS sp_createAuction // 
CREATE FUNCTION `sp_createAuction`(pAuctionDate DATE, pAuctionTotal Double, pSurcharges Double, pCashCharges double, pChequeCharges double, pCreditCardCharges double) RETURNS int
begin
	INSERT INTO auction
		(AuctionDate,
		AuctionTotal,
		Surcharges,
		CashCharges,
		ChequeCharges,
		CreditCardCharges)
	VALUES
		(
        pAuctionDate,
		pAuctionTotal,
		pSurcharges,
		pCashCharges,
		pChequeCharges,
		pCreditCardCharges
		);

return LAST_INSERT_ID()  ; 

end //

DROP PROCEDURE IF EXISTS sp_getAuctionYears //
CREATE PROCEDURE `sp_getAuctionYears`()
BEGIN
	select distinct Year(AuctionDate) As Year
	FROM auction
	order by year(auctionDate) desc;
END //

-- Vehicle Screen queries

DROP FUNCTION IF EXISTS sp_createVehicle //
CREATE FUNCTION sp_createVehicle(pLotNumber text,  pYear text,  pMake text,  pModel text,  pVin text,  pColor text,  pMileage integer,  pUnits text,  pProvince text,  pTransmission text,  pSellerID int,  pOptions text) returns int
BEGIN
INSERT INTO  `vehicle`
(
`LotNumber`,
`Year`,
`Make`,
`Model`,
`VIN`,
`Color`,
`Mileage`,
`Units`,
`Province`,
`Transmission`,
`VehicleOptions`,
`SellerID`)
VALUES
(
pLotNumber,
pYear,
pMake,
pModel,
pVin,
pColor,
pMileage,
pUnits,
pProvince,
pTransmission,
pOptions,
pSellerID);

RETURN LAST_INSERT_ID();
END//

DROP FUNCTION IF EXISTS sp_createVehiclePicture //
CREATE FUNCTION sp_createVehiclePicture(pImage longblob, pVehicleID int) returns int
begin
INSERT INTO vehiclepictures(Image, VehicleID)
VALUES
(
	pImage,
    pVehicleID
);

RETURN LAST_INSERT_ID();
END//

DROP FUNCTION IF EXISTS sp_createAuctionSale //
CREATE FUNCTION sp_createAuctionSale(
	`pAuctionID` int(11),
	`pVehicleID` int(11),
	`pBuyerID` int(11),
	`pBidderNumber` int(11),
	`pSellingPrice` double,
	`pBuyersFee` double,
	`pDeposit` double,
	`pConditionID` int(11),
	`pGSTID` int(11),
	`pTotal` double,
	`pSaledate` date,
	`pNotes` text) returns int

BEGIN
INSERT INTO `auctionsale`
(`AuctionID`,
`VehicleID`,
`BuyerID`,
`BidderNumber`,
`SellingPrice`,
`BuyersFee`,
`Deposit`,
`ConditionID`,
`GSTID`,
`Total`,
`Saledate`,

`Notes`)
VALUES
(`pAuctionID`,
`pVehicleID`,
`pBuyerID`,
`pBidderNumber`,
`pSellingPrice`,
`pBuyersFee`,
`pDeposit`,
`pConditionID`,
`pGSTID`,
`pTotal`,
`pSaledate`,
`pNotes`
);

RETURN LAST_INSERT_ID();
END//

DELIMITER //
DROP PROCEDURE IF EXISTS sp_updateAuctionSale //
CREATE PROCEDURE sp_updateAuctionSale(
	`pAuctionSaleID` int(11),
	`pAuctionID` int(11),
	`pVehicleID` int(11),
	`pBuyerID` int(11),
	`pBidderNumber` int(11),
	`pSellingPrice` double,
	`pBuyersFee` double,
	`pDeposit` double,
	`pConditionID` int(11),
	`pGSTID` int(11),
	`pTotal` double,
	`pSaledate` date,
	`pNotes` text)

BEGIN
UPDATE `auctionsale`
SET
`AuctionID` = pAuctionID,
`VehicleID` = pVehicleID,
`BuyerID` = pBuyerID,
`BidderNumber` = pBidderNumber,
`SellingPrice` = pSellingPrice,
`BuyersFee` = pBuyersFee,
`Deposit` = pDeposit,
`ConditionID` = pConditionID,
`GSTID` = pGSTID,
`Total` = pTotal,
`Saledate` = pSaledate,
`Notes` = pNotes
WHERE `AuctionSaleID` = pAuctionSaleID;
END//

DROP PROCEDURE IF EXISTS sp_deleteAuctionSale //
CREATE PROCEDURE sp_deleteAuctionSale(pAuctionSaleID integer)
	BEGIN
	DELETE FROM AuctionSale
	WHERE AuctionSaleID = pAuctionSaleID;
	END //

delimiter //
DROP FUNCTION IF EXISTS sp_createPayment //
CREATE FUNCTION sp_createPayment(
  `pPaymentAmount` double,
  `pAuctionSaleID` int(11),
  `pPaymentTypeID` int(11),
  `pSurcharges` double,
  `pPaymentDate` datetime
) returns int

BEGIN
INSERT INTO `payment`
(
`PaymentAmount`,
`AuctionSaleID`,
`PaymentTypeID`,
`Surcharges`,
`PaymentDate`)
VALUES
(
`pPaymentAmount`,
`pAuctionSaleID`,
`pPaymentTypeID`,
`pSurcharges`,
`pPaymentDate`);

return LAST_INSERT_ID();
END//

delimiter //
DROP PROCEDURE IF EXISTS sp_updatePayment //
CREATE PROCEDURE sp_updatePayment(
 `pPaymentID` int(11),
  `PaymentAmount` double,
  `AuctionSaleID` int(11),
  `PaymentTypeID` int(11),
  `Surcharges` double,
  `PaymentDate` datetime
)
BEGIN
	UPDATE `payment`
	SET
	`PaymentAmount` = `pPaymentAmount`,
	`AuctionSaleID` = `pAuctionSaleID`,
	`PaymentTypeID` = `pPaymentTypeID`,
	`Surcharges` = `pSurcharges`,
	`PaymentDate` = `pPaymentDate`
	WHERE `PaymentID` = `pPaymentID`;
END//

DROP PROCEDURE IF EXISTS sp_viewPaymentTypes //
CREATE PROCEDURE sp_viewPaymentTypes()
BEGIN	
	Select PaymentTypeID, PaymentDescription, SurchargeInPercent
	FROM PaymentType;
END//


DROP PROCEDURE IF EXISTS sp_getActiveGST //
CREATE PROCEDURE sp_getActiveGST()
BEGIN	
	Select GSTID, GSTPercent, GSTStatus
	FROM gst
	where GSTStatus = 1;
END//

DROP PROCEDURE IF EXISTS sp_getAuctionData //
CREATE PROCEDURE sp_getAuctionData(pAuctionID int(11))
BEGIN
SELECT 
	`seller`.`SellerCode`,
    `vehicle`.`LotNumber`,
    `seller`.`SellerID`,
    `auctionsale`.`AuctionID`,
    `auctionsale`.`AuctionSaleID`,
    `auctionsale`.`VehicleID`,
    `auctionsale`.`BuyerID`,
    `auctionsale`.`SellingPrice`,
    `auctionsale`.`BuyersFee`,
    `auctionsale`.`Deposit`,
    `auctionsale`.`ConditionID`,
    `auctionsale`.`GSTID`,
    0.00 as `GST`,
    0.00 as `PaymentsTotal`,
    0.00 as `SurchargesTotal`,
    0.00 as `NetTotal`,
    `auctionsale`.`Total`,
    `auctionsale`.`Saledate`,
	IF(SUM(`payment`.`PaymentAmount`) is null, 0.00, SUM(`payment`.`PaymentAmount`))  as 'Payments',
	IF(SUM(`payment`.`Surcharges`) is null, 0.00, SUM(`payment`.`Surcharges`))  as 'Surcharges',
    `auctionsale`.`Notes`
	FROM (`seller`, `vehicle`, `auctionsale`) left join `payment` on `payment`.`AuctionSaleID` = `auctionSale`.`AuctionSaleID`
  -- and `payment`.`AuctionSaleID` = `auctionSale`.`AuctionSaleID`
  -- and `conditionstatus`.`ConditionID` = `auctionSale`.`ConditonID`
	WHERE `auctionsale`.`AuctionID` = pAuctionID 
    and `vehicle`.`SellerID` = `seller`.`SellerID`
	and `auctionsale`.`VehicleID` = `vehicle`.`VehicleID`
    group by AuctionSaleID
    ;
END//

DROP PROCEDURE IF EXISTS sp_viewVehiclePictures //
CREATE PROCEDURE sp_viewVehiclePictures(pVehicleID int)
BEGIN
    SELECT `vehiclepictures`.`Image`,
    `vehiclepictures`.`VehicleID`
	FROM `vehiclepictures`
    WHERE `VehicleID` = pVehicleID;
END//

DROP PROCEDURE IF EXISTS sp_getVehicleByID //
CREATE PROCEDURE sp_getVehicleByID(pVehicleID int)
BEGIN
	SELECT 
    `vehicle`.`LotNumber`,
    `vehicle`.`Year`,
    `vehicle`.`Make`,
    `vehicle`.`Model`,
    `vehicle`.`VIN`,
    `vehicle`.`Color`,
    `vehicle`.`Mileage`,
    `vehicle`.`Units`,
    `vehicle`.`Province`,
    `vehicle`.`Transmission`,
    `vehicle`.`VehicleOptions`,
    `vehicle`.`SellerID`
	FROM `vehicle`
	WHERE `vehicle`.`VehicleID` = pVehicleID;
END//

DROP PROCEDURE IF EXISTS sp_updateAuction//
CREATE PROCEDURE sp_updateAuction(pAuctionID int, pAuctionDate datetime, pAuctionTotal double, pSurCharges double, pCashCharges double, pChequeCharges double, pCreditCardCharges double)
BEGIN
	UPDATE `auction`
	SET
	`AuctionDate` = pAuctionDate,
	`AuctionTotal` = pAuctionTotal,
	`SurCharges` = pSurCharges,
	`CashCharges` = pCashCharges,
	`ChequeCharges` = pChequeCharges,
	`CreditCardCharges` = pCreditCardCharges
	WHERE `AuctionID` = pAuctionID;
END//


DROP FUNCTION IF EXISTS sp_createVehicleCondnReqs//
CREATE FUNCTION sp_createVehicleCondnReqs(
`pVehicleConReqID` int,
`pVehicleID` int,
`pReserve` double,
`pRecord` boolean,
`pCallOnHigh` boolean,
`pComments` text,
`pEstValue` double,
`pdateIn` date,
`pForSale` boolean
) returns int
BEGIN
INSERT INTO `vehiclecondnreqs`
(`VehicleConReqID`,
`VehicleID`,
`Reserve`,
`Record`,
`CallOnHigh`,
`Comments`,
`EstValue`,
`dateIn`,
`ForSale`)
VALUES
(
`pVehicleConReqID`,
`pVehicleID`,
`pReserve`,
`pRecord`,
`pCallOnHigh`,
`pComments`,
`pEstValue`,
`pdateIn`,
`pForSale`
);

return LAST_INSERT_ID();
END//

DROP PROCEDURE IF EXISTS sp_viewVehiclesForSale//
CREATE PROCEDURE sp_viewVehiclesForSale()
BEGIN
	SELECT `vehicle`.`VehicleID`, CONCAT(`LotNumber`, " - ", `Year`, " ", `Color`, " ", `Make`, " ", `Model`) as `DisplayInfo`
    FROM `vehicle`, `vehiclecondnreqs`
    WHERE `vehiclecondnreqs`.`VehicleID` = `vehicle`.`VehicleID`;
END//

DROP PROCEDURE IF EXISTS sp_viewAuctionSalePayments//
CREATE PROCEDURE sp_viewAuctionSalePayments(pAuctionSaleID int)
BEGIN
	SELECT `payment`.`PaymentID`,
    `payment`.`PaymentAmount`,
    `payment`.`AuctionSaleID`,
    `payment`.`PaymentTypeID`,
    `payment`.`Surcharges`,
    `payment`.`PaymentDate`
	FROM `payment`
    WHERE `AuctionSaleID` = pAuctionSaleID;
END//

DROP PROCEDURE IF EXISTS sp_getVehiclePicturesByVehicleID//
CREATE PROCEDURE sp_getVehiclePicturesByVehicleID(pVehicleID int)
BEGIN
	SELECT `vehiclepictures`.`ImageID`,
		`vehiclepictures`.`Image`
	FROM `vehiclepictures`
	WHERE `VehicleID` = pVehicleID;
END//

DROP PROCEDURE IF EXISTS sp_deleteBuyer//
CREATE PROCEDURE sp_deleteBuyer(pBuyerID integer)
BEGIN
	DELETE 
    FROM buyer
	WHERE BuyerID = pBuyerID;
END//
