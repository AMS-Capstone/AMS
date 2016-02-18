-- Settings Management Procedures
-- Author: Duane Roach
-- Created: February 16, 2016
-- Validated: 

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
(IN pConditionCode tinyText, IN pConditionDescription text)

BEGIN
	
	INSERT INTO ConditionStatus (ConditionCode,ConditionDescription)
	VALUES (pConditionCode, pConditionDescription);

END//

drop procedure if exists sp_viewConditionStatus //
create procedure sp_viewConditionStatus()

BEGIN
	
	Select ConditionId, ConditionCode, ConditionDescription
	FROM ConditionStatus;

END//

drop procedure if exists sp_updateConditionStatus //
create procedure sp_updateConditionStatus(IN pConditionId integer, IN pConditionDescription text, pConditionCode tinyText)

BEGIN

	UPDATE ConditionStatus
	SET
	ConditionCode = pConditionCode,
	ConditionDescription = pConditionDescription
	WHERE ConditionStatus = pConditionId;
END//

drop procedure if exists sp_createFeeType //
create procedure sp_createFeeType
(IN pFeeCost double, IN pFeeType text)

BEGIN
	
	INSERT INTO FeeType (FeeCost,FeeType)
	VALUES (pFeeCost, pFeeType);

END//

drop procedure if exists sp_viewFeeTypes //
create procedure sp_viewFeeTypes()

BEGIN
	
	Select FeeId, FeeCost, FeeType
	FROM FeeType;

END//

drop procedure if exists sp_updateFeeType //
create procedure sp_updateFeeType(IN pFeeId integer, IN pFeeType text, pFeeCost double)

BEGIN

	UPDATE FeeType
	SET
	FeeCost = pFeeCost,
	FeeType = pFeeType
	WHERE FeeId = pFeeId;
END//


drop procedure if exists sp_createPaymentType //	
create procedure sp_createPaymentType
(IN pPaymentDescription text)

BEGIN
	
	INSERT INTO PaymentType (PaymentDescription)
	VALUES (pPaymentDescription);

END //

drop procedure if exists sp_viewPaymentType //
create procedure sp_viewPaymentType()

BEGIN
	
	Select PaymentTypeId, PaymentDescription
	FROM PaymentType;

END//

drop procedure if exists sp_updatePaymentType //
create procedure sp_updatePaymentType(IN pPaymentId integer, IN pPaymentDescription text)

BEGIN

	UPDATE PaymentType
	SET
	PaymentDescription = pPaymentDescription
	WHERE PaymentTypeId = PaymentTypeId;
END //
