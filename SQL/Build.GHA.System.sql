-- USE GHATest;
-- Purpose: The statements below create the tables for the GHA system.alter. The script is broken into 3 major phases.
-- [1] Drop Tables if it exists
-- [2] Create Tables
-- [3] Load Tables With Data
-- [4] Create Prod

-- [1][1]				[1][1] --
-- [1][1]				[1][1] --
-- [1][1]  DROP TABLES 	[1][1] --
-- [1][1]				[1][1] --
-- [1][1]				[1][1] --
-- [1][1]				[1][1] --

drop table if exists VehiclePictures;
drop table if exists Payment;
drop table if exists VehicleFeeId;
drop table if exists VehicleCondnReqs;
drop table if exists AuctionSale;
drop table if exists Vehicle;
drop table if exists Seller;
drop table if exists Buyer;
drop table if exists PaymentType ;
drop table if exists GST;
drop table if exists FeeType;
drop table if exists ConditionStatus;
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
    CreditCardCharges double,
    AuctioneerFirstName text,
    AuctioneerLastName text
);
    
-- Create the ConditionStatus table
Create Table ConditionStatus
(
	ConditionID integer primary key AUTO_INCREMENT,
    ConditionCode tinytext,
    CondidtionDescription text
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
    PaymentDescription text
);

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
    LotNumber integer, 
    Year text, 
    Make text,
    Model text,
    VIN text,
    Color text,
    Mileage int,
    Units text,
    ProvinceID integer,
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
    SellingPrice double, 
    BuyersFee double, 
    Deposit double,
    ConiditonCode text,
    GSTID integer,
    constraint FK_AuctionSale_GSTID foreign key (GSTID) references GST(GSTID),
    Total double, 
    saledate date,
    Notes text,
    BuyerID integer,
    constraint FK_AuctionSale_BuyerID foreign key (BuyerID) references Buyer(BuyerID)
);

-- Create table Vehicle CondnReqs
Create Table VehicleCondnReqs
(
	VehicleConReqID integer primary key AUTO_INCREMENT,
    VehicleID integer,
    constraint FK_VehicleCondnReqs_VehicleID foreign key (VehicleID) references Vehicle(VehicleID),
	Reserve text,
    Record boolean, 
    CallOnHigh boolean,
    Comments text,
    EstValue double,
    dateIn date,
    ForSale boolean
);

-- Create table VehicleFeeID
Create Table VehicleFeeID
(
	VehicleFeeID integer primary key AUTO_INCREMENT,
    VehicleConReqID integer,
    constraint FK_VehicleConReqID foreign key (VehicleConReqID) references VehicleCondnReqs(VehicleConReqID),
    FeeID integer,
    constraint FK_VehicleFeeID_FeeID foreign key(FeeID) references FeeType(FeeID),
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
     Image longblob, 
     VehicleID integer, 
     constraint FK_VehiclePictures_VehicleID foreign key (VehicleID) references Vehicle(VehicleID) 
 ); 

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
("","","","","","","", 0,TRUE, FALSE, "");

INSERT INTO `conditionstatus` (`ConditionCode`) VALUES ('Not Sold');
INSERT INTO `conditionstatus` (`ConditionCode`) VALUES ('Conditional');
INSERT INTO  `conditionstatus` (`ConditionCode`) VALUES ('Refused');
INSERT INTO  `conditionstatus` (`ConditionCode`) VALUES ('Sold');
INSERT INTO  `conditionstatus` (`ConditionCode`) VALUES ('Paid');

INSERT INTO `paymenttype` (`PaymentDescription`) VALUES ('Cash');
INSERT INTO `paymenttype` (`PaymentDescription`) VALUES ('Cheque');
INSERT INTO `paymenttype` (`PaymentDescription`) VALUES ('Credit Card');
INSERT INTO `paymenttype` (`PaymentDescription`) VALUES ('Debit');

INSERT INTO `feetype` (`FeeType`) VALUES ('Towing');
INSERT INTO `feetype` (`FeeType`) VALUES ('Cleaning');
INSERT INTO `feetype` (`FeeType`) VALUES ('Miscellaneous');
INSERT INTO `feetype` (`FeeType`) VALUES ('Storage');


-- [4][4]					[4][4] --
-- [4][4]					[4][4] --
-- [4][4]  CREATE PROD 		[4][4] --
-- [4][4]					[4][4] --
-- [4][4]					[4][4] --
-- [4][4]					[4][4] --

