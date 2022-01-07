IF OBJECT_ID('dbo.usp_WocBookSubCon') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.usp_WocBookSubCon
    IF OBJECT_ID('dbo.usp_WocBookSubCon') IS NOT NULL
        PRINT '<<< FAILED DROPPING PROCEDURE dbo.usp_WocBookSubCon >>>'
    ELSE
        PRINT '<<< DROPPED PROCEDURE dbo.usp_WocBookSubCon >>>'
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE

PROCEDURE usp_WocBookSubCon(
@SubConCode NVARCHAR(50),
@Company NVARCHAR(100),
@Initial NVARCHAR(50),
@Person NVARCHAR(200),
@Fax NVARCHAR(50),
@Telephone NVARCHAR(50),
@Mobile NVARCHAR(50),
@Address NVARCHAR(200),
@Remarks NVARCHAR(200),
@Passes1 NVARCHAR(50),
@Passes2 NVARCHAR(50),
@Expiry1 DateTime,
@Expiry2 DateTime,
@CreatedBy  UNIQUEIDENTIFIER = NULL,
@UpdatedBy UNIQUEIDENTIFIER = NULL,
@QueryTypeID INT = 1
)
AS

BEGIN

IF @QueryTypeID = 1
BEGIN 
	INSERT INTO Subcon
           ([SubconID]
           ,[Company]
           ,[SubconCode]
           ,[Initial]
           ,[Person]
           ,[Telephone]
           ,[Mobile]
           ,[Fax]
           ,[Address]
           ,[Remarks]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[Passes1]
           ,[Passes2]
           ,[Expiry1]
           ,[Expiry2])
     VALUES
           (newID()
           ,@Company
           ,@SubconCode
           ,@Initial
           ,@Person
           ,@Telephone
           ,@Mobile
           ,@Fax
           ,@Address
           ,@Remarks
           ,@CreatedBy
           ,GetDate()
           ,@Passes1
           ,@Passes2
           ,@Expiry1
           ,@Expiry2)

END 

IF @QueryTypeID = 2
BEGIN
	UPDATE Subcon
	   SET [Company] = @Company
		  ,[Person] = @Person
		  ,[Initial] = @Initial
		  ,[Telephone] = @Telephone
		  ,[Mobile] = @Mobile
		  ,[Fax] = @Fax
		  ,[Address] = @Address
		  ,[Remarks] = @Remarks
		  ,[UpdatedBy] = @UpdatedBy
		  ,[UpdatedDate] = GetDate()
		  ,[Passes1] = @Passes1
		  ,[Passes2] = @Passes2
		  ,[Expiry1] = @Expiry1
		  ,[Expiry2] = @Expiry2
	 WHERE SubconCode=@SubconCode

END

IF @QueryTypeID = 3
BEGIN 
	UPDATE Subcon
	SET [Delete] = 'Y',
	UpdatedBy =@UpdatedBy,
	UpdatedDate = getDate()
	WHERE SubconCode=@SubconCode;
END

END

GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
IF OBJECT_ID('dbo.usp_WocBookSubCon') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE dbo.usp_WocBookSubCon >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE dbo.usp_WocBookSubCon >>>'
GO


