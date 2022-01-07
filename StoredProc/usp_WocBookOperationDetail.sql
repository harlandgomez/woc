IF OBJECT_ID('dbo.usp_WocBookOperationDetail') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.usp_WocBookOperationDetail
    IF OBJECT_ID('dbo.usp_WocBookOperationDetail') IS NOT NULL
        PRINT '<<< FAILED DROPPING PROCEDURE dbo.usp_WocBookOperationDetail >>>'
    ELSE
        PRINT '<<< DROPPED PROCEDURE dbo.usp_WocBookOperationDetail >>>'
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE

PROCEDURE dbo.usp_WocBookOperationDetail(

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
		
		DECLARE @tmpSegmentType NVARCHAR(5),
				@tmpTripTime DATETIME,
				@tmpBusNo NVARCHAR(100)
		
		SELECT @tmpSegmentType = SegmentType 
			, @tmpTripTime = TripTime
			, @tmpBusNo = BusNo
		FROM OperationDetail 
		WHERE OperationDetailID = @OperationDetailID 

		DELETE FROM OperationDetail 
		WHERE OperationDetailID = @OperationDetailID
		
		IF @SegmentType = 'S'
			UPDATE Operation
			SET StartBusNo = null 
			WHERE OperationID = @OperationID
				AND CONVERT(VARCHAR(20), StartTime, 100) = CONVERT(VARCHAR(20), @tmpTripTime, 100)
				AND StartBusNo = @tmpBusNo 
		ELSE
			UPDATE Operation
			SET EndBusNo = null 
			WHERE OperationID = @OperationID
				AND CONVERT(VARCHAR(20), EndTime, 100) = CONVERT(VARCHAR(20), @tmpTripTime, 100)
				AND EndBusNo = @tmpBusNo 
	END
	
END
GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
IF OBJECT_ID('dbo.usp_WocBookOperationDetail') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE dbo.usp_WocBookOperationDetail >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE dbo.usp_WocBookOperationDetail >>>'
GO
