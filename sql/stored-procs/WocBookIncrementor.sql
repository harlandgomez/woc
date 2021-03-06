IF OBJECT_ID('dbo.sp_WocBookIncrementor') IS NOT NULLഀ
BEGINഀ
    DROP PROCEDURE dbo.sp_WocBookIncrementorഀ
    IF OBJECT_ID('dbo.sp_WocBookIncrementor') IS NOT NULLഀ
        PRINT '<<< FAILED DROPPING PROCEDURE dbo.sp_WocBookIncrementor >>>'ഀ
    ELSEഀ
        PRINT '<<< DROPPED PROCEDURE dbo.sp_WocBookIncrementor >>>'ഀ
ENDഀ
GOഀ
SET ANSI_NULLS ONഀ
GOഀ
SET QUOTED_IDENTIFIER OFFഀ
GOഀ
ഀ
CREATE PROCEDURE [dbo].[sp_WocBookGSTType](ഀ
@ColumnCode NVARCHAR(50),ഀ
@SequenceCount INT,ഀ
@CreatedBy UNIQUEIDENTIFIER,ഀ
@QueryTypeID INTഀ
/* WITH ENCRYPTION */ഀ
)ഀ
ASഀ
BEGINഀ
ഀ
	IF @QueryTypeID = 1 ഀ
	BEGINഀ
		DECLARE @RoWCount INTഀ
		ഀ
		SELECT @RoWCount = (MAX(SequenceCount) + 1) ഀ
		FROM Sequenceഀ
		WHERE ColumnCode = @ColumnCodeഀ
		ഀ
		IF @RoWCount = 0 ഀ
		BEGINഀ
			INSERT INTO Sequence(SequenceCount,ColumnCode,CreatedBy,CreatedDate)ഀ
			VALUES(1,@ColumnCode,@CreatedBy,GetDate())ഀ
		ENDഀ
		ഀ
		RETURN @RoWCountഀ
	ENDഀ
	ഀ
	IF @QueryTypeID = 2ഀ
	BEGINഀ
		UPDATE Sequenceഀ
		SET SequenceCount = @SequenceCountഀ
		WHERE ColumnCode = @ColumnCodeഀ
	END ഀ
ENDഀ
ഀ
GOഀ
SET ANSI_NULLS OFFഀ
GOഀ
SET QUOTED_IDENTIFIER OFFഀ
GOഀ
IF OBJECT_ID('dbo.sp_WocBookSequence') IS NOT NULLഀ
    PRINT '<<< CREATED PROCEDURE dbo.sp_WocBookSequence >>>'ഀ
ELSEഀ
    PRINT '<<< FAILED CREATING PROCEDURE dbo.sp_WocBookSequence >>>'ഀ
GO