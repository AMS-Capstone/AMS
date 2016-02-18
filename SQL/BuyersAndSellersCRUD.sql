DELIMITER $$
DROP FUNCTION IF EXISTS ADD_BUYER $$
Create FUNCTION ADD_BUYER (N_BUYER_FIRST_NAME text,
	N_BUYER_LAST_NAME text,
    N_BUYER_ADDRESS text,
    N_BUYER_CITY text,
    N_BUYER_PROVINCE text,
    N_BUYER_POSTAL text,
    N_BUYER_PHONE text,
    N_BUYER_BIDNUM integer,
    N_BUYER_PERM boolean,
    N_BUYER_BANNED boolean) RETURNS INTEGER

begin    
    INSERT INTO `buyers`
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
	N_BUYER_FIRST_NAME,
	N_BUYER_LAST_NAME,
    N_BUYER_ADDRESS,
    N_BUYER_CITY,
    N_BUYER_PROVINCE,
    N_BUYER_POSTAL,
    N_BUYER_PHONE,
    N_BUYER_BIDNUM,
    N_BUYER_PERM,
    N_BUYER_BANNED)
;
    return LAST_INSERT_ID()
    ;
end $$

drop procedure if exists UPDATE_BUYER$$
create procedure UPDATE_BUYER(N_BUYER_ID integer,
N_BUYER_FIRST_NAME text,
    N_BUYER_ADDRESS text,
    N_BUYER_CITY text,
    N_BUYER_PROVINCE text,
    N_BUYER_POSTAL text,
    N_BUYER_PHONE text,
    N_BUYER_BIDNUM integer,
    N_BUYER_PERM boolean,
    N_BUYER_BANNED boolean)
begin
	-- Must make sure that the change is trivial => if only buyer bidder number is changed we don't care
	select 
	@bname := `BuyerFirstName`,
	@baddress := `BuyerAddress`,
	@bcity := `BuyerCity`,
	@bprovince := `BuyerProvince`,
	@bpostal := `BuyerPostalCode`,
	@bphone := `BuyerPhone`,
	-- @bbidnum := `BidderNumber`,
	@bperm := `Permanent`,
	@bbanned := `Banned`
	from buyers where buyers.BUYER_ID = N_BUYER_ID;

	if 	(@bname = N_BUYER_FIRST_NAME) and 
		(@baddress = N_BUYER_ADDRESS) and
		(@bcity = N_BUYER_CITY) and
		(@bprovince = N_BUYER_PROVINCE) and
		(@bpostal = N_BUYER_POSTAL) and
		(@bphone = N_BUYER_PHONE) and
		(@bperm = N_BUYER_PERM) and
		(@bbanned = N_BUYER_BANNED) then

		UPDATE `buyers`
		SET
		`BuyerFirstName` = N_BUYER_FIRST_NAME,
		`BuyerAddress` = N_BUYER_ADDRESS,
		`BuyerCity` = N_BUYER_CITY,
		`BuyerProvince` = N_BUYER_PROVINCE,
		`BuyerPostalCode` = N_BUYER_POSTAL,
		`BuyerPhone` = N_BUYER_PHONE,
		`BidderNumber` = N_BUYER_BIDNUM,
		`Banned` = N_BUYER_BANNED
		WHERE `BuyerID` = N_BUYER_ID;

	elseif (select COUNT(SALE_ID) from sales where sales.BUYER_ID = N_BUYER_ID) > 0 then
		UPDATE `buyers`
		SET
		`BUYER_ACTIVE` = FALSE
		WHERE BUYER_ID = N_BUYER_ID;
		INSERT INTO `buyers`
		(`BuyerFirstName`,
		`BuyerAddress`,
		`BuyerCity`,
		`BuyerProvince`,
		`BuyerPostalCode`,
		`BuyerPhone`,
		`BidderNumber`,
		`Permanent`,
		`Banned`)
		VALUES
		(	N_BUYER_FIRST_NAME,
			N_BUYER_ADDRESS,
			N_BUYER_CITY,
			N_BUYER_PROVINCE,
			N_BUYER_POSTAL,
			N_BUYER_PHONE,
			N_BUYER_BIDNUM,
			N_BUYER_PERM,
			N_BUYER_BANNED);
	ELSE
		UPDATE `buyers`
		SET
		`BuyerFirstName` = N_BUYER_FIRST_NAME,
		`BuyerAddress` = N_BUYER_ADDRESS,
		`BuyerCity` = N_BUYER_CITY,
		`BuyerProvince` = N_BUYER_PROVINCE,
		`BuyerPostalCode` = N_BUYER_POSTAL,
		`BuyerPhone` = N_BUYER_PHONE,
		`BidderNumber` = N_BUYER_BIDNUM,
		`Banned` = N_BUYER_BANNED
		WHERE `BuyerID` = N_BUYER_ID;
	end if;
