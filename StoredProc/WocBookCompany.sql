IF OBJECT_ID('dbo.sp_WocBookCompany') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.sp_WocBookCompany
    IF OBJECT_ID('dbo.sp_WocBookCompany') IS NOT NULL
        PRINT '<<< FAILED DROPPING PROCEDURE dbo.sp_WocBookCompany >>>'
    ELSE
        PRINT '<<< DROPPED PROCEDURE dbo.sp_WocBookCompany >>>'
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE

PROCEDURE [dbo].[sp_WocBookCompany](
@CompanyCode NVARCHAR(50),
@Company NVARCHAR(100),
@Address NVARCHAR(200),
@Telephone NVARCHAR(15),
@Fax NVARCHAR(200),
@Email NVARCHAR(15),
@Website NVARCHAR(50),
@ROC NVARCHAR(50),
@Prefix NVARCHAR(50),
@GST NVARCHAR(50),
@ReflectToOperation NVARCHAR(1),
@CreatedBy  UNIQUEIDENTIFIER = NULL,
@UpdatedBy UNIQUEIDENTIFIER = NULL,
@QueryTypeID INT = 1,
@CompanyID UNIQUEIDENTIFIER OUTPUT
)
AS

BEGIN

IF @QueryTypeID = 1
BEGIN 
	DECLARE @newID UNIQUEIDENTIFIER
	SET @newID = newID()
	
	INSERT INTO Company
       (CompanyID
       ,CompanyCode
       ,[Company]
       ,[Address]
       ,[Telephone]
       ,[Fax]
       ,[Email]
       ,[Website]
       ,[ROC]
       ,[Prefix]
       ,[GST]
       ,[ReflectToOperation]
       ,[CreatedBy]
       ,[CreatedDate])
     VALUES
		(@newID
		,@CompanyCode
		,@Company
		,@Address
		,@Telephone
		,@Fax
		,@Email
		,@Website
		,@ROC
		,@Prefix
		,@GST
		,@ReflectToOperation
		,@CreatedBy
		,GetDate())
		
	SET @CompanyID = @newID
END 

IF @QueryTypeID = 2
BEGIN
	UPDATE Company
		SET [Company] = @Company
		  ,[Address] = @Address
		  ,[Telephone] = @Telephone
		  ,[Fax] = @Fax
		  ,[Email] = @Email
		  ,[Website] = @Website
		  ,[ROC] = @ROC
		  ,[Prefix] = @Prefix
		  ,[GST] = @GST
		  ,[ReflectToOperation] = @ReflectToOperation
		  ,[UpdatedBy] = @UpdatedBy
		  ,[UpdatedDate] = GetDate()
	WHERE CompanyCode=@CompanyCode
END

IF @QueryTypeID = 3
BEGIN 
	UPDATE Company
	SET [Delete] = 'Y',
	CreatedBy = @CreatedBy,
	UpdatedBy =@UpdatedBy,
	CreatedDate = getdate(),
	UpdatedDate = getDate()
	WHERE CompanyCode=@CompanyCode;
END

END

GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
IF OBJECT_ID('dbo.sp_WocBookCompany') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE dbo.sp_WocBookCompany >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE dbo.sp_WocBookCompany >>>'
GO


