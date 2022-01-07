IF OBJECT_ID('dbo.Setting') IS NOT NULL
BEGIN
    DROP TABLE dbo.Setting
    IF OBJECT_ID('dbo.Setting') IS NOT NULL
        PRINT '<<< FAILED DROPPING TABLE dbo.Setting >>>'
    ELSE
        PRINT '<<< DROPPED TABLE dbo.Setting >>>'
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO


CREATE TABLE [dbo].[Setting](
	[SettingID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[SettingCode] [nvarchar](50) NOT NULL UNIQUE,
	[Value] [nvarchar](max) NULL,
	[DefaultValue] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[LocaleAware] [bit] NOT NULL,
 CONSTRAINT [PK_setting] PRIMARY KEY CLUSTERED 
(
	[SettingID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Setting] ADD  CONSTRAINT [DF_setting_SettingID]  DEFAULT (newid()) FOR [SettingID]
GO

ALTER TABLE [dbo].[Setting] ADD  CONSTRAINT [DF_Setting_LocaleAware]  DEFAULT ((0)) FOR [LocaleAware]
GO



SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
IF OBJECT_ID('dbo.Setting') IS NOT NULL
    PRINT '<<< CREATED TABLE dbo.Setting >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE dbo.Setting >>>'
GO

INSERT INTO [setting] (SettingID,[SettingCode],[Value],[DefaultValue],[Description],[LocaleAware])VALUES(newID(),'DROPDOWN_SEATER','25|25,29|29,39|39,49|49','25|25,29|29,39|39,49|49','Values in seater dropdownlist',0)
INSERT INTO [setting] (SettingID,[SettingCode],[Value],[DefaultValue],[Description],[LocaleAware])VALUES(newID(),'DROPDOWN_PAGESIZE','10|10,20|20,40|40,80|80,100|100,200|200','10|10,20|20,40|40,80|80,100|100,200|200','Values in Dropdownlist use in grid''s pagesize.',0)
INSERT INTO [setting] (SettingID,[SettingCode],[Value],[DefaultValue],[Description],[LocaleAware])VALUES(newID(),'GST_PERCENTAGE','0.07','0.07','Goods and Services Tax',1)
