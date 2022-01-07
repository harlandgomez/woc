IF OBJECT_ID('dbo.Agent') IS NOT NULL
BEGIN
    DROP TABLE dbo.Agent
    IF OBJECT_ID('dbo.Agent') IS NOT NULL
        PRINT '<<< FAILED DROPPING TABLE dbo.Agent >>>'
    ELSE
        PRINT '<<< DROPPED TABLE dbo.Agent >>>'
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE TABLE [dbo].[Agent](
	[AgentID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[AgentCode] [nvarchar](100) NULL,
	[Agent] [nvarchar](100) NULL,
	[Prefix] [nvarchar](50) NULL,
	[Address] [nvarchar](200) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Telephone] [nvarchar](15) NULL,
	[Fax] [nvarchar](200) NULL,
	[RegistrationNo] [nvarchar](50) NULL,
	[PostalCode] [nvarchar](50) NULL,
	[ContactPerson1] [nvarchar](100) NULL,
	[Destination1] [nvarchar](100) NULL,
	[HP1] [nvarchar](100) NULL,
	[Stop] [bit] NULL,
	[StopDate] [datetime] NULL,
	[ContactTelephone1] [nvarchar](100) NULL,
	[ContactPerson2] [nvarchar](100) NULL,
	[Destination2] [nvarchar](100) NULL,
	[HP2] [nvarchar](100) NULL,
	[ContactTelephone2] [nvarchar](100) NULL,
	[UserName] [nvarchar](100) NULL,
	[Password] [nvarchar](100) NULL,
	[Delete] [nvarchar](100) NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [uniqueidentifier] NOT NULL,
	[UpdatedDate] [datetime] NULL
) ON [PRIMARY]


GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
IF OBJECT_ID('dbo.Agent') IS NOT NULL
    PRINT '<<< CREATED TABLE dbo.Agent >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE dbo.Agent >>>'
GO