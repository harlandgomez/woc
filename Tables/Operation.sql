USE [ANS]
GO

/****** Object:  Table [dbo].[Operation]    Script Date: 09/04/2011 13:42:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Operation](
	[OperationID] [uniqueidentifier] NOT NULL,
	[OperationDate] [datetime] NOT NULL,
	[Route] [nvarchar](50) NULL,
	[RefNo] [nvarchar](50) NULL,
	[Remarks] [nvarchar](50) NULL,
	[StartBusNo] [nvarchar](50) NULL,
	[StartTime] [datetime] NULL,
	[EndBusNo] [nvarchar](50) NULL,
	[EndTime] [datetime] NULL,
	[OperationType] [nvarchar](10) NULL
) ON [PRIMARY]

GO


