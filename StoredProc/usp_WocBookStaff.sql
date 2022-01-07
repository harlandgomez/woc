IF OBJECT_ID('dbo.usp_WocBookStaff') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.usp_WocBookStaff
    IF OBJECT_ID('dbo.usp_WocBookStaff') IS NOT NULL
        PRINT '<<< FAILED DROPPING PROCEDURE dbo.usp_WocBookStaff >>>'
    ELSE
        PRINT '<<< DROPPED PROCEDURE dbo.usp_WocBookStaff >>>'
END
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE

PROCEDURE [dbo].[usp_WocBookStaff](
@LoginID NVARCHAR(20),
@NRIC NVARCHAR(8),
@Address1 NVARCHAR(200),
@Address2 NVARCHAR(200),
@Address3 NVARCHAR(200),
@Contact NVARCHAR(100),
@DOB NVARCHAR(100),
@CountryID uniqueidentifier,
@AccessLevelID uniqueidentifier,
@Password NVARCHAR(200),
@CreatedBy uniqueidentifier,
@UpdatedBy uniqueidentifier,
@TransactionMode INT
)
AS

BEGIN

     IF @TransactionMode = 1
		BEGIN 

				INSERT INTO Users

				(
				LoginID,
				NRIC,
				Address1,
				Address2,
				Address3,
				Contact,
				DOB,
				CountryID,
				AccessLevelID,
				[Password],
				CreatedBy,
				CreatedDate,
				UpdatedBy
				)
					
				VALUES

				(
				@LoginID,
				@NRIC,
				@Address1,
				@Address2,
				@Address3,
				@Contact,
				@DOB,
				@CountryID,
				@AccessLevelID,
				@Password,
				@CreatedBy,
				getdate(),
				@UpdatedBy
				)
				
	   END
	ELSE IF @TransactionMode = 2
		BEGIN
			UPDATE Users

			 SET NRIC=@NRIC, 
			 [Address1]=@Address1,
			 [Contact] = @Contact,
			 DOB = @DOB,
			 CountryID = @CountryID,
			 AccessLevelID = @AccessLevelID,
			 [Password] = @Password,
			 CreatedBy = @CreatedBy,
			 UpdatedBy =@UpdatedBy,
			 CreatedDate = getdate(),
			 UpdatedDate = getDate()
			 
			 WHERE LoginID=@LoginID;

		 END
	ELSE IF @TransactionMode = 3
		BEGIN
			UPDATE Users

			 SET 
			 [Delete] = 'Y',
			 CreatedBy = @CreatedBy,
			 UpdatedBy =@UpdatedBy,
			 CreatedDate = getdate(),
			 UpdatedDate = getDate()
			 
			 WHERE LoginID=@LoginID;

		END
	  ELSE IF @TransactionMode = 4
		BEGIN 
			UPDATE Users

			 SET 
			 [Resigned] = 'Y',
			 CreatedBy = @CreatedBy,
			 UpdatedBy =@UpdatedBy,
			 CreatedDate = getdate(),
			 UpdatedDate = getDate()
			 
			 WHERE LoginID=@LoginID;
		END
END

GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
IF OBJECT_ID('dbo.usp_WocBookStaff') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE dbo.usp_WocBookStaff >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE dbo.usp_WocBookStaff >>>'
GO



