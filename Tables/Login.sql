USE [ANS]
GO

/****** Object:  Table [dbo].[Login]    Script Date: 10/23/2011 09:03:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Login](
	[LoginSystemID] [uniqueidentifier] NOT NULL,
	[LoginID] [nvarchar](50) NULL,
	[LoginOnDate] [datetime] NULL,
	[Message] [nvarchar](50) NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[LoginSystemID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


