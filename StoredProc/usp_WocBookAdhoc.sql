IF OBJECT_ID('dbo.usp_WocBookAdhoc') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.usp_WocBookAdhoc
    IF OBJECT_ID('dbo.usp_WocBookAdhoc') IS NOT NULL
        PRINT '<<< FAILED DROPPING PROCEDURE dbo.usp_WocBookAdhoc >>>'
    ELSE
        PRINT '<<< DROPPED PROCEDURE dbo.usp_WocBookAdhoc >>>'
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE 
PROCEDURE [dbo].[usp_WocBookAdhoc](

@AgentID UniqueIdentifier  = null,
@AdhocCode NVarchar(50) = null,
@AdhocBookDate datetime  = null,
@TripType NVarchar(50)  = null,
@TripFrom NVarchar(50)  = null,
@TripTo NVarchar(50)  = null,
@TimeDepart datetime  = null,
@TimeReturn datetime  = null,
@Seater int = null,
@Purpose NVarchar(50) = null,
@PersonInCharge NVarchar(50) = null,
@DriverClaim NVarchar(50) = null,
@Contact NVarchar(50) = null,
@Delete NVarchar(50) = null,
@UpdatedBy UniqueIdentifier  = null,
@Voided BIT = 1,
@TransactionMode INT
)
AS

BEGIN

IF @TransactionMode = 1
BEGIN 

	INSERT INTO [Adhoc]
           (AdhocID,
            AgentID,
            AdhocCode,
            AdhocBookDate,
            TripType,
            TripFrom,
            TripTo,
            TimeDepart,
			TimeReturn,
			Seater,
			Purpose,
			PersonInCharge,
            DriverClaim,
            Contact,
            [Delete]
            )
           
     VALUES
            (NEWID(),
            @AgentID,
            @AdhocCode,
            @AdhocBookDate,
            @TripType,
            @TripFrom,
            @TripTo,
            @TimeDepart,
			@TimeReturn,
			@Seater,
			@Purpose,
			@PersonInCharge,
            @DriverClaim,
            @Contact,
            @Delete
            )
END 
ELSE IF @TransactionMode = 2
BEGIN

	Update Adhoc
	Set Voided = @Voided
	  , UpdatedBy = @UpdatedBy
	  , UpdatedDate = GetDate()
	WHERE AdhocCode = @AdhocCode
	
END


END


GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
IF OBJECT_ID('dbo.usp_WocBookAdhoc') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE dbo.usp_WocBookAdhoc >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE dbo.usp_WocBookAdhoc >>>'
GO