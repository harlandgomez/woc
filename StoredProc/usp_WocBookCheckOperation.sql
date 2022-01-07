USE [ANS]
GO
/****** Object:  StoredProcedure [dbo].[usp_WocBookCheckOperation]    Script Date: 10/02/2011 13:49:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE

PROCEDURE [dbo].[usp_WocBookCheckOperation](
@OperationDate DateTime 
)
AS


BEGIN
  select RefNo,OperationDate,StartTime,EndTime,StartBusNo,EndBusNo,'' As TripType,[Route],'' As TripType,Remarks 
  FROM Operation Where OperationDate = @OperationDate
END