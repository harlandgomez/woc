USE [ANS]
GO

/****** Object:  Table [dbo].[OperationDetail]    Script Date: 09/04/2011 13:25:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[OperationDetail](
	[OperationDetailID] [uniqueidentifier] NOT NULL,
	[OperationID] [uniqueidentifier] NOT NULL,
	[DriverCode] [nvarchar](50) NULL,
	[BusNo] [nvarchar](50) NULL,
	[DriverName] [nvarchar](50) NULL,
	[ContactNo] [nvarchar](50) NULL,
	[TripTime] [datetime] NULL,
	[Route] [nvarchar](50) NULL,
	[Customer] [nvarchar](50) NULL,
	[Person] [nvarchar](50) NULL,
	[Contact] [nvarchar](50) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


