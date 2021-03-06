IF OBJECT_ID('dbo.usp_WocBookAgent') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.usp_WocBookAgent
    IF OBJECT_ID('dbo.usp_WocBookAgent') IS NOT NULL
        PRINT '<<< FAILED DROPPING PROCEDURE dbo.usp_WocBookAgent >>>'
    ELSE
        PRINT '<<< DROPPED PROCEDURE dbo.usp_WocBookAgent >>>'
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE 

PROCEDURE [dbo].[usp_WocBookAgent](
@AgentCode nvarchar(100),
@Agent nvarchar(100),
@Prefix nvarchar(50) = null,
@Address nvarchar(200) = null,
@Email nvarchar(50) = null,
@Telephone nvarchar(15) = null,
@Fax nvarchar(200) = null,
@PostalCode nvarchar(50) = null,
@ContactPerson1 nvarchar(100) = null,
@Destination1 nvarchar(100) = null,
@HP1 nvarchar(100) = null,
@Stop bit = null,
@StopDate datetime = null,
@ContactTelephone1 nvarchar(100) = null,
@ContactPerson2 nvarchar(100) = null,
@Destination2 nvarchar(100) = null,
@HP2 nvarchar(100) = null,
@ContactTelephone2 nvarchar(100) = null,
@UserName nvarchar(100) = null,
@Password nvarchar(100) = null,
@CreatedBy uniqueidentifier  = null,
@CreatedDate datetime  = null,
@UpdatedBy uniqueidentifier  = null,
@UpdatedDate datetime  = null,
@Delete nvarchar(100)  = null,
@TransactionMode INT
)
AS

BEGIN

IF @TransactionMode = 1
BEGIN 

	INSERT INTO [Agent]
           ([AgentID]
           ,[AgentCode]
           ,[Agent]
           ,[Prefix]
           ,[Address]
           ,[Email]
           ,[Telephone]
           ,[Fax]
           ,[PostalCode]
           ,[ContactPerson1]
           ,[Destination1]
           ,[HP1]
           ,[Stop]
           ,[StopDate]
           ,[ContactTelephone1]
           ,[ContactPerson2]
           ,[Destination2]
           ,[HP2]
           ,[ContactTelephone2]
           ,[UserName]
           ,[Password]
           ,[Delete]
           ,[CreatedBy]
           ,[CreatedDate])
           
     VALUES
            (NEWID(),
            @AgentCode,
			@Agent,
			@Prefix,
			@Address,
			@Email,
			@Telephone,
			@Fax,
		    @PostalCode,
			@ContactPerson1,
			@Destination1,
			@HP1,
			@Stop,
			@StopDate,
			@ContactTelephone1,
			@ContactPerson2,
			@Destination2,
			@HP2,
			@ContactTelephone2,
			@UserName,
			@Password,
			@Delete,
			@CreatedBy,
			@CreatedDate)
	END 

IF @TransactionMode = 2
BEGIN
	UPDATE Agent
	SET 
	Agent = @Agent,
	Prefix = @Prefix,
	[Address] = @Address,
	Email =	@Email,
	Telephone =	@Telephone,
	Fax = @Fax,
	PostalCode = @PostalCode,
	ContactPerson1 = @ContactPerson1,
	Destination1 = @Destination1,
	HP1 = @HP1,
	[Stop] = @Stop,
	StopDate = @StopDate,
	ContactTelephone1 =	@ContactTelephone1,
	ContactPerson2 = @ContactPerson2,
	Destination2 = @Destination2,
	HP2 = @HP2,
	ContactTelephone2 =	@ContactTelephone2,
	UserName = @UserName,
	[Password] = @Password,
	UpdatedBy = @UpdatedBy,
	UpdatedDate = getDate()
	WHERE AgentCode= @AgentCode;
END

IF @TransactionMode = 3
BEGIN 
	UPDATE Agent
	SET [Delete] = 'Y',
	CreatedBy = @CreatedBy,
	UpdatedBy = @UpdatedBy,
	CreatedDate = getdate(),
	UpdatedDate = getDate()
	WHERE AgentCode=@AgentCode;
END

END


GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
IF OBJECT_ID('dbo.usp_WocBookAgent') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE dbo.usp_WocBookAgent >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE dbo.usp_WocBookAgent >>>'
GO