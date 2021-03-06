IF OBJECT_ID('dbo.usp_WocBookSetting') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.usp_WocBookSetting
    IF OBJECT_ID('dbo.usp_WocBookSetting') IS NOT NULL
        PRINT '<<< FAILED DROPPING PROCEDURE dbo.usp_WocBookSetting >>>'
    ELSE
        PRINT '<<< DROPPED PROCEDURE dbo.usp_WocBookSetting >>>'
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[usp_WocBookSetting]
(
@SettingID UNIQUEIDENTIFIER = NULL,
@SettingCode NVARCHAR(100) = NULL,
@Value NVARCHAR(MAX) = NULL,
@DefaultValue NVARCHAR(MAX) = NULL,
@Description NVARCHAR(500) = NULL,
@LocaleAware bit = 0,
@TransactionMode INT = 1
/* WITH ENCRYPTION */
)
AS
BEGIN
	
	IF @TransactionMode = 1
	BEGIN
		SELECT Coalesce(Value, DefaultValue) AS Value
		FROM Setting
		WHERE SettingCode = @SettingCode	
	END
	ELSE IF @TransactionMode = 2
	BEGIN
		SELECT Coalesce(Value, DefaultValue) AS Value,
			[Description] 
		FROM Setting
		WHERE SettingCode = @SettingCode	
	END
	ELSE IF @TransactionMode = 3
	BEGIN
		INSERT INTO Setting
           ([SettingID]
           ,[SettingCode]
           ,[Value]
           ,[DefaultValue]
           ,[Description]
           ,[LocaleAware])
		VALUES
           (newID()
           ,@SettingCode
           ,@Value
           ,@DefaultValue
           ,@Description
           ,@LocaleAware)
	END
	ELSE IF @TransactionMode = 4
	BEGIN
		UPDATE Setting
			SET [Value] = @Value
			,	[DefaultValue] = @DefaultValue
			,	[Description] = @Description
			,	[LocaleAware] = @LocaleAware
        WHERE SettingCode = @SettingCode
	END
END

GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
IF OBJECT_ID('dbo.usp_WocBookSetting') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE dbo.usp_WocBookSetting >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE dbo.usp_WocBookSetting >>>'
GO