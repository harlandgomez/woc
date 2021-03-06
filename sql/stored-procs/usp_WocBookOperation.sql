USE [ANS]ഀ
GOഀ
/****** Object:  StoredProcedure [dbo].[usp_WocBookOperation]    Script Date: 09/20/2011 22:33:33 ******/ഀ
SET ANSI_NULLS ONഀ
GOഀ
SET QUOTED_IDENTIFIER OFFഀ
GOഀ
ALTERഀ
ഀ
PROCEDURE [dbo].[usp_WocBookOperation](ഀ
ഀ
@OperationDate datetime,ഀ
@Route NVarchar(50),ഀ
@RefNo NVarchar(50),ഀ
@Remarks  NVarchar(50),ഀ
@StartTime DateTime,ഀ
@StartBusNo NVarchar(50),ഀ
@EndTime DateTime,ഀ
@EndBusNo NVarchar(50),ഀ
@TransactionMode INTഀ
ഀ
ഀ
)ഀ
ASഀ
ഀ
BEGINഀ
ഀ
Declare @UniOperationID  Uniqueidentifier ഀ
Declare @DriverCode NVarchar(50)ഀ
Declare @DriverName NVarchar(50)ഀ
Declare @Person NVarchar(50)ഀ
Declare @Contact NVarchar(50)ഀ
Declare @AgentID Uniqueidentifierഀ
Declare @Agent  NVarchar(100)ഀ
ഀ
SET @UniOperationID = newID()ഀ
IF @TransactionMode = 1ഀ
		BEGIN ഀ
ഀ
			INSERT INTO [Operation]ഀ
				   (ഀ
					 OperationID,ഀ
					 OperationDate,ഀ
					 [Route],ഀ
					 RefNo,ഀ
					 Remarks,ഀ
					 StartTime,ഀ
					 StartBusNo,ഀ
					 EndTime,ഀ
					 EndBusNoഀ
					)ഀ
		           ഀ
			 VALUESഀ
					(ഀ
					  @UniOperationID,ഀ
					  @OperationDate,ഀ
					  @Route,ഀ
					  @RefNo,ഀ
					  @Remarks,ഀ
					  @StartTime,ഀ
					  @StartBusNo,ഀ
					  @EndTime,ഀ
					  @EndBusNo ഀ
		             ഀ
					)ഀ
			 ഀ
ഀ
ഀ
		 Select  Top 1 @DriverCode = DriverCode,@DriverName = DriverName from Driver where Busno = @StartBusNoഀ
  ഀ
		 select Top 1  @Person = PersonInCharge,@Contact = Contact, @AgentID  = AgentID  from Adhoc where  AdhocCode = @RefNoഀ
		  ഀ
		 IF (@AgentID = NULL)ഀ
		  BEGINഀ
			  select Top 1  @Person = PersonInCharge,@Contact = Contact, @AgentID  = AgentID  from  [Contract] where  BookingCode= @RefNo ഀ
		  ENDഀ
			  ഀ
		 select Top 1 @Agent = Agent from Agent where   @AgentID  = AgentID ഀ
  ഀ
  ഀ
ഀ
			INSERT INTO [OperationDetail]ഀ
			ഀ
		       (ഀ
				 OperationDetailID,ഀ
				 OperationID,ഀ
				 DriverCode,ഀ
				 BusNo,ഀ
				 DriverName,ഀ
				 TripTime,ഀ
				 [Route],ഀ
				 Customer,ഀ
				 Person,ഀ
				 Contact,ഀ
				 SegmentTypeഀ
				)ഀ
			VALUESഀ
			  (ഀ
				 ഀ
				 NEWID(),ഀ
				 @UniOperationID,ഀ
				 @DriverCode,ഀ
				 @StartBusNo,ഀ
				 @DriverName,ഀ
				 @StartTime,ഀ
				 @Route,ഀ
				 @Agent,ഀ
				 @Person,ഀ
				 @Contact,ഀ
				 'S'ഀ
		       ഀ
			  )ഀ
			  ഀ
			  IF @EndBusNo <> '' ഀ
			  BEGINഀ
				SELECT  Top 1 @DriverCode = DriverCode,@DriverName = DriverName from Driver where Busno = @EndBusNoഀ
				SELECT  Top 1  @Person = PersonInCharge,@Contact = Contact, @AgentID  = AgentID  from Adhoc where  AdhocCode = @RefNoഀ
				IF (@AgentID = NULL)ഀ
				 BEGINഀ
					  select Top 1  @Person = PersonInCharge,@Contact = Contact, @AgentID  = AgentID  from  [Contract] where  BookingCode= @RefNo ഀ
				  ENDഀ
				SELECT Top 1 @Agent = Agent from Agent where   @AgentID  = AgentID ഀ
				  INSERT INTO [OperationDetail]ഀ
				ഀ
				   (ഀ
					 OperationDetailID,ഀ
					 OperationID,ഀ
					 DriverCode,ഀ
					 BusNo,ഀ
					 DriverName,ഀ
					 TripTime,ഀ
					 [Route],ഀ
					 Customer,ഀ
					 Person,ഀ
					 Contact,ഀ
					 SegmentTypeഀ
					)ഀ
				  VALUESഀ
				   (ഀ
					 NEWID(),ഀ
					 @UniOperationID,ഀ
					 @DriverCode,ഀ
					 @StartBusNo,ഀ
					 @DriverName,ഀ
					 @StartTime,ഀ
					 @Route,ഀ
					 @Agent,ഀ
					 @Person,ഀ
					 @Contact,ഀ
					 'E'ഀ
				  )ഀ
			ഀ
			  ENDഀ
ഀ
		ENDഀ
ENDഀ
ഀ
ഀ
