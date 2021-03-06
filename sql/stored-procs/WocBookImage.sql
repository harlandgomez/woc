IF OBJECT_ID('dbo.usp_WocBookImage') IS NOT NULLഀ
BEGINഀ
    DROP PROCEDURE dbo.usp_WocBookImageഀ
    IF OBJECT_ID('dbo.usp_WocBookImage') IS NOT NULLഀ
        PRINT '<<< FAILED DROPPING PROCEDURE dbo.usp_WocBookImage >>>'ഀ
    ELSEഀ
        PRINT '<<< DROPPED PROCEDURE dbo.usp_WocBookImage >>>'ഀ
ENDഀ
GOഀ
SET ANSI_NULLS ONഀ
GOഀ
SET QUOTED_IDENTIFIER OFFഀ
GOഀ
ഀ
CREATE PROCEDURE [dbo].[usp_WocBookImage]ഀ
	@FileName NVARCHAR(200) = NULL,ഀ
    @ImageFile IMAGE = NULL,ഀ
    @ContentType NVARCHAR(200) = NULL,ഀ
    @CompanyID UNIQUEIDENTIFIER = NULL,ഀ
    @FileSize INT = NULL,ഀ
    @QueryTypeID INT = 1ഀ
  ഀ
ASഀ
ഀ
IF @QueryTypeID = 1ഀ
BEGINഀ
	INSERT INTO [Image](ImageId,[ImageFile],[FileName],[ContentType],[FileSize],[CompanyID])ഀ
	VALUES(newId(),@ImageFile,@FileName,@ContentType,@FileSize,@CompanyID)ഀ
ENDഀ
ELSE IF @QueryTypeID = 2ഀ
BEGINഀ
	SELECT *ഀ
	FROM [Image]ഀ
	WHERE [CompanyID] = @CompanyIDഀ
ENDഀ
ELSE IF @QueryTypeID = 3ഀ
BEGINഀ
	SELECT ImageFileഀ
	FROM [Image]ഀ
	WHERE [CompanyID] = @CompanyIDഀ
ENDഀ
ഀ
ഀ
GOഀ
SET ANSI_NULLS OFFഀ
GOഀ
SET QUOTED_IDENTIFIER OFFഀ
GOഀ
IF OBJECT_ID('dbo.usp_WocBookImage') IS NOT NULLഀ
    PRINT '<<< CREATED PROCEDURE dbo.usp_WocBookImage >>>'ഀ
ELSEഀ
    PRINT '<<< FAILED CREATING PROCEDURE dbo.usp_WocBookImage >>>'ഀ
GO