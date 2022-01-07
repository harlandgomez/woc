USE [ANS]
GO

/****** Object:  Table [dbo].[AccessLevel]    Script Date: 10/23/2011 08:59:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AccessLevel](
	[AccessLevelID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[AccessLevel] [nchar](10) NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [uniqueidentifier] NOT NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_AccessLevel] PRIMARY KEY CLUSTERED 
(
	[AccessLevelID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[AccessLevel] ADD  CONSTRAINT [DF_AccessLevel_AccessLevelID]  DEFAULT (newid()) FOR [AccessLevelID]
GO


