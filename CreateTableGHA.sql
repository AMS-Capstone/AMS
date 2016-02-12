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
    BuyerCountry Text,
    BuyerPhone Text,
    Permanent boolean default false,
    Banned boolean default false
);


-- Create the Seller table
Create Table Seller 
(
	SellerID integer primary key AUTO_INCREMENT,
    SellerCode char(30),
    SellerName text,
    Street text,
    City text,
    Province text,
    PostalCode char(6),
    Country text,
    Phone text,
    Fax text,
    ContactFirstName text,
    ContactLastName text,
    ConFile text,
    DebtorFirstName text,
    DebtorLastName text,
    Private boolean,
    GSTNumber text
);

-- Create Table FeeType
Create Table FeeType
(
	FeeID integer primary key AUTO_INCREMENT,
    FeeCost double,
    FeeType text
);

-- Create Table Province
Create Table Province 
(
	ProvinceID integer primary key AUTO_INCREMENT,
    Province text
);

-- Create Table GST
Create Table GST 
(
	GSTID integer primary key AUTO_INCREMENT,
    GSTPercent integer,
    GSTStatus boolean
);

-- Create Table PaymentType
Create Table PaymentType
(
	PaymentTypeID integer primary key AUTO_INCREMENT,
    PaymentDescription text
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
    constraint ProvinceID  foreign key (ProvinceID) references Province(ProvinceID),
    Transmission text, 
    VehicleOptions text,
    SellerID integer,
	constraint SellerID foreign key (SellerID) references Seller(SellerID)
);
-- Create table AuctionSale 
Create Table AuctionSale 
(
	AuctionSaleID integer primary key AUTO_INCREMENT,
    AuctionID integer,
    constraint AuctionID foreign key (AuctionID) references Auction(AuctionID),
    VehicleID integer,
    constraint VehicleID foreign key (VehicleID) references Vehicle(VehicleID),
    SellingPrice double, 
    BuyersFee double, 
    Deposit double,
    ConiditonCode text,
    GSTID integer,
    constraint GSTID foreign key (GSTID) references GST(GSTID),
    Total double, 
    saledate date,
    Notes text,
    BuyerID integer,
    constraint BuyerID foreign key (BuyerID) references Buyer(BuyerID)
);

Create Table VehicleCondnReqs
(
	VehicleConReqID integer primary key AUTO_INCREMENT,
    VehicleID integer,
    constraint VehicleID foreign key (VehicleID) references Vehicle(VehicleID),
	Reserve text,
    Record boolean, 
    CallOnHigh boolean,
    Comments text,
    EstValue double,
    dateIn date,
    ForSale boolean
);

Create Table VehicleFeeID
(
	VehicleFeeID integer primary key AUTO_INCREMENT,
    VehicleConReqID integer,
    constraint VehicleConReqID foreign key (VehicleConReqID) references VehicleCondnReqs(VehicleConReqID),
    FeeID integer,
    constraint FeeID foreign key(FeeID) references FeeType(FeeID),
    VehiclFeeCost double
);

Create Table Payment
(
	PaymentID integer primary key AUTO_INCREMENT,
    Payment double,
    AuctionSaleID integer,
    constraint AuctionSaleID foreign key (AuctionSaleID) references AuctionSale(AuctionSaleID),
    PaymentTypeID integer,
    constraint PaymentTypeID foreign key (PaymentTypeID) references PaymentType(PaymentTypeID),
    PaymentDate datetime
);

