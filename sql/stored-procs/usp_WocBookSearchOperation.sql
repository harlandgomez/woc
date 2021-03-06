
/****** Object:  StoredProcedure [dbo].[usp_WocBookSearchOperation]    Script Date: 10/22/2011 11:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER

PROCEDURE [dbo].[usp_WocBookSearchOperation](
@OperationDate DateTime 
)
AS

DECLARE @RefNo NVARCHAR(50)

select Top 1 @RefNo = RefNo from Operation Where OperationDate = @OperationDate

IF (@RefNo is null)
BEGIN

  SELECT Adhoc.AdhocCode as RefNo,
  Adhoc.AdhocBookDate as OperationDate,
  Adhoc.TimeDepart as StartTime,
  Adhoc.TimeReturn as EndTime,
  '' as StartBusNo,
  '' as EndBusNo,
  CASE Adhoc.TripType
  WHEN 'One Way' THEN Adhoc.TripFrom + ' > ' + Adhoc.TripTo ELSE Adhoc.TripFrom + ' <> ' + Adhoc.TripTo END AS [Route],
  Adhoc.TripType,
  Adhoc.Purpose as Remarks,
  Adhoc.Seater as Pax
  FROM Adhoc
  INNER JOIN Agent ON Adhoc.AgentID = Agent.AgentID
  WHERE convert(varchar, Adhoc.AdhocBookDate, 103)   = convert(varchar, @OperationDate, 103) 
  UNION ALL

  SELECT Distinct
  Contract.BookingCode as RefNo,     
  ContractSchedule.ScheduleDate as OperationDate,
  ContractSchedule.StartTime,
  ContractSchedule.EndTime,
  '' as StartBusNo,
  '' as EndBusNo, 
  CASE Contract.TripType 
  WHEN 'One Way' THEN Contract.TripFrom + ' > ' + Contract.TripTo ELSE Contract.TripFrom + ' <> ' + Contract.TripTo END AS [Route],
  Contract.TripType,
  Contract.Remarks1 + ' ' +  Contract.Remarks1 as Remarks,
  Contract.Seater as Pax
  FROM  Contract INNER JOIN
  ContractSchedule ON Contract.ContractID = ContractSchedule.ContractID

  where convert(varchar, ContractSchedule.ScheduleDate, 103)   = convert(varchar, @OperationDate, 103) 
  

  END

ELSE

BEGIN
  select RefNo,OperationDate,StartTime,EndTime,StartBusNo,EndBusNo,'' As TripType,[Route],'' As TripType,Remarks, Pax FROM Operation Where OperationDate = @OperationDate
END