-- Settings Management STORED PROCEDURES

delimiter //
drop procedure if exists sp_createGSTEntry //
create procedure sp_createGSTEntry
( pGstPercent integer,pGSTStatus boolean)

BEGIN
	
	INSERT INTO GST (GstPercent,GSTStatus)
	VALUES (pGSTPercent, pGSTStatus);

END//

drop procedure if exists sp_viewGSTEntries //
create procedure sp_viewGSTEntries()

BEGIN
	
	Select GSTID, GSTPercent, GSTStatus
	FROM GST;

END//

drop procedure if exists sp_updateGSTEntry //
create procedure sp_updateGSTEntry(IN pGstID integer, IN pGSTPercent integer, pGSTStatus boolean)

BEGIN

	UPDATE GST
	SET
	GSTPercent = pGSTPercent,
	GSTStatus = pGSTStatus
	WHERE GSTID = pGstID;
END//

drop procedure if exists sp_createConditionStatus //
create procedure sp_createConditionStatus
(IN pConditionCode tinyText, IN pConditionDescription text, IN pStatus boolean)

BEGIN
	
	INSERT INTO ConditionStatus (ConditionCode,CondidtionDescription, status)
	VALUES (pConditionCode, pConditionDescription, pStatus);

END//

drop procedure if exists sp_viewConditionStatus //
create procedure sp_viewConditionStatus()

BEGIN
	
	Select ConditionId,CONCAT( ConditionCode , ' - ' , CondidtionDescription) as Description, status
	FROM ConditionStatus;

END//

drop procedure if exists sp_updateConditionStatus //
create procedure sp_updateConditionStatus(IN pConditionId integer, IN pConditionDescription text, pConditionCode tinyText, IN pStatus boolean)

BEGIN

	UPDATE ConditionStatus
	SET
	ConditionCode = pConditionCode,
	CondidtionDescription = pConditionDescription,
    status = pStatus 
	WHERE ConditionID = pConditionId;
END//

drop procedure if exists sp_createFeeType //
create procedure sp_createFeeType
(IN pFeeCost double, IN pFeeType text, in pStatus boolean)

BEGIN
	
	INSERT INTO FeeType (FeeCost,FeeType, Status)
	VALUES (pFeeCost, pFeeType, pStatus);

END//

drop procedure if exists sp_viewFeeTypes //
create procedure sp_viewFeeTypes()

BEGIN
	
	Select FeeId, CONCAT( FeeCost, ' - ' , FeeType) as description, status
	FROM FeeType;

END//

drop procedure if exists sp_updateFeeType //
create procedure sp_updateFeeType(IN pFeeId integer, IN pFeeType text, pFeeCost double, pStatus boolean)

BEGIN

	UPDATE FeeType
	SET
	FeeCost = pFeeCost,
	FeeType = pFeeType, 
    Status = pStatus
	WHERE FeeId = pFeeId;
END//

drop procedure if exists sp_createPaymentType //	
create procedure sp_createPaymentType
(IN pPaymentDescription text, in pStatus boolean)

BEGIN
	
	INSERT INTO PaymentType (PaymentDescription, Status)
	VALUES (pPaymentDescription, pStatus);

END //

drop procedure if exists sp_viewPaymentType //
create procedure sp_viewPaymentType()

BEGIN
	
	Select PaymentTypeId, PaymentDescription, pStatus
	FROM PaymentType;

END//

drop procedure if exists sp_updatePaymentType //
create procedure sp_updatePaymentType(IN pPaymentId integer, IN pPaymentDescription text, IN pStatus boolean)

BEGIN

	UPDATE PaymentType
	SET
	PaymentDescription = pPaymentDescription, 
    Status = pStatus
	WHERE PaymentTypeId = PaymentTypeId;
END //

drop procedure if exists sp_getGSTByID //
create procedure sp_getGSTByID(IN pGstID integer)
BEGIN
	Select GSTPercent, GSTStatus
    FROM GST
    where GSTID = pGstID;
END//

drop procedure if exists sp_getConditionStatusByID //
create procedure sp_getConditionStatusByID(IN pConditionID integer)
BEGIN
	Select ConditionCode, CondidtionDescription, Status
    FROM conditionstatus
    where ConditionID = pConditionID;
END//

drop procedure if exists sp_getFeeTypeByID //
create procedure sp_getFeeTypeByID(IN pFeeID integer)
BEGIN
	Select FeeCost, FeeType, Status
    FROM feetype
    where FeeID = pFeeID;
END//

drop procedure if exists sp_getPaymentTypeByID //
create procedure sp_getPaymentTypeByID(IN pPaymentTypeID integer)
BEGIN
	Select PaymentDescription, Status
    FROM paymenttype
    where PaymentTypeID = pPaymentTypeID;
END//


-- Buyers Stored Procedures

DROP FUNCTION IF EXISTS ADD_BUYER //
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
end //

drop procedure if exists UPDATE_BUYER //
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
end //

drop procedure if exists RESET_BUYER_BIDNUMS //
create procedure RESET_BUYER_BIDNUMS()
BEGIN
UPDATE `buyer`
SET
`BidderNumber` = null
WHERE Permanent = FALSE; 
END //

drop procedure if exists GET_BUYERS //
create procedure GET_BUYERS()
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
BidderNumber,
Permanent,
Banned,
Notes
FROM `buyer` ;
END //

-- Sellers Stored procedures 

DROP FUNCTION IF EXISTS ADD_SELLER //
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
        
end //

drop procedure if exists UPDATE_SELLER //
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
BEGIN
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
	END //

drop procedure if exists DEL_CON //
create procedure DEL_CON(N_SellerID integer)
	BEGIN
	DELETE FROM CONS
	WHERE SellerID = N_SellerID;
	END //

drop procedure if exists DEL_SELLER // 
create procedure DEL_SELLER(N_SellerID integer)
BEGIN
DELETE FROM seller
WHERE SellerID = N_SellerID;
END //

DROP PROCEDURE IF EXISTS GET_SELLERS //
Create Procedure GET_SELLERS()
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
-- SellerFileNumber 'SELLER_FILE#',
SellerPrivate,
GSTNumber
FROM `seller`;
END //

-- drop procedure if exists sp_getSellers //
-- create procedure sp_getSellers()
-- BEGIN
-- Select SellerID, SellerName
--   FROM seller;
-- END//

-- Auction Queries
drop procedure if exists sp_findAuction //
CREATE PROCEDURE `sp_FindAuction`(IN pAuctionYear text)
BEGIN
	select date_format(auctiondate, '%M %e %Y') As AuctionDate, AuctionID, AuctionTotal 
    from AUCTION
    where YEAR(AUCTION.AUCTIONDATE) = pAuctionYear;
END //

drop function if exists sp_createAuction // 
CREATE FUNCTION `sp_createAuction`(pAuctionDate DATE, pAuctionTotal Double, pSurcharges Double, pCashCharges double, pChequeCharges double, pCreditCardCharges double, pAuctioneerFirstName text, pAuctioneerLastName text) RETURNS int
begin
	INSERT INTO auction
		(AuctionDate,
		AuctionTotal,
		Surcharges,
		CashCharges,
		ChequeCharges,
		CreditCardCharges,
		AuctioneerFirstName,
		AuctioneerLastName)
	VALUES
		(
        pAuctionDate,
		pAuctionTotal,
		pSurcharges,
		pCashCharges,
		pChequeCharges,
		pCreditCardCharges,
		pAuctioneerFirstName,
		pAuctioneerLastName
		);

return LAST_INSERT_ID()  ; 

end //

drop procedure if exists sp_getAuctionYears //
CREATE PROCEDURE `sp_getAuctionYears`()
BEGIN
	select distinct Year(AuctionDate) As Year
	FROM auction
	order by year(auctionDate) desc;
END //

-- Vehicle Screen queries

drop procedure if exists sp_createVehicle //
create procedure sp_createVehicle(In pLotNumber integer, in pYear text, in pMake text, in pModel text, in pVin text, in pColor text, in pMileage integer, in pUnits text, in pTransmission text, in pSellerID int, in pOptions text, out vehicleID integer)
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
pTransmission,
pOptions,
pSellerID);

SELECT LAST_INSERT_ID();
END//

drop procedure if exists sp_createVehiclePicture //
create procedure sp_createVehiclePicture(in pImage blob, pVehicleID int)
begin
INSERT INTO vehiclepictures(Image, VehicleID)
VALUES
(
	pImage,
    pVehicleID
);
END//
 
