IF OBJECT_ID('dbo.sp_WocBookSequence') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.sp_WocBookSequence
    IF OBJECT_ID('dbo.sp_WocBookSequence') IS NOT NULL
        PRINT '<<< FAILED DROPPING PROCEDURE dbo.sp_WocBookSequence >>>'
    ELSE
        PRINT '<<< DROPPED PROCEDURE dbo.sp_WocBookSequence >>>'
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[sp_WocBookSequence](
@ColumnCode NVARCHAR(50),
@QueryTypeID INT = 1
/* WITH ENCRYPTION */
)
AS
BEGIN

	IF @QueryTypeID = 1 
	BEGIN
		DECLARE @RowCount INT,
				@Prefix NVARCHAR(50),
				@Postfix NVARCHAR(50),
				@Len INT
				
		
		SELECT @RowCount = (MAX(SequenceCount) + 1) 
		FROM Sequence
		WHERE ColumnCode = @ColumnCode
		
		IF @RowCount = 0 
		BEGIN
			INSERT INTO Sequence(SequenceCount,ColumnCode)
			VALUES(1,@ColumnCode)
			
			SET @RowCount = 1
		END
		
		SELECT @Prefix = Prefix
			, @Postfix = Postfix
			, @Len = DataLength(CAST(SequenceCount AS VARCHAR))
		FROM Sequence
		WHERE ColumnCode = @ColumnCode		
		
		SELECT Coalesce(@Prefix,'') + RIGHT(REPLICATE('0', @Len) + CAST(@RowCount AS VARCHAR), @Len) + Coalesce(@Postfix,'')
		
		UPDATE Sequence
		SET SequenceCount = RIGHT(REPLICATE('0', @Len) + CAST(@RowCount AS VARCHAR), @Len)
		WHERE ColumnCode = @ColumnCode
	END
END


GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
IF OBJECT_ID('dbo.sp_WocBookSequence') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE dbo.sp_WocBookSequence >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE dbo.sp_WocBookSequence >>>'
GO