end;
$$

drop procedure if exists DEL_BUYER$$
create procedure DEL_BUYER(N_BUYER_ID integer)
if (select COUNT(SALE_ID) from sales where sales.BUYER_ID = N_BUYER_ID) > 0 then
UPDATE `buyers`
SET
`BUYER_ACTIVE` = FALSE
WHERE BUYER_ID = N_BUYER_ID;
ELSE
delete FROM BUYERS
WHERE BUYER_ID = N_BUYER_ID;
end if;
$$
DELIMITER ;

drop procedure if exists RESET_BUYER_BIDNUMS;
create procedure RESET_BUYER_BIDNUMS()
UPDATE `buyers`
SET
`BidderNumber` = null
WHERE BUYER_ACTIVE = TRUE AND BUYER_PERM = FALSE; 

drop procedure if exists GET_BUYERS;
create procedure GET_BUYERS()
SELECT
BUYER_ID,
BUYER_NAME,
BUYER_ADDRESS,
BUYER_CITY,
BUYER_PROVINCE,
BUYER_POSTAL,
BUYER_PHONE,
BUYER_BIDNUM,
BUYER_PERM,
BUYER_BANNED
FROM `buyers`
where BUYER_ACTIVE = TRUE;

DELIMITER $$
DROP FUNCTION IF EXISTS ADD_CON $$
Create FUNCTION ADD_CON(N_CON_CODE text, 
N_CON_NAME text, 
N_CON_ADDRESS text, 
N_CON_CITY text, 
N_CON_PROVINCE text, 
N_CON_POSTAL text, 
N_CON_PHONE text, 
N_OTH_PHONE text, 
N_CON_FAX text, 
N_CON_CONTACT text, 
N_CON_FILE_NUMBER text,
N_CON_DL text,
N_CON_GST boolean) RETURNS INTEGER
begin
        insert into CONS(CON_CODE, 
        CON_NAME, 
        CON_ADDRESS, 
        CON_CITY, 
        CON_PROVINCE, 
        CON_POSTAL, 
        CON_PHONE, 
        OTH_PHONE, 
        CON_FAX, 
        CON_CONTACT, 
        CON_FILE_NUMBER,
        CON_DL,
        CON_GST) 
        
        values (N_CON_CODE, 
        N_CON_NAME, 
        N_CON_ADDRESS, 
        N_CON_CITY, 
        N_CON_PROVINCE, 
        N_CON_POSTAL, 
        N_CON_PHONE, 
        N_OTH_PHONE, 
        N_CON_FAX, 
        N_CON_CONTACT, 
        N_CON_FILE_NUMBER,
        N_CON_DL,
        N_CON_GST);
        return LAST_INSERT_ID();
        
end $$
DELIMITER ;

drop procedure if exists UPDATE_CON;
create procedure UPDATE_CON(
N_CON_ID integer, 
N_CON_CODE text, 
N_CON_NAME text, 
N_CON_ADDRESS text, 
N_CON_CITY text, 
N_CON_PROVINCE text, 
N_CON_POSTAL text, 
N_CON_PHONE text,
N_OTH_PHONE text, 
N_CON_FAX text, 
N_CON_CONTACT text, 
N_CON_FILE_NUMBER text,
N_CON_DL text,
N_CON_GST boolean)
UPDATE `cons`
SET
`CON_CODE` = N_CON_CODE,
`CON_NAME` = N_CON_NAME,
`CON_ADDRESS` = N_CON_ADDRESS, 
`CON_CITY` = N_CON_CITY, 
`CON_PROVINCE` = N_CON_PROVINCE,
`CON_POSTAL` = N_CON_POSTAL,
`CON_PHONE` = N_CON_PHONE,
`OTH_PHONE` = N_OTH_PHONE,
`CON_FAX` = N_CON_FAX,
`CON_CONTACT` = N_CON_CONTACT,
`CON_FILE_NUMBER` = N_CON_FILE_NUMBER,
CON_DL = N_CON_DL,
CON_GST = N_CON_GST
WHERE `CON_ID` = N_CON_ID;

drop procedure if exists DEL_CON;
create procedure DEL_CON(N_CON_ID integer)
DELETE FROM CONS
WHERE CON_ID = N_CON_ID;

DROP PROCEDURE IF EXISTS GET_CONS;
Create Procedure GET_CONS()
    SELECT
CON_ID,
CON_CODE,
CON_NAME,
CON_ADDRESS, 
CON_CITY, 
CON_PROVINCE,
CON_POSTAL,
CON_PHONE,
OTH_PHONE,
CON_FAX,
CON_CONTACT,
CON_FILE_NUMBER 'CON_FILE#',
CON_DL,
CON_GST
FROM `cons`;