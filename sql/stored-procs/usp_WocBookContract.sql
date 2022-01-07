IF OBJECT_ID('dbo.usp_WocBookContract') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.usp_WocBookContract
    IF OBJECT_ID('dbo.usp_WocBookContract') IS NOT NULL
        PRINT '<<< FAILED DROPPING PROCEDURE dbo.usp_WocBookContract >>>'
    ELSE
        PRINT '<<< DROPPED PROCEDURE dbo.usp_WocBookContract >>>'
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE

PROCEDURE [dbo].[usp_WocBookContract](
@BookingCode nvarchar(200) = NULL,
@AgentID uniqueidentifier = NULL,
@StartDate datetime = NULL,
@StopDate datetime = NULL,
@TripType nvarchar(400) = NULL,
@TripFrom nvarchar(400) = NULL,
@TripTo nvarchar(400) = NULL,
@Seater INT = 0,
@InvoiceText nvarchar(250) = NULL,
@PersonInCharge nvarchar(30) = NULL,
@Contact nvarchar(30) = NULL,
@PONumber  nvarchar(50) = NULL,
@RatesType nvarchar(5) = NULL,
@Rates money = 0,
@Remarks1 nvarchar(30) = NULL,
@Remarks2 nvarchar(30) = NULL,
@DriverClaim nvarchar(30) = NULL,
@GST nvarchar(30) = NULL,
@Mon bit,
@Tue bit,
@Wed bit,
@Thu bit,
@Fri bit,
@Sat bit,
@Sun bit,
@StartMon nvarchar(10) = NULL,
@StartTue nvarchar(10) = NULL,
@StartWed nvarchar(10) = NULL,
@StartThu nvarchar(10) = NULL,
@StartFri nvarchar(10) = NULL,
@StartSat nvarchar(10) = NULL,
@StartSun nvarchar(10) = NULL,
@EndMon nvarchar(10) = NULL,
@EndTue nvarchar(10) = NULL,
@EndWed nvarchar(10) = NULL,
@EndThu nvarchar(10) = NULL,
@EndFri nvarchar(10) = NULL,
@EndSat nvarchar(10) = NULL,
@EndSun nvarchar(10) = NULL,
@CreatedBy uniqueidentifier = NULL,
@UpdatedBy uniqueidentifier = NULL,
@TransactionMode INT = 1,
@ContractID UNIQUEIDENTIFIER = NULL OUTPUT
)
AS

BEGIN

IF @TransactionMode = 1
BEGIN 
	DECLARE @newID UNIQUEIDENTIFIER
	DECLARE @AgentCode NVARCHAR(100)
	
	SET @newID = newID()
	
	SELECT @AgentCode = AgentCode FROM Agent WHERE  AgentID = @AgentID
	
	INSERT INTO [Contract]
        (ContractID		--1
		, BookingCode
		, AgentID		
		, StartDate
		, StopDate		--5
		, TripType
		, TripFrom		
		, TripTo
		, Seater		
		, InvoiceText		--10
		, PersonInCharge
		, Contact
		, RatesType
		, Rates
		, Remarks1		--15
		, Remarks2
		, DriverClaim
		, GST
		, Mon
		, Tue			--20
		, Wed
		, Thu
		, Fri
		, Sat
		, Sun			--25
		, StartMon
		, StartTue
		, StartWed
		, StartThu
		, StartFri		--30
		, StartSat
		, StartSun
		, EndMon
		, EndTue
		, EndWed		--35
		, EndThu
		, EndFri
		, EndSat
		, EndSun
		, CreatedBy		--40
		, CreatedDate	
		, PONumber
		)
     VALUES
		(@newID		--1
		,@AgentCode + @BookingCode
		,@AgentID
		,@StartDate
		,@StopDate		--5
		,@TripType
		,@TripFrom
		,@TripTo
		,@Seater
		,@InvoiceText		--10
		,@PersonInCharge
		,@Contact
		,@RatesType
		,@Rates
		,@Remarks1		--15
		,@Remarks2
		,@DriverClaim
		,@GST
		,@Mon
		,@Tue			--20
		,@Wed
		,@Thu
		,@Fri
		,@Sat
		,@Sun			--25
		,@StartMon
		,@StartTue
		,@StartWed
		,@StartThu
		,@StartFri		--30
		,@StartSat
		,@StartSun
		,@EndMon
		,@EndTue
		,@EndWed		--35
		,@EndThu
		,@EndFri
		,@EndSat
		,@EndSun		
		,@CreatedBy		--40
		,getDate()
		,@PONumber)		
	SET @ContractID = @newID
END 

IF @TransactionMode = 2
BEGIN

	UPDATE [Contract]
	   SET [AgentID] = @AgentID 
		  ,[StartDate] = @StartDate 
		  ,[StopDate] = @StopDate 
		  ,[TripType] = @TripType 
		  ,[TripFrom] = @TripFrom 
		  ,[TripTo] = @TripTo 
		  ,[Seater] = @Seater 
		  ,[InvoiceText] = @InvoiceText 
		  ,[PONumber] = @PONumber 
		  ,[PersonInCharge] = @PersonInCharge 
		  ,[Contact] = @Contact 
		  ,[RatesType] = @RatesType 
		  ,[Rates] = @Rates
		  ,[Remarks1] = @Remarks1 
		  ,[Remarks2] = @Remarks2 
		  ,[DriverClaim] = @DriverClaim 
		  ,[GST] = @GST 
		  ,[Mon] = @Mon 
		  ,[Tue] = @Tue 
		  ,[Wed] = @Wed 
		  ,[Thu] = @Thu 
		  ,[Fri] = @Fri 
		  ,[Sat] = @Sat 
		  ,[Sun] = @Sun 
		  ,[StartMon] = @StartMon 
		  ,[StartTue] = @StartTue 
		  ,[StartWed] = @StartWed 
		  ,[StartThu] = @StartThu 
		  ,[StartFri] = @StartFri 
		  ,[StartSat] = @StartSat 
		  ,[StartSun] = @StartSun 
		  ,[EndMon] = @EndMon 
		  ,[EndTue] = @EndTue 
		  ,[EndWed] = @EndWed 
		  ,[EndThu] = @EndThu 
		  ,[EndFri] = @EndFri 
		  ,[EndSat] = @EndSat 
		  ,[EndSun] = @EndSun 
		  ,[UpdatedBy] = @UpdatedBy
		  ,[UpdatedDate] = GetDate()
	WHERE [BookingCode] = @BookingCode 
	
END

IF @TransactionMode = 3
BEGIN 
	DELETE FROM [Contract] WHERE BookingCode = @BookingCode;
END

END

GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
IF OBJECT_ID('dbo.usp_WocBookContract') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE dbo.usp_WocBookContract >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE dbo.usp_WocBookContract >>>'
GO


