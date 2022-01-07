IF OBJECT_ID('dbo.Users') IS NOT NULL
BEGIN
    DROP TABLE dbo.Users
    IF OBJECT_ID('dbo.Users') IS NOT NULL
        PRINT '<<< FAILED DROPPING TABLE dbo.Users >>>'
    ELSE
        PRINT '<<< DROPPED TABLE dbo.Users >>>'
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE TABLE [dbo].[Users](
	[UserID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[LoginID] [nvarchar](20) NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[MiddleName] [nvarchar](50) NULL,
	[NRIC] [nvarchar](8) NULL,
	[Address1] [nvarchar](200) NULL,
	[Contact] [nvarchar](100) NULL,
	[DOB] [nvarchar](100) NULL,
	[CountryID] [uniqueidentifier] NOT NULL,
	[AccessLevelID] [uniqueidentifier] NOT NULL,
	[Password] [nvarchar](200) NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [uniqueidentifier] NOT NULL,
	[UpdatedDate] [datetime] NULL,
	[Resigned] [nvarchar](50) NULL,
	[Delete] [nvarchar](50) NULL,
	[Address2] [nvarchar](200) NULL,
	[Address3] [nvarchar](200) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_User_AccessLevel] FOREIGN KEY([AccessLevelID])
REFERENCES [dbo].[AccessLevel] ([AccessLevelID])
GO

ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_User_AccessLevel]
GO

ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_User_Country] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Country] ([CountryID])
GO

ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_User_Country]
GO

ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_User_UserID]  DEFAULT (newid()) FOR [UserID]
GO

ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Delete]  DEFAULT ('N') FOR [Delete]
GO


GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
IF OBJECT_ID('dbo.Users') IS NOT NULL
    PRINT '<<< CREATED TABLE dbo.Users >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE dbo.Users >>>'
GO