IF OBJECT_ID('dbo.usp_WocBookContractSchedule') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.usp_WocBookContractSchedule
    IF OBJECT_ID('dbo.usp_WocBookContractSchedule') IS NOT NULL
        PRINT '<<< FAILED DROPPING PROCEDURE dbo.usp_WocBookContractSchedule >>>'
    ELSE
        PRINT '<<< DROPPED PROCEDURE dbo.usp_WocBookContractSchedule >>>'
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE

PROCEDURE [dbo].[usp_WocBookContractSchedule](
@ContractID uniqueidentifier,
@ScheduleDate datetime,
@StartTime datetime,
@EndTime datetime,
@TransactionMode INT = 1
)
AS

BEGIN

IF @TransactionMode = 1
BEGIN 
	
	INSERT INTO [ContractSchedule]
        (ContractScheduleID		--1
		, ContractID
		, ScheduleDate		
		, StartTime
		, EndTime)
     VALUES
		(newID()		--1
		,@ContractID
		,@ScheduleDate
		,@StartTime
		,@EndTime)		
END 

IF @TransactionMode = 2
BEGIN
	DELETE FROM [Contract] 
	WHERE ContractID = @ContractID
END


END

GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
IF OBJECT_ID('dbo.usp_WocBookContractSchedule') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE dbo.usp_WocBookContractSchedule >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE dbo.usp_WocBookContractSchedule >>>'
GO


