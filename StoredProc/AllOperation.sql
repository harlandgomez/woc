USE [ANS]
GO

/****** Object:  StoredProcedure [dbo].[usp_WocBookDeleteOperation]    Script Date: 09/28/2011 23:09:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


alter

PROCEDURE [dbo].[usp_WocBookDeleteOperation](
@OperationDate DateTime 
)
AS



--BEGIN Tran
 
 Delete from OperationDetail where OperationID in (select OperationID FROM Operation Where OperationDate = @OperationDate)
 delete FROM Operation Where OperationDate = @OperationDate
 

GO

/****** Object:  StoredProcedure [dbo].[usp_WocBookEndOperation]    Script Date: 09/28/2011 23:09:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO

alter

PROCEDURE [dbo].[usp_WocBookEndOperation](

@OperationDate datetime,
@Route NVarchar(50),
@RefNo NVarchar(50),
@Remarks  NVarchar(50),
@EndTime DateTime = null,
@EndBusNo NVarchar(50) = null
)
AS

BEGIN

Declare @UniOperationID  Uniqueidentifier 
Declare @DriverCode NVarchar(50)
Declare @DriverName NVarchar(50)
Declare @Person NVarchar(50)
Declare @Contact NVarchar(50)
Declare @AgentID Uniqueidentifier
Declare @Agent  NVarchar(100)


IF (@EndBusNo IS NULL)
BEGIN
	SET @EndTime  = null
END 

    	Update [Operation]
		
		SET OperationDate = @OperationDate,
					 [Route] = @Route,
					 Remarks =  @Remarks,
					 EndTime = @EndTime,
					 EndBusNo = @EndBusNo
		WHERE  RefNo =  @RefNo
			  IF @EndBusNo <> '' 
			  BEGIN
			  
			    select @UniOperationID = OperationID FROM Operation WHERE  RefNo =  @RefNo
				SELECT  Top 1 @DriverCode = DriverCode,@DriverName = DriverName from Driver where Busno = @EndBusNo
				SELECT  Top 1  @Person = PersonInCharge,@Contact = Contact, @AgentID  = AgentID  from Adhoc where  AdhocCode = @RefNo
				IF (@AgentID = NULL)
				 BEGIN
					  select Top 1  @Person = PersonInCharge,@Contact = Contact, @AgentID  = AgentID  from  [Contract] where  BookingCode= @RefNo 
				  END
				SELECT Top 1 @Agent = Agent from Agent where   @AgentID  = AgentID 
				  INSERT INTO [OperationDetail]
				
				   (
					 OperationDetailID,
					 OperationID,
					-- DriverCode,
					 BusNo,
					 DriverName,
					 TripTime,
					 [Route],
					 Customer,
					 Person,
					 Contact,
					 SegmentType
					)
				  VALUES
				   (
					 NEWID(),
					 @UniOperationID,
				--	 @DriverCode,
					 @EndBusNo,
					 @DriverName,
					 @EndTime,
					 @Route,
					 @Agent,
					 @Person,
					 @Contact,
					 'E'
				  )
			
			  END

	
END



GO

/****** Object:  StoredProcedure [dbo].[usp_WocBookOperation]    Script Date: 09/28/2011 23:09:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO

alter

PROCEDURE [dbo].[usp_WocBookOperation](

@OperationDate datetime,
@Route NVarchar(50),
@RefNo NVarchar(50),
@Remarks  NVarchar(50),
@StartTime DateTime = null,
@StartBusNo NVarchar(50) = null,
@EndTime DateTime = null,
@EndBusNo NVarchar(50) = null



)
AS

BEGIN

Declare @UniOperationID  Uniqueidentifier 
Declare @DriverCode NVarchar(50)
Declare @DriverName NVarchar(50)
Declare @Person NVarchar(50)
Declare @Contact NVarchar(50)
Declare @AgentID Uniqueidentifier
Declare @Agent  NVarchar(100)

IF (@StartBusNo IS NULL)
BEGIN
	SET @StartTime  = null
END 

IF (@EndBusNo IS NULL)
BEGIN
	SET @EndTime  = null
END 

SET @UniOperationID = newID()



			INSERT INTO [Operation]
				   (
					 OperationID,
					 OperationDate,
					 [Route],
					 RefNo,
					 Remarks,
					 StartTime,
					 StartBusNo,
					 EndTime,
					 EndBusNo
					)
		           
			 VALUES
					(
					  @UniOperationID,
					  @OperationDate,
					  @Route,
					  @RefNo,
					  @Remarks,
					  @StartTime,
					  @StartBusNo,
					  @EndTime,
					  @EndBusNo 
		             
					)
			 


	
END



GO

/****** Object:  StoredProcedure [dbo].[usp_WocBookOperationDetail]    Script Date: 09/28/2011 23:09:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO


alter

PROCEDURE [dbo].[usp_WocBookOperationDetail](

@OperationDetailID uniqueidentifier = NULL,
@OperationID uniqueidentifier = NULL,
@SegmentType NVarchar(5) = 'S',
@BusNo	NVarchar(100) = NULL,
@DriverName  NVarchar(100) = NULL,
@ContactNo  NVarchar(100) = NULL,
@TripTime DATETIME = '1/1/1753 12:00:00 AM',
@Route NVarchar(100) = NULL,
@Customer NVarchar(100) = NULL,
@Person NVarchar(100) = NULL,
@Contact NVarchar(100) = NULL,
@TransactionMode INT = 1,
@FieldID INT = 1
)
AS

BEGIN
	-- INSERT FIELD FROM Right Frame
	IF @TransactionMode = 1
	BEGIN
		INSERT INTO OperationDetail(OperationDetailID, OperationID, DriverName, BusNo, ContactNo, TripTime, [Route], Customer, Person, Contact)
		VALUES(newID(), @OperationID, @DriverName, @BusNo, @ContactNo, @TripTime, @Route, @Customer, @Person, @Contact)
	END
	ELSE IF @TransactionMode = 2 -- UPDATE FIELD FROM Right Frame
	BEGIN
		IF @FieldID = 1
		BEGIN
			UPDATE OperationDetail
			SET TripTime = @TripTime
			WHERE OperationDetailID = @OperationDetailID
		END
		ELSE IF @FieldID = 2
		BEGIN
			UPDATE OperationDetail
			SET [Route] = @Route
			WHERE OperationDetailID = @OperationDetailID
		END	
		ELSE IF @FieldID = 3
		BEGIN
			UPDATE OperationDetail
			SET Customer = @Customer
			WHERE OperationDetailID = @OperationDetailID
		END	
		ELSE IF @FieldID = 4
		BEGIN
			UPDATE OperationDetail
			SET Person = @Person
			WHERE OperationDetailID = @OperationDetailID
		END	
		ELSE IF @FieldID = 5
		BEGIN
			UPDATE OperationDetail
			SET Contact = @Contact
			WHERE OperationDetailID = @OperationDetailID
		END	
	END
	ELSE IF  @TransactionMode = 3 -- DELETE FIELD FROM Right Frame
	BEGIN
		DELETE FROM OperationDetail 
		WHERE OperationDetailID = @OperationDetailID
		
		DELETE FROM Operation 
		WHERE OperationID = @OperationID
		AND CASE @SegmentType WHEN 'S' THEN 
				CONVERT(VARCHAR(20), StartTime, 100) 
			ELSE 
				CONVERT(VARCHAR(20), EndTime, 100) 
			END = CONVERT(VARCHAR(20), @TripTime, 100)
		AND CASE @SegmentType WHEN 'S' THEN StartBusNo ELSE EndBusNo END = @BusNo 
	END
	
END

GO

/****** Object:  StoredProcedure [dbo].[usp_WocBookSearchOperation]    Script Date: 09/28/2011 23:09:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


alter

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
		Adhoc.Purpose as Remarks
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
		Contract.Remarks1 + ' ' +  Contract.Remarks1 as Remarks
		FROM  Contract INNER JOIN
		ContractSchedule ON Contract.ContractID = ContractSchedule.ContractID

		where convert(varchar, ContractSchedule.ScheduleDate, 103)   = convert(varchar, @OperationDate, 103) 
		

		END

ELSE

BEGIN
  select RefNo,OperationDate,StartTime,EndTime,StartBusNo,EndBusNo,'' As TripType,[Route],'' As TripType,Remarks FROM Operation Where OperationDate = @OperationDate
END
GO

/****** Object:  StoredProcedure [dbo].[usp_WocBookStartOperation]    Script Date: 09/28/2011 23:09:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO

alter

PROCEDURE [dbo].[usp_WocBookStartOperation](

@OperationDate datetime,
@Route NVarchar(50),
@RefNo NVarchar(50),
@Remarks  NVarchar(50),
@StartTime DateTime = null,
@StartBusNo NVarchar(50) = null
)
AS

BEGIN

Declare @UniOperationID  Uniqueidentifier 
Declare @DriverCode NVarchar(50)
Declare @DriverName NVarchar(50)
Declare @Person NVarchar(50)
Declare @Contact NVarchar(50)
Declare @AgentID Uniqueidentifier
Declare @Agent  NVarchar(100)

IF (@StartBusNo IS NULL)
BEGIN
	SET @StartTime  = null
END 



    	Update [Operation]
		
		SET OperationDate = @OperationDate,
					 [Route] = @Route,
					 Remarks =  @Remarks,
					 StartTime =  @StartTime,
					 StartBusNo = @StartBusNo		
		WHERE  RefNo =  @RefNo
			 
		 select @UniOperationID = OperationID FROM Operation WHERE  RefNo =  @RefNo
		 
		 Select  Top 1 @DriverCode = DriverCode,@DriverName = DriverName from Driver where Busno = @StartBusNo
  
		 select Top 1  @Person = PersonInCharge,@Contact = Contact, @AgentID  = AgentID  from Adhoc where  AdhocCode = @RefNo
		  
		 IF (@AgentID = NULL)
		  BEGIN
			  select Top 1  @Person = PersonInCharge,@Contact = Contact, @AgentID  = AgentID  from  [Contract] where  BookingCode= @RefNo 
		  END
			  
		 select Top 1 @Agent = Agent from Agent where   @AgentID  = AgentID 
  
            IF @StartBusNo <> '' 
               BEGIN
					INSERT INTO [OperationDetail]
					
					   (
						 OperationDetailID,
						 OperationID,
						-- DriverCode,
						 BusNo,
						 DriverName,
						 TripTime,
						 [Route],
						 Customer,
						 Person,
						 Contact,
						 SegmentType
						)
					VALUES
					  (
						 
						 NEWID(),
						 @UniOperationID,
					--	 @DriverCode,
						 @StartBusNo,
						 @DriverName,
						 @StartTime,
						 @Route,
						 @Agent,
						 @Person,
						 @Contact,
						 'S'
				       
					  )
			  END
			 

	
END



GO


