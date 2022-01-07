IF OBJECT_ID('dbo.usp_WocBookSearchInvoice') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.usp_WocBookSearchInvoice
    IF OBJECT_ID('dbo.usp_WocBookSearchInvoice') IS NOT NULL
        PRINT '<<< FAILED DROPPING PROCEDURE dbo.usp_WocBookSearchInvoice >>>'
    ELSE
        PRINT '<<< DROPPED PROCEDURE dbo.usp_WocBookSearchInvoice >>>'
END
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE

PROCEDURE [dbo].[usp_WocBookSearchInvoice](
@AgentID uniqueidentifier,
@StartDate DATETIME,
@EndDate DATETIME,
@TransactionMode INT
)
AS

BEGIN

	IF @TransactionMode = 1 
	BEGIN
		 SELECT C.BookingCode AS RefNo 
			, CS.StartTime 
			, CS.EndTime 
			, CASE WHEN UPPER(C.TripType) = 'ONE WAY' THEN C.TripFrom + ' > ' + C.TripTo 
				ELSE C.TripFrom + ' <> ' + C.TripTo END  AS Description
			, C.Seater AS Pax
			, CASE WHEN C.RatesType = 1 THEN 'Daily' 
				ELSE 'Contract' END AS RatesType
			, C.Rates
		 FROM Contract AS C 
		 INNER JOIN CONTRACTSCHedule AS CS ON (C.ContractID = CS.ContractID)
		 WHERE CS.ScheduleDate > DATEADD(d, -1, @StartDate)  
		 AND CS.ScheduleDate < DATEADD(d, 1, @EndDate)
		 AND C.AgentID = @AgentID
		 AND C.[Delete] = 'N'
		 ORDER BY StartTime 
	END
	ELSE IF @TransactionMode = 2
	BEGIN
		 SELECT AdhocCOde AS RefNo 
			, TimeDepart AS StartTime
			, TimeReturn AS EndTime
			, CASE WHEN UPPER(TripType) = 'ONE WAY' THEN TripFrom + ' > ' + TripTo 
				ELSE TripFrom + ' <> ' + TripTo END  AS Description
			, Seater AS Pax
			, 'Daily' AS RatesType
			, DriverClaim AS Rates
		 FROM ADHOC
		 WHERE AdhocBookDate > DATEADD(d, -1, @StartDate)  
		 AND AdhocBookDate < DATEADD(d, 1, @EndDate)
		 AND AgentID = @AgentID 
		 AND [Delete] = 'N'
		 ORDER BY StartTime 
	END
	ELSE IF @TransactionMode = 3
	BEGIN
		 SELECT C.BookingCode AS RefNo 
			, CS.StartTime 
			, CS.EndTime 
			, CASE WHEN UPPER(C.TripType) = 'ONE WAY' THEN C.TripFrom + ' > ' + C.TripTo 
				ELSE C.TripFrom + ' <> ' + C.TripTo END  AS Description
			, C.Seater AS Pax
			, CASE WHEN C.RatesType = 1 THEN 'Daily' 
				ELSE 'Contract' END AS RatesType
			, C.Rates
		 FROM Contract AS C 
		 INNER JOIN CONTRACTSCHedule AS CS ON (C.ContractID = CS.ContractID)
		 WHERE CS.ScheduleDate  > DATEADD(d, -1, @StartDate) 
		 AND CS.ScheduleDate < DATEADD(d, 1, @EndDate)
		 AND C.AgentID = @AgentID
		 AND C.[Delete] = 'N'

		 UNION ALL
		 
		 SELECT AdhocCOde AS RefNo 
			, TimeDepart AS StartTime
			, TimeReturn AS EndTime
			, CASE WHEN UPPER(TripType) = 'ONE WAY' THEN TripFrom + ' > ' + TripTo 
				ELSE TripFrom + ' <> ' + TripTo END  AS Description
			, Seater AS Pax
			, 'Daily' AS RatesType
			, DriverClaim AS Rates
		 FROM ADHOC
		 WHERE AdhocBookDate  > DATEADD(d, -1, @StartDate)  
		 AND AdhocBookDate < DATEADD(d, 1, @EndDate)
		 AND AgentID = @AgentID 
		 AND [Delete] = 'N'

		 ORDER BY StartTime   
	END
  
END

GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
IF OBJECT_ID('dbo.usp_WocBookSearchInvoice') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE dbo.usp_WocBookSearchInvoice >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE dbo.usp_WocBookSearchInvoice >>>'
GO
